using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4BFileReader
{
    // useful online forum thread for reference
    // https://forum.xentax.com/viewtopic.php?f=13&t=852&start=45
    public class M4BReader
    {
        public readonly byte[] UbiSoftHeader = new byte[] { 0x55, 0x42, 0x49, 0x5F, 0x42, 0x46, 0x5F, 0x53, 0x49, 0x47 };

        public void OpenM4B(string filePath)
        {
            var hasProperExtension = filePath.ToLower().Contains(".m4b");
            if (File.Exists(filePath) && hasProperExtension)
            {
                ReadM4BFile(filePath);
                //var rootFolder = ReadM4BFile(filePath);
                //PrintFolderContents(rootFolder);
            }
        }

        public void PrintFolderContents(VirtualFolder folder, int indentCount = 0)
        {
            string indents = "";
            for(int i=0; i<indentCount; i++)
            {
                indents += "\t";
            }
            Console.WriteLine("\r\n-------------------------");
            Console.WriteLine(string.Format("{0}{1}", indents, folder.Name));
            Console.WriteLine("-------------------------");
            foreach (var subFolder in folder.SubFolders)
            {
                PrintFolderContents(subFolder, indentCount + 1);
            }

            foreach(var file in folder.Files)
            {
                Console.WriteLine(string.Format("\r\n{0}{1}{2,-30}", indents, file.Name, "(s " + file.GetSize() + " o " + file.Start + ")"));
            }
        }

        public void ReadM4BFile(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                var totalFileSize = fileStream.Seek(0, SeekOrigin.End);
                ReadM4BFileData(fileStream, 0, totalFileSize);
            }
            finally
            {
                fileStream.Close();
            }
        }

        public void ReadM4BFileData(FileStream fileStream, long startIndex, long endIndex)
        {
            var totalHeaderSize = 0;
            if (HasM4BHeader(fileStream, 0, out totalHeaderSize))
            {
                ReadM4bBody(fileStream, totalHeaderSize, endIndex);
            }
        }

        private bool HasM4BHeader(FileStream fileStream, long startIndex, out int totalHeaderSize)
        {
            totalHeaderSize = 0;
            long index = startIndex;

            var headerSizeBuffer = new byte[sizeof(int)];
            fileStream.Seek(0, SeekOrigin.Begin);
            fileStream.Read(headerSizeBuffer, 0, headerSizeBuffer.Length);
            index += sizeof(int);

            var headerSize = BitConverter.ToInt32(headerSizeBuffer, 0);
            Console.WriteLine("Header Size: " + headerSize);

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
            if (first != 1) return false;


            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(spacer, 0, spacer.Length);
            index += spacer.Length;

            var second = BitConverter.ToInt32(spacer, 0);
            if (second != 0) return false;

            totalHeaderSize = headerSizeBuffer.Length + headerBuffer.Length + (spacer.Length * 2);
            return true;
        }

        private void ReadM4bBody(FileStream fileStream, long startIndex, long endIndex)
        {
            long index = startIndex;

            byte[] buffer = new byte[sizeof(byte)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(byte);

            var rootFolderCount = (int)buffer[0];
            Console.WriteLine("Root Folder Count: " + rootFolderCount);

            for (int i = 0; i < rootFolderCount; i++)
            {
                index = ReadFolder(fileStream, index);
            }
        }

        private long ReadFolder(FileStream fileStream, long startIndex)
        {
            long index = startIndex;

            var buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var folderNameSize = BitConverter.ToUInt32(buffer, 0);

            buffer = new byte[folderNameSize];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += buffer.Length;

            var folderName = Encoding.ASCII.GetString(buffer);

            buffer = new byte[sizeof(byte)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += buffer.Length;

            var subFolderCount = (int)buffer[0];
            Console.WriteLine("\r\n\r\n -------------------------\r\n + " + folderName);
            if (subFolderCount > 0)
                Console.WriteLine(subFolderCount + " folders");

            // ubi organized the data in such a way that folders contain either subfolders or files, but not both
            if (subFolderCount != 0)
            {
                index = IterateFolders(fileStream, index, subFolderCount);
            }
            else
            {
                index = IterateFiles(fileStream, index);
            }
            return index;
        }


        private long IterateFolders(FileStream fileStream, long startIndex, int folderCount)
        {
            long index = startIndex;

            for (int i = 0; i < folderCount; i++)
            {
                index = ReadFolder(fileStream, index);
            }

            var buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var fileCount = BitConverter.ToUInt32(buffer, 0);
            Debug.Assert(fileCount == 0); // should be zero, no folder has both children folders and files

            return index;
        }

        private long IterateFiles(FileStream fileStream, long startIndex)
        {
            long index = startIndex;

            var buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var fileCount = BitConverter.ToUInt32(buffer, 0);
            if (fileCount > 0)
                Console.WriteLine(fileCount + " files");

            for (int i = 0; i < fileCount; i++)
            {
                index = ReadFileInfo(fileStream, index);
            }
            return index;
        }

        private long ReadFileInfo(FileStream fileStream, long startIndex)
        {
            long index = startIndex;

            var buffer = new byte[sizeof(uint)];
            fileStream.Seek(index, SeekOrigin.Begin);
            fileStream.Read(buffer, 0, buffer.Length);
            index += sizeof(uint);

            var fileNameSize = BitConverter.ToUInt32(buffer, 0);

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
            Console.Write(string.Format("\r\n - {0}{1,-30}", FileName, "(s " + FileSize + " o " + FileOffset + ")"));
            return index;
        }
    }
}
