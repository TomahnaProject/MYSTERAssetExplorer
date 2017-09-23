using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.Services
{
    public class M4BFileIndexingService : IFileIndexerService
    {
        // useful online forum thread for reference
        // https://forum.xentax.com/viewtopic.php?f=13&t=852&start=45

        public readonly byte[] UbiSoftHeader = new byte[] { 0x55, 0x42, 0x49, 0x5F, 0x42, 0x46, 0x5F, 0x53, 0x49, 0x47 };

        public VirtualFolder IndexFile(string filePath)
        {
            VirtualFolder builtFolder;
            var fileName = Path.GetFileName(filePath);
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                var totalFileSize = fileStream.Seek(0, SeekOrigin.End);
                builtFolder = ReadM4BFileData(fileStream, fileName, 0, totalFileSize);
            }
            finally
            {
                fileStream.Close();
            }
            return builtFolder;
        }

        // used recursively to read nested m4b files
        public VirtualFolder ReadM4BFileData(FileStream fileStream, string fileName, long fileStart, long fileEnd)
        {
            if (fileName == "common.m4b" || fileName == "shared.m4b")
            {
                return null; // common/shared have some kind of special format, and can't be read like the other m4b
            }
            var totalHeaderSize = 0;
            if (HasM4BHeader(fileStream, fileStart, out totalHeaderSize))
            {
                try
                {
                    return ReadM4bBody(fileStream, fileName, fileStart, fileEnd, fileStart + totalHeaderSize);
                }
                catch (Exception ex)
                {
                    // some m4b (example: w1z04n115.m4b) have unusual formats that cause trouble, so we need to catch the exceptions they throw
                    return null;
                }
            }
            else
            {
                throw new Exception("Not an m4b file");
            }
        }

        private bool HasM4BHeader(FileStream fileStream, long startIndex, out int totalHeaderSize)
        {
            totalHeaderSize = 0;
            long index = startIndex;

            var headerSizeBuffer = new byte[sizeof(int)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(headerSizeBuffer, 0, headerSizeBuffer.Length);
            index += sizeof(int);

            var headerSize = BitConverter.ToInt32(headerSizeBuffer, 0);

            if(headerSize > 512)
            {
                throw new Exception("Header Too Large");
            }

            var headerBuffer = new byte[headerSize];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(headerBuffer, 0, headerBuffer.Length);
            index += headerBuffer.Length;

            if (!headerBuffer.Take(10).SequenceEqual(UbiSoftHeader))
                return false;

            var spacer = new byte[4];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(spacer, 0, spacer.Length);
            index += spacer.Length;

            var first = BitConverter.ToInt32(spacer, 0);
            if (first != 1)
                return false;


            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(spacer, 0, spacer.Length);
            index += spacer.Length;

            var second = BitConverter.ToInt32(spacer, 0);
            if (second != 0)
                return false;

            totalHeaderSize = headerSizeBuffer.Length + headerBuffer.Length + (spacer.Length * 2);
            return true;
        }

        private VirtualFolder ReadM4bBody(FileStream fileStream, string fileName, long fileStart, long fileEnd, long startIndex)
        {
            long index = startIndex;

            byte[] buffer = new byte[sizeof(byte)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(byte);

            var rootFolderCount = (int)buffer[0];

            var folder = new VirtualFolder(fileName);

            for (int i = 0; i < rootFolderCount; i++)
            {
                index = ReadFolder(folder, fileStream, fileStart, index);
            }
            return folder;
        }

        private long ReadFolder(VirtualFolder parentFolder, FileStream fileStream, long fileStart, long startIndex)
        {
            long index = startIndex;

            var buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var folderNameSize = BitConverter.ToUInt32(buffer, 0);

            if (folderNameSize > 512)
            {
                throw new Exception("FolderNameSize Too Big");
            }

            buffer = new byte[folderNameSize];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += buffer.Length;

            var folderName = Encoding.ASCII.GetString(buffer);
            var thisFolder = new VirtualFolder(folderName.ToLower().TrimEnd(new char[1] { '\0' }));

            buffer = new byte[sizeof(byte)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += buffer.Length;

            var subFolderCount = (int)buffer[0];

            // ubi organized the data in such a way that folders contain either subfolders or files, but not both
            if (subFolderCount != 0)
            {
                index = IterateFolders(thisFolder, fileStream, fileStart, index, subFolderCount);
            }
            else
            {
                index = IterateFiles(thisFolder, fileStream, fileStart, index);
            }
            parentFolder.SubFolders.Add(thisFolder);
            return index;
        }


        private long IterateFolders(VirtualFolder parentFolder, FileStream fileStream, long fileStart, long startIndex, int folderCount)
        {
            long index = startIndex;

            for (int i = 0; i < folderCount; i++)
            {
                index = ReadFolder(parentFolder, fileStream, fileStart, index);
            }

            var buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var fileCount = BitConverter.ToUInt32(buffer, 0);

            // fileCount SHOULD be zero, ASSUMING no folder has both children folders and files
            // which is apparently NOT the case, there ARE cases where there is an actual count here
            // and that there may be rare cases of a file and folder living in the same parent folder
            //Debug.Assert(fileCount == 0);

            return index;
        }

        private long IterateFiles(VirtualFolder parentFolder, FileStream fileStream, long fileStart, long startIndex)
        {
            long index = startIndex;

            var buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var fileCount = BitConverter.ToUInt32(buffer, 0);

            for (int i = 0; i < fileCount; i++)
            {
                index = ReadFileInfo(parentFolder, fileStream, fileStart, index);
            }
            return index;
        }

        private long ReadFileInfo(VirtualFolder parentFolder, FileStream fileStream, long fileStart, long startIndex)
        {
            long index = startIndex;

            var buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var fileNameSize = BitConverter.ToUInt32(buffer, 0);
            
            if(fileNameSize > 512)
            {
                throw new Exception("FileNameSize Too Big");
            }

            buffer = new byte[fileNameSize];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += buffer.Length;

            var FileName = Encoding.ASCII.GetString(buffer);

            buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var FileSize = BitConverter.ToUInt32(buffer, 0);

            buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var FileOffset = BitConverter.ToUInt32(buffer, 0);

            var fileType = FileType.Unknown;
            var fileNameLowercase = FileName.TrimEnd(new char[1] { '\0' }).ToLower();
            if (fileNameLowercase.EndsWith(".jpg"))
                fileType = FileType.Jpg;
            else if (fileNameLowercase.EndsWith(".zap"))
                fileType = FileType.Zap;
            else if (fileNameLowercase.EndsWith(".m4b"))
                fileType = FileType.M4B;
            else if (fileNameLowercase.EndsWith(".bik"))
                fileType = FileType.Bink;
            else if (fileNameLowercase.EndsWith(".bin"))
                fileType = FileType.Binary;
            else
                fileType = FileType.Unknown;

            if(fileType == FileType.M4B)
            {
                var folder = ReadM4BFileData(fileStream, fileNameLowercase, fileStart + FileOffset, FileOffset + FileSize);
                parentFolder.SubFolders.Add(folder);
            }
            else
            {
                var thisFile = new VirtualFileIndex(0, fileNameLowercase, fileType, FileOffset, FileOffset + FileSize, fileStream.Name);
                parentFolder.Files.Add(thisFile);
            }
            return index;
        }
    }
}
