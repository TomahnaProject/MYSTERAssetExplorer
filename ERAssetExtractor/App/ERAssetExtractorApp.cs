using ERAssetExtractor.Core;
using ERAssetExtractor.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERAssetExtractor.App
{
    public class ERAssetExtractorApp
    {
        string M3FileExtension = ".M3A";
        string M4FileExtension = ".M4B";

        string _filePath;
        string _extractionPath;

        ERAssetExtractorContext _context;

        public ERAssetExtractorApp(IUIContext uiContext)
        {
            _context = new ERAssetExtractorContext();
            _context.uiContext = uiContext;
            _context.files = new VirtualFileListing();
            _context.indexer = new VirtualFileIndexerService();
            _context.extractor = new VirtualFileExtractionService();
            _context.registryManager = new RegistryManager(uiContext);
            _context.workspaceModServ = new WorkspaceModificationService(uiContext);



        }

        public void OpenFile(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(filePath))
                throw new Exception("No such file " + filePath);

            if (Path.GetExtension(filePath).ToUpper() == M3FileExtension)
            {
                _context.files = _context.indexer.IndexM3AFile(_filePath);
            }
            else if (Path.GetExtension(filePath).ToUpper() == M4FileExtension)
            {
                _context.files = _context.indexer.IndexM4BDataFile(_filePath);
            }
            else
            {
                throw new Exception("NOT A VALID FILE FORMAT");
            }
        }

        public void ExtractFiles(string folderPath)
        {
            _extractionPath = folderPath;
            if (!Directory.Exists(folderPath))
                return;
            _context.extractor.Extract(_filePath, _context.files, _extractionPath);

        }

        public Workspace GetWorkspace()
        {
            return _context.workspaceModServ.Workspace;
        }

        public CubeMapImageSet GetCurrentSet() // hackiness
        {
            return _context.workspaceModServ.currentSet;
        }
        public void SetCurrentSet(CubeMapImageSet imageSet) // hackiness
        {
            _context.workspaceModServ.currentSet = imageSet;
        }

        public void SetWorkingDirectory(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                _context.uiContext.WriteToConsole(Color.Red, "The following path is invalid: \"" + path + "\"");
            _context.DataDirectory = Path.GetDirectoryName(path);

            var files = LoadDataFiles();

            //_context.workspaceModServ.SetWorkingDirectory(path);
        }

        public List<string> LoadDataFiles()
        {
            var directory = new DirectoryInfo(_context.DataDirectory);
            var masks = new[] { "*.m3a", "*.m4b" };
            var files = masks.SelectMany(directory.EnumerateFiles);
            return files.Select(x=>x.FullName).ToList();
        }

        public void SortDataFiles()
        {
            _context.workspaceModServ.SortDataFiles();
        }
    }
}
