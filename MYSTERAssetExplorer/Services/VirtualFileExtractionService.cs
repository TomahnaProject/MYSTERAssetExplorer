using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYSTERAssetExplorer.Core;
using System.IO;

namespace MYSTERAssetExplorer.Services
{
    public class VirtualFileExtractionService
    {
        internal void Extract(string _filePath, VirtualFolder folder, string folderPath)
        {
            //var fileSaveService = new VirtualFileSaveService();
            //foreach (var file in folder.SubFolders)
            //{
            //    var data = CopyFile(_filePath, file);
            //    fileSaveService.SaveFile(folderPath, file, data);
            //}
        }

        public byte[] GetImageDataFromVirtualFileTiledImage(VirtualFileTiledImage tiledImage)
        {
            var stitcher = new TileImageStitcher(this);
            return stitcher.StitchTiledImage(tiledImage);
        }

        public byte[] GetImageDataFromVirtualFile(VirtualFileIndex file)
        {
            if (file.Type == FileType.Jpg)
            {
                var jpgData = CopyFile(file);
                return jpgData;
            }
            if (file.Type == FileType.Zap)
            {
                var zapData = CopyFile(file);
                var jpgData = ConversionService.ConvertFromZapToJpg(zapData);
                return jpgData;
            }
            return new byte[0];
        }

        public byte[] CopyFile(VirtualFileIndex file)
        {
            int bufferSize = (int)(file.End - file.Start) +1; // assuming that any given file never has more bytes that max int size
            byte[] buffer = new byte[bufferSize];
            FileStream fileStream = new FileStream(file.ContainerFilePath, FileMode.Open, FileAccess.Read);
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
