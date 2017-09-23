using MYSTERAssetExplorer.Core;
using MYSTERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.App
{
    public class AssetExplorerApp
    {
        string M3FileExtension = ".M3A";
        string M4FileExtension = ".M4B";

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

            foreach(var file in files)
            {
                _context.uiContext.WriteToConsole(Color.Green, "Found file " + file);
            }

            IndexFiles(files);

            var folders = new List<VirtualFolder>();
            var exileFolder = _context.VirtualFiles.SubFolders.FirstOrDefault(x => x.Name == "Exile");
            var revelationFolder = _context.VirtualFiles.SubFolders.FirstOrDefault(x => x.Name == "Revelation");
            if (exileFolder != null)
                folders.Add(exileFolder);
            if (revelationFolder != null)
                folders.Add(revelationFolder);

            _context.uiContext.PopulateFolders(folders);
            //_context.workspaceModServ.SetWorkingDirectory(path);
        }

        private void IndexFiles(List<string> files)
        {
            _context.uiContext.WriteToConsole(Color.Yellow, "Indexing Files...");
            VirtualFolder exileFolder = new VirtualFolder("Exile");
            VirtualFolder revelationFolder = new VirtualFolder("Revelation");
            _context.VirtualFiles = new VirtualFolder("/");
            IFileIndexerService indexingService;
            foreach (var file in files)
            {
                _context.uiContext.WriteToConsole(Color.Yellow, "Indexing " + Path.GetFileName(file));
                if (Path.GetExtension(file).ToUpper() == M3FileExtension)
                {
                    indexingService = new M3AFileIndexingService();
                    exileFolder.SubFolders.Add(indexingService.IndexFile(file));
                }
                else if (Path.GetExtension(file).ToUpper() == M4FileExtension)
                {
                    indexingService = new M4BFileIndexingService();
                    revelationFolder.SubFolders.Add(indexingService.IndexFile(file));
                }
                else
                {
                    // maybe write to console instead???
                    throw new Exception("NOT A VALID FILE FORMAT");
                }
            }
                _context.VirtualFiles.SubFolders.Add(exileFolder);
                _context.VirtualFiles.SubFolders.Add(revelationFolder);
            _context.uiContext.WriteToConsole(Color.Green, "Indexing Complete!");
        }

        public List<string> LoadDataFiles()
        {
            var directory = new DirectoryInfo(_context.DataDirectory);
            var masks = new[] { "*.m3a", "*.m4b" };
            var files = masks.SelectMany(directory.EnumerateFiles);
            return files.Select(x=>x.FullName).ToList();
        }
    }
}
