using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExileAndRevelationAssetExtractor.Core;
using System.IO;

namespace ExileAndRevelationAssetExtractor.Services
{
    public class FileExtractionService
    {
        internal void Extract(string _filePath, FileListing files, string folderPath)
        {
            var fileListing = files.GetList();
            foreach (var file in fileListing)
            {
                var data = ExtractFile(_filePath, file);
                SaveFile(file, data, folderPath);
            }
        }

        private byte[] ExtractFile(string dataFilePath, FileIndex file)
        {
            int bufferSize = file.End - file.Start;
            byte[] buffer = new byte[bufferSize];
            FileStream fileStream = new FileStream(dataFilePath, FileMode.Open, FileAccess.Read);
            try
            {
                    fileStream.Seek(file.Start, SeekOrigin.Begin);
                    fileStream.Read(buffer, 0, bufferSize);
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        private void SaveFile(FileIndex file, byte[] data, string extractionPath)
        {
            string extension = "";
            if (file.Type == FileType.Jpg)
                extension = ".jpg";
            else if (file.Type == FileType.Bink)
                extension = ".bik";

            var savePath = Path.Combine(extractionPath, file.Name + extension);
            File.WriteAllBytes(savePath, data);
        }
    }
}
