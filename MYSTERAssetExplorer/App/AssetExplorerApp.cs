using MYSTERAssetExplorer.Core;
using MYSTERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.App
{
    public class AssetExplorerApp
    {
        const string M3FileExtension = ".M3A";
        const string M4FileExtension = ".M4B";

        string _extractionPath;

        AssetExplorerContext _context;

        RegistryTreeViewManager treeViewManager;

        public AssetExplorerApp(IUIContext uiContext)
        {
            _context = new AssetExplorerContext();
            _context.uiContext = uiContext;
            _context.VirtualFiles = new VirtualFolder("/");
            _context.extractor = new VirtualFileExtractionService();
            _context.registryManager = new RegistryManager(uiContext);
            _context.registryPersistence = new RegistryPersistenceService();

            treeViewManager = new RegistryTreeViewManager(uiContext);

            LoadRegistry();

            treeViewManager.RegenTreeView(_context.registryManager.Registry);
            //var fakeReg = _context.registryManager.CreateFakeRegistry();
            //_context.registryManager.Registry.Exile = fakeReg;
        }

        private void LoadRegistry()
        {
            _context.uiContext.WriteToConsole(Color.Orange, "Loading Registry...");
            var registry = _context.registryPersistence.GetRegistryFromDisk();
            _context.registryManager.Registry = registry;
            treeViewManager.RegenTreeView(_context.registryManager.Registry);
            _context.uiContext.WriteToConsole(Color.Green, "Registry Loaded Successfully!");
        }

        public void SaveRegistry()
        {
            _context.uiContext.WriteToConsole(Color.Orange, "Saving Registry...");
            _context.registryPersistence.SaveRegistryToDisk(_context.registryManager.Registry);
            _context.uiContext.WriteToConsole(Color.Green, "Registry Saved!");
        }

        public void ExtractFiles(string folderPath)
        {
            //_extractionPath = folderPath;
            //if (!Directory.Exists(folderPath))
            //    return;
            //_context.extractor.Extract(_filePath, _context.files, _extractionPath);

        }

        //public CubeMapImageSet GetCurrentSet() // hackiness
        //{
        //    return _context.workspaceModServ.currentSet;
        //}
        //public void SetCurrentSet(CubeMapImageSet imageSet) // hackiness
        //{
        //    _context.workspaceModServ.currentSet = imageSet;
        //}

        public void SetWorkingDirectory(string path)
        {
            var dir = Path.GetDirectoryName(path);
            _context.uiContext.WriteToConsole(Color.Orange, "Opening Folder " + dir);

            if (!Directory.Exists(dir))
                _context.uiContext.WriteToConsole(Color.Red, "The following path is invalid: \"" + dir + "\"");
            _context.DataDirectory = dir;

            var files = LoadDataFiles();

            foreach (var file in files)
            {
                _context.uiContext.WriteToConsole(Color.Green, "Found file " + file);
            }

            IndexAndShowFiles(files);
        }

        private void IndexAndShowFiles(List<string> filePaths)
        {
            _context.uiContext.WriteToConsole(Color.Orange, "Beginning Indexing Thread");

            var indexThread = new Thread(() =>
            {
                var rootFolder = IndexFiles(filePaths, _context.uiContext.WriteToConsole);
                IndexingCompleted(rootFolder);
            });
            indexThread.Start();
        }

        private void IndexingCompleted(VirtualFolder rootFolder)
        {
            _context.uiContext.WriteToConsole(Color.Green, "Indexing Complete!");
            _context.VirtualFiles = rootFolder;

            PopulateFolders();
        }

        private void PopulateFolders()
        {
            var folders = new List<VirtualFolder>();
            var exileFolder = _context.VirtualFiles.SubFolders.FirstOrDefault(x => x.Name == "Exile");
            var revelationFolder = _context.VirtualFiles.SubFolders.FirstOrDefault(x => x.Name == "Revelation");
            if (exileFolder != null)
                folders.Add(exileFolder);
            if (revelationFolder != null)
                folders.Add(revelationFolder);

            _context.uiContext.PopulateFolders(folders);
        }

        private VirtualFolder IndexFiles(List<string> filePaths, Action<Color, string> consoleWrite)
        {
            consoleWrite(Color.Yellow, "Indexing Files...");

            var exileFiles = filePaths.Where(x => Path.GetExtension(x).ToUpper() == M3FileExtension).ToList();
            var revFiles = filePaths.Where(x => Path.GetExtension(x).ToUpper() == M4FileExtension).ToList();

            VirtualFolder exileFolder = new VirtualFolder("Exile");
            VirtualFolder revelationFolder = new VirtualFolder("Revelation");

            var exileIndexer = new M3AFileIndexingService();
            var revIndexer = new M4BFileIndexingService();

            Stopwatch eWatch = new Stopwatch();
            Stopwatch rWatch = new Stopwatch();
            bool[] exileFinished = new bool[exileFiles.Count()];
            bool[] revFinished =  new bool[revFiles.Count()];
            for (int i = 0; i < revFiles.Count(); i++)
            {
                var index = i;
                consoleWrite(Color.Yellow, "Indexing " + Path.GetFileName(revFiles[i]));
                rWatch.Reset(); rWatch.Start();
                var fileThread = new Thread(() =>
                {
                    var indexedFolder = IndexSingleFile(revFiles[index], revIndexer);
                    revelationFolder.SubFolders.Add(indexedFolder);
                    revFinished[index] = true;
                    rWatch.Stop();
                    consoleWrite(Color.Green, Path.GetFileName(revFiles[index]) + " Indexed in " + rWatch.ElapsedMilliseconds + "ms");
                });
                fileThread.Start();
            }
            for (int i = 0; i < exileFiles.Count(); i++)
            {
                var index = i;
                consoleWrite(Color.Yellow, "Indexing " + Path.GetFileName(exileFiles[i]));
                eWatch.Reset(); eWatch.Start();
                var fileThread = new Thread(() =>
                {
                    var indexedFolder = IndexSingleFile(exileFiles[index], exileIndexer);
                    exileFolder.SubFolders.Add(indexedFolder);
                    exileFinished[index] = true;
                    eWatch.Stop();
                    consoleWrite(Color.Green, Path.GetFileName(exileFiles[index]) + " Indexed in " + eWatch.ElapsedMilliseconds + "ms");
                });
                fileThread.Start();
            }

            bool notFinished = true;
            while(notFinished)
            {
                notFinished = !(exileFinished.All(x => x == true) && revFinished.All(x => x == true));
                Thread.Sleep(1000);
            }

            var rootFolder = new VirtualFolder("/");
            rootFolder.SubFolders.Add(exileFolder);
            rootFolder.SubFolders.Add(revelationFolder);
            return rootFolder;
        }

        private VirtualFolder IndexSingleFile(string filePath, IFileIndexerService indexingService)
        {
            var indexedFile = indexingService.IndexFile(filePath);
            return indexedFile;
        }

        public List<string> LoadDataFiles()
        {
            var files = Directory.GetFiles(_context.DataDirectory, "*.*", SearchOption.AllDirectories)
                .Where(s => 
                    s.EndsWith(M3FileExtension, StringComparison.OrdinalIgnoreCase) || 
                    s.EndsWith(M4FileExtension, StringComparison.OrdinalIgnoreCase)
                );
            return files.ToList();
        }
    }
}
