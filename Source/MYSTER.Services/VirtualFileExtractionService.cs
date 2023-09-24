using ArchiveSystem.VirtualFileSystem;
using M4ArchiveLib;
using MYSTER.Core;
using System.IO;

namespace MYSTER.Services
{
    public class VirtualFileExtractionService
    {
        public byte[] GetDataForVirtualFile(IVirtualFileEntry file)
        {
            if (file.FileData is VirtualFileDataInArchive)
            {
                return GetFileDataFromArchive(file.FileData as VirtualFileDataInArchive);
            }
            else if (file.FileData is VirtualFileTiledImage)
            {
                return GetImageDataForTiledImage(file.FileData as VirtualFileTiledImage);
            }
            else
            {
                return new byte[0];
            }
        }

        private byte[] GetImageDataForTiledImage(VirtualFileTiledImage tiledImage)
        {
            var stitcher = new TileImageStitcher(this);
            return stitcher.GetAssembledTiledImage(tiledImage);
        }

        private byte[] GetFileDataFromArchive(VirtualFileDataInArchive archivedFile)
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

        private byte[] CopyFileDataFromArchive(VirtualFileDataInArchive archiveIndex)
        {
            int bufferSize = (int)(archiveIndex.End - archiveIndex.Start) + 1; // assuming that any given file never has more bytes that max int size
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
