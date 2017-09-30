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
        public byte[] GetDataForVirtualFile(IVirtualFile file)
        {
            if(file.ContentDetails is ArchiveIndex)
            {
                return GetFileDataFromArchive(file.ContentDetails as ArchiveIndex);
            }
            else if(file.ContentDetails is TiledImage)
            {
                return GetImageDataForTiledImage(file.ContentDetails as TiledImage);
            }
            else
            {
                return new byte[0];
            }
        }

        private byte[] GetImageDataForTiledImage(TiledImage tiledImage)
        {
            var stitcher = new TileImageStitcher(this);
            return stitcher.GetAssembledTiledImage(tiledImage);
        }

        private byte[] GetFileDataFromArchive(ArchiveIndex archivedFile)
        {
            if (archivedFile.Type == FileType.Zap)
            {
                var zapData = CopyFileDataFromArchive(archivedFile);
                var jpgData = ConversionService.ConvertFromZapToJpg(zapData);
                return jpgData;
            }
            else
            {
                var fileData = CopyFileDataFromArchive(archivedFile);
                return fileData;
            }
        }

        private byte[] CopyFileDataFromArchive(ArchiveIndex archiveIndex)
        {
            int bufferSize = (int)(archiveIndex.End - archiveIndex.Start) +1; // assuming that any given file never has more bytes that max int size
            byte[] buffer = new byte[bufferSize];
            FileStream fileStream = new FileStream(archiveIndex.ArchiveFilePath, FileMode.Open, FileAccess.Read);
            try
            {
                    fileStream.Seek(archiveIndex.Start, SeekOrigin.Begin);
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
