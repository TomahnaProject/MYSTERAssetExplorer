using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYSTERAssetExplorer.Services
{
    public class VirtualFileSaveService
    {
        public void SaveFile(string filePath, string fileName, FileType type, byte[] data)
        {
            string extension = "";
            if (type == FileType.Jpg)
                extension = ".png";
            else if (type == FileType.Bink)
                extension = ".bik";

            if (!fileName.Contains(extension))
                fileName += extension;

            var savePath = Path.Combine(filePath, fileName);
            File.WriteAllBytes(savePath, data);
        }

        public string SaveFolder(string filePath, string folderName)
        {
            string path = "";
            if(Directory.Exists(filePath))
            {
                path = Path.Combine(filePath, folderName);
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}
