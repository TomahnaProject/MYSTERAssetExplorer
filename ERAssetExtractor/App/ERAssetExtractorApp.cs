﻿using ERAssetExtractor.Core;
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

            //SaveRegistryFiles();
            LoadRegistryFiles();
        }

        const string templateRegistryXML = @"<AssetRegistry><Nodes /></AssetRegistry>";

        const string regDir = "Registry";
        string exileRegistryFilePath = Path.Combine(regDir, "ExileAssetRegistry.xml");
        string revelationRegistryFilePath = Path.Combine(regDir, "RevelationAssetRegistry.xml");

        private void LoadRegistryFiles()
        {
            if (!Directory.Exists(regDir))
                Directory.CreateDirectory(regDir);

            var exileRegistryText = File.ReadAllText(exileRegistryFilePath);
            if (string.IsNullOrEmpty(exileRegistryText))
                File.WriteAllText(exileRegistryFilePath, templateRegistryXML);

            var revalationRegistryText = File.ReadAllText(revelationRegistryFilePath);
            if (string.IsNullOrEmpty(revalationRegistryText))
                File.WriteAllText(revelationRegistryFilePath, templateRegistryXML);

            var serializationService = new AssetRegistrySerializationService();
            var exileRegistry = serializationService.DeserializeRegistry(exileRegistryText);
            var revelationRegistry = serializationService.DeserializeRegistry(revalationRegistryText);

            _context.registryManager.Registries.Exile = exileRegistry;
            _context.registryManager.Registries.Revelation = revelationRegistry;

            _context.registryManager.RegenTreeView();
        }

        private void SaveRegistryFiles()
        {
            var serializer = new AssetRegistrySerializationService();
            var exileRegistry = serializer.SerializeRegistry(_context.registryManager.Registries.Exile);
            var revelationRegistry = serializer.SerializeRegistry(_context.registryManager.Registries.Revelation);

            File.WriteAllText(exileRegistryFilePath, exileRegistry);
            File.WriteAllText(revelationRegistryFilePath, revelationRegistry);
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

        //public void SortDataFiles()
        //{
        //    _context.workspaceModServ.SortDataFiles();
        //}
    }
}
