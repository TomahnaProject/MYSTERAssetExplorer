using ExileAndRevelationAssetExtractor.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExileAndRevelationAssetExtractor.Services
{
    public class FileSaveService
    {
        public void SaveFile(string filePath, FileIndex file, byte[] data)
        {
            string extension = "";
            if (file.Type == FileType.Jpg)
                extension = ".jpg";
            else if (file.Type == FileType.Bink)
                extension = ".bik";

            var savePath = Path.Combine(filePath, file.Name + extension);
            File.WriteAllBytes(savePath, data);
        }
    }
}
