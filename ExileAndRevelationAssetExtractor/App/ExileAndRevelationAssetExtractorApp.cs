using ExileAndRevelationAssetExtractor.Core;
using ExileAndRevelationAssetExtractor.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExileAndRevelationAssetExtractor.App
{
    public class ExileAndRevelationAssetExtractorApp
    {
        string M3FileExtension = ".M3A";
        string M4FileExtension = ".M4B";

        

        FileListing files = new FileListing();
        FileIndexerService indexer = new FileIndexerService();
        FileExtractionService extractor = new FileExtractionService();

        string _filePath;
        string _extractionPath;

        public void OpenFile(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(filePath))
                throw new Exception("No such file " + filePath);

            if(Path.GetExtension(filePath).ToUpper() == M3FileExtension)
            {
                files = indexer.IndexM3AFile(_filePath);
            }
            else if (Path.GetExtension(filePath).ToUpper() == M4FileExtension)
            {
                files = indexer.IndexM4BDataFile(_filePath);
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
            extractor.Extract(_filePath, files, _extractionPath);

        }
    }
}
