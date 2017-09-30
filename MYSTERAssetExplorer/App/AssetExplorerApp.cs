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
        public string M3A_FileExtension { get { return _context.M3A_FileExtension; } }
        public string M4B_FileExtension { get { return _context.M4B_FileExtension; } }

        AssetExplorerContext _context;

        RegistryTreeViewManager treeViewManager;

        public AssetExplorerApp(IUIContext uiContext)
        {
            _context = new AssetExplorerContext();
            _context.uiContext = uiContext;
            _context.VirtualFiles = new VirtualFolder("/");
            _context.registryManager = new RegistryManager(uiContext);
            _context.registryPersistence = new RegistryPersistenceService();

            treeViewManager = new RegistryTreeViewManager(uiContext);
        }

        public void LoadRegistry()
        {
            _context.uiContext.WriteToConsole(Color.Orange, "Loading Registry...");
            var registry = _context.registryPersistence.GetRegistryFromDisk();
            _context.registryManager.Registry = registry;
            treeViewManager.RegenTreeView(_context.registryManager.Registry);
            _context.uiContext.WriteToConsole(Color.Green, "Registry Loaded Successfully!");

            //temporary, just so I have something to look at
            var fakeReg = _context.registryManager.CreateFakeRegistry();
            _context.registryManager.Registry.Exile = fakeReg;
            treeViewManager.RegenTreeView(_context.registryManager.Registry);
        }

        public void SaveRegistry()
        {
            _context.uiContext.WriteToConsole(Color.Orange, "Saving Registry...");
            _context.registryPersistence.SaveRegistryToDisk(_context.registryManager.Registry);
            _context.uiContext.WriteToConsole(Color.Green, "Registry Saved!");
        }

        public void SetDataDirectory(string path)
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
            var folders = new List<IVirtualFolder>();
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

            var exileFiles = filePaths.Where(x => Path.GetExtension(x).ToLower() == _context.M3A_FileExtension).ToList();
            var revFiles = filePaths.Where(x => Path.GetExtension(x).ToLower() == _context.M4B_FileExtension).ToList();

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

        private IVirtualFolder IndexSingleFile(string filePath, IFileIndexerService indexingService)
        {
            var indexedFile = indexingService.IndexFile(filePath);
            return indexedFile;
        }

        public List<string> LoadDataFiles()
        {
            var files = Directory.GetFiles(_context.DataDirectory, "*.*", SearchOption.AllDirectories)
                .Where(s => 
                    s.EndsWith(_context.M3A_FileExtension, StringComparison.OrdinalIgnoreCase) || 
                    s.EndsWith(_context.M4B_FileExtension, StringComparison.OrdinalIgnoreCase)
                );
            return files.ToList();
        }

        public void SetExtractionDirectory(string path)
        {
            _context.ExtractionDirectory = path;
        }

        public string GetExtractionDirectory()
        {
            return _context.ExtractionDirectory;
        }

        public string GetDataDirectory()
        {
            return _context.DataDirectory;
        }

        public void ExtractFiles(string extractionPath, List<IVirtualFile> files)
        {
            var saveService = new VirtualFileSaveService();
            var extractor = new VirtualFileExtractionService();
            foreach (var file in files)
            {
                _context.uiContext.WriteToConsole(Color.LightBlue, "Extracting " + file.Name);
                var fileData = extractor.GetDataForVirtualFile(file);
                var savefileType = file.ContentDetails.Type;

                if (file.ContentDetails.Type == FileType.Zap)
                {
                    fileData = ConversionService.ConvertFromZapToJpg(fileData);
                    savefileType = FileType.Jpg;
                }
                saveService.SaveFile(extractionPath, file.Name, savefileType, fileData);
            }
        }

        public void ExtractFolder(string extractionPath, IVirtualFolder folder)
        {
            var saveService = new VirtualFileSaveService();
            var extractor = new VirtualFileExtractionService();

            var thisFolderPath = saveService.SaveFolder(extractionPath, folder.Name);

            foreach (var file in folder.Files)
            {
                _context.uiContext.WriteToConsole(Color.LightBlue, "Extracting " + file.Name);
                var fileData = extractor.GetDataForVirtualFile(file);
                var savefileType = file.ContentDetails.Type;

                if (file.ContentDetails.Type == FileType.Zap)
                {
                    fileData = ConversionService.ConvertFromZapToJpg(fileData);
                    savefileType = FileType.Jpg;
                }
                saveService.SaveFile(thisFolderPath, file.Name, savefileType, fileData);
            }
            foreach (var subFolder in folder.SubFolders)
            {
                ExtractFolder(thisFolderPath, subFolder);
            }
        }

        public byte[] GetDataForFile(IVirtualFile file)
        {
            var extractor = new VirtualFileExtractionService();
            return extractor.GetDataForVirtualFile(file);
        }

        public IVirtualFile FindFile(VirtualFileAddress address)
        {
            var lookup = new FileLookupService(_context.VirtualFiles);
            bool couldFind = false;
            return lookup.GetFile(out couldFind, address);
        }
        
        public void FindFile()
        {
            FindExileFile();
            FindRevFile();
        }

        public void FindExileFile()
        {
            var lookupService = new FileLookupService(_context.VirtualFiles);
            var address = new VirtualFileAddress(GameEnum.Exile.ToString(), "Edanna", "SP", "010", "0012.jpg");
            bool fileFound;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var file = lookupService.GetFile(out fileFound, address);
            stopwatch.Stop();
            if (fileFound)
            {
                _context.uiContext.WriteToConsole(Color.Cyan, file.Name + " found in " + stopwatch.ElapsedMilliseconds + " ms");
            }
            else
            {
                _context.uiContext.WriteToConsole(Color.Red, "File not found. Lookup took " + stopwatch.ElapsedMilliseconds + " ms");
            }
        }

        public void FindRevFile()
        {
            var lookupService = new FileLookupService(_context.VirtualFiles);
            var address = new VirtualFileAddress(GameEnum.Revelation.ToString(), "Haven", "Gate", "010", "front");
            bool fileFound;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var file = lookupService.GetFile(out fileFound, address);
            stopwatch.Stop();
            if (fileFound)
            {
                _context.uiContext.WriteToConsole(Color.Cyan, file.Name + " found in " + stopwatch.ElapsedMilliseconds + " ms");
            }
            else
            {
                _context.uiContext.WriteToConsole(Color.Red, "File not found. Lookup took " + stopwatch.ElapsedMilliseconds + " ms");
            }
        }
    }
}
