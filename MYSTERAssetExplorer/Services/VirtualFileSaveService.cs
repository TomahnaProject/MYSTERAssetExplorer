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
        public void SaveFile(string filePath, VirtualFileIndex file, byte[] data)
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
