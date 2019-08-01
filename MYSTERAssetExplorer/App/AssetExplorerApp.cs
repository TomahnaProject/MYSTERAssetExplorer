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
        public NodeViewerApp NodeApp;

        public Action<Color, string> WriteToConsole { get; set; }
        public Action<List<IVirtualFile>> ListFiles { get; set; }
        public Action<List<IVirtualFolder>> PopulateFolders { get; set; }

        public AssetExplorerApp()
        {
            _context = new AssetExplorerContext();
            _context.CacheDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IndexCache");
            if (!Directory.Exists(_context.CacheDirectory))
                Directory.CreateDirectory(_context.CacheDirectory);

            _context.CacheService = new CacheSerializationService();
            _context.VirtualFiles = new VirtualFolder("/");

        }

        public void LaunchNodeViewer()
        {
            NodeApp.Launch();
        }

        public void SetDataDirectory(string path)
        {
            var dir = Path.GetDirectoryName(path);
            WriteToConsole(Color.Orange, "Opening Folder " + dir);

            if (!Directory.Exists(dir))
                WriteToConsole(Color.Red, "The following path is invalid: \"" + dir + "\"");
            _context.DataDirectory = dir;

            var files = LoadDataFiles();

            foreach (var file in files)
            {
                WriteToConsole(Color.Green, "Found file " + file);
            }

            IndexAndShowFiles(files);
        }

        private void IndexAndShowFiles(List<string> filePaths)
        {
            WriteToConsole(Color.Orange, "Beginning Indexing Thread");

            var indexThread = new Thread(() =>
            {
                var rootFolder = IndexFiles(filePaths, WriteToConsole);
                IndexingCompleted(rootFolder);
            });
            indexThread.Start();
        }

        private void IndexingCompleted(VirtualFolder rootFolder)
        {
            WriteToConsole(Color.Green, "Indexing Complete!");
            _context.VirtualFiles = rootFolder;

            InitializeFolders();
        }

        private void InitializeFolders()
        {
            var folders = new List<IVirtualFolder>();
            var exileFolder = _context.VirtualFiles.SubFolders.FirstOrDefault(x => x.Name == "Exile");
            var revelationFolder = _context.VirtualFiles.SubFolders.FirstOrDefault(x => x.Name == "Revelation");
            if (exileFolder != null)
                folders.Add(exileFolder);
            if (revelationFolder != null)
                folders.Add(revelationFolder);

            PopulateFolders(folders);
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
                var filePath = revFiles[i];
                var fileName = Path.GetFileName(filePath);
                var cacheFileName = fileName.Replace(M4B_FileExtension, ".index");

                if (_context.CacheDirectory.Contains(cacheFileName))
                {
                    // check for a cached copy so indexing only needs to be done the first time a file is loaded
                    consoleWrite(Color.Yellow, "Loading cached index for " + fileName);
                    var cacheText = File.ReadAllText(Path.Combine(_context.CacheDirectory, cacheFileName));
                    IVirtualFolder indexedFile = _context.CacheService.DeserializeIndexedFolder(cacheText);
                    revelationFolder.SubFolders.Add(indexedFile);
                }
                else
                {
                    var threadAccessibleIndex = i;
                    consoleWrite(Color.Yellow, "Indexing " + fileName);
                    rWatch.Reset(); rWatch.Start();
                    //var fileThread = new Thread(() =>
                    //{
                        IVirtualFolder indexedFile = revIndexer.IndexFile(filePath);
                        revelationFolder.SubFolders.Add(indexedFile);
                        revFinished[threadAccessibleIndex] = true;
                        rWatch.Stop();
                        consoleWrite(Color.Green, fileName + " Indexed in " + rWatch.ElapsedMilliseconds + "ms");
                        var serializedIndex = _context.CacheService.SerializeIndexedFolder(indexedFile as VirtualFolder);
                        //File.WriteAllText(Path.Combine(_context.CacheDirectory, ""),serializedIndex);
                    //});
                    //fileThread.Start();
                }
            }
            for (int i = 0; i < exileFiles.Count(); i++)
            {
                var fileName = Path.GetFileName(exileFiles[i]);
                var cacheFileName = fileName.Replace(M3A_FileExtension, ".index");
                if (_context.CacheDirectory.Contains(cacheFileName))
                {
                    // check for a cached copy so indexing only needs to be done the first time a file is loaded
                    consoleWrite(Color.Yellow, "Loading cached index for " + fileName);
                    var cacheText = File.ReadAllText(Path.Combine(_context.CacheDirectory, cacheFileName));
                    IVirtualFolder indexedFile = _context.CacheService.DeserializeIndexedFolder(cacheText);
                    exileFolder.SubFolders.Add(indexedFile);
                }
                else
                {
                    var threadAccessibleIndex = i;
                    consoleWrite(Color.Yellow, "Indexing " + fileName);
                    eWatch.Reset(); eWatch.Start();
                    var fileThread = new Thread(() =>
                    {
                        IVirtualFolder indexedFile = exileIndexer.IndexFile(exileFiles[threadAccessibleIndex]);
                        exileFolder.SubFolders.Add(indexedFile);
                        exileFinished[threadAccessibleIndex] = true;
                        eWatch.Stop();
                        consoleWrite(Color.Green, fileName + " Indexed in " + eWatch.ElapsedMilliseconds + "ms");
                    });
                    fileThread.Start();
                }
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
                WriteToConsole(Color.LightBlue, "Extracting " + file.Name);
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
                WriteToConsole(Color.LightBlue, "Extracting " + file.Name);
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
                WriteToConsole(Color.Cyan, file.Name + " found in " + stopwatch.ElapsedMilliseconds + " ms");
            }
            else
            {
                WriteToConsole(Color.Red, "File not found. Lookup took " + stopwatch.ElapsedMilliseconds + " ms");
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
                WriteToConsole(Color.Cyan, file.Name + " found in " + stopwatch.ElapsedMilliseconds + " ms");
            }
            else
            {
                WriteToConsole(Color.Red, "File not found. Lookup took " + stopwatch.ElapsedMilliseconds + " ms");
            }
        }

        internal void SendImagesToNodeViewer(string game, string scene, string zone, List<IVirtualFile> files)
        {
            NodeApp.ReceiveImages(game, scene, zone, files);
        }
    }
}
