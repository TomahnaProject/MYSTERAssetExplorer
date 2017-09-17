using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERAssetExtractor.Core;
using System.IO;

namespace ERAssetExtractor.Services
{
    public class FileExtractionService
    {
        internal void Extract(string _filePath, FileListing files, string folderPath)
        {
            var fileListing = files.GetList();
            var fileSaveService = new FileSaveService();
            foreach (var file in fileListing)
            {
                var data = ExtractFile(_filePath, file);
                fileSaveService.SaveFile(folderPath, file, data);
            }
        }

        private byte[] ExtractFile(string dataFilePath, FileIndex file)
        {
            int bufferSize = (file.End - file.Start) +1;
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
    }
}
