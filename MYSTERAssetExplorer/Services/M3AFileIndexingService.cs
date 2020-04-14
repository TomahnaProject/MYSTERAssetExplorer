using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MYSTERAssetExplorer.Core;
using MYSTERAssetExplorer.Utils;

namespace MYSTERAssetExplorer.Services
{
    public enum Myst3ResourceType
    {
        CubeFace = 0,
        WaterEffectMask = 1,
        LavaEffectMask = 2,
        MagneticEffectMask = 3,
        ShieldEffectMask = 4,
        SpotItem = 5,
        Frame = 6,
        RawData = 7,
        Movie = 8,
        StillMovie = 10,
        Text = 11,
        TextMetadata = 12,
        NumMetadata = 13,
        LocalizedSpotItem = 69,
        LocalizedFrame = 70,
        MultitrackMovie = 72,
        DialogMovie = 74
    }
    public enum M3CubeFace
    {
        None = 0,
        Back = 1,
        Bottom = 2,
        Front = 3,
        Left = 4,
        Right = 5,
        Top = 6,
    }
    public class SpotItemData
    {
        public uint U;
        public uint V;
    }
    public class Vector3
    {
        public float X;
        public float Y;
        public float Z;
    }
    public class VideoData
    {
        public Vector3 V1 = new Vector3();
        public Vector3 V2 = new Vector3();
        public int U;
        public int V;
        public int Width;
        public int Height;
    }
    public class M3ArchiveFileEntry
    {
        public string Folder = null;
        //public byte[] HeaderData = new byte[0];
        public UInt32 Offset;
        public UInt32 Size;
        public UInt16 MetaDataSize;
        public M3CubeFace CubeFace = M3CubeFace.None;
        public Myst3ResourceType Type = Myst3ResourceType.RawData;
        public byte[] MetaData = new byte[0];
        //public byte[] MiscData = new byte[0];
        public VideoData VideoData = new VideoData();
        public SpotItemData SpotItemData = new SpotItemData();
    }

    public class M3AFileIndexingService : IFileIndexerService
    {
        public IVirtualFolder IndexFile(string filePath)
        {
            IVirtualFolder builtFolder;
            var fileName = Path.GetFileName(filePath);
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                var totalFileSize = fileStream.Seek(0, SeekOrigin.End);
                builtFolder = ReadMyst3Archive(fileStream, fileName, 0, totalFileSize);
            }
            finally
            {
                fileStream.Close();
            }
            return builtFolder;
        }

        private IVirtualFolder ReadMyst3Archive(FileStream fileStream, string fileName, long fileStart, long fileEnd)
        {
            var header = ReadArchiveHeader(fileStream);
            //File.WriteAllBytes("E:\\test\\" + Path.GetFileName(fileStream.Name), header);

            bool containsSubFolders = false;
            containsSubFolders =
                fileName.ToLower().Contains(".m3r") ||
                fileName.ToLower().Contains(".m3o") ||
                fileName.ToLower().Contains(".m3u") ||
                fileName.ToLower().Contains(".m3t");

            var folder = CreateListingForArchive(fileStream.Name, fileEnd, header, containsSubFolders);
            return folder;

        }
        private byte[] ReadArchiveHeader(FileStream fileStream)
        {
            fileStream.Seek(0, SeekOrigin.Begin);
            UInt32 headerSize = fileStream.ReadUInt32LE(0);

            // first 4 bytes contains the header size
            // in reality the header is never going to be very large
            // but when encrypted it's value will appear gigantic
            // check if it has an enormous value
            // if that is the case, it's encrypted
            bool encrypted = headerSize > 1000000;

            byte[] headerBuffer = null;

            if (encrypted)
            {
                headerBuffer = DecryptArchiveHeader(fileStream);
            }
            else
            {
                headerBuffer = CopyHeader(fileStream, headerSize);
            }
            return headerBuffer;
        }

        private byte[] CopyHeader(FileStream fileStream, UInt32 headerLength)
        {
            var headerBuffer = new byte[headerLength];
            fileStream.Seek(0, SeekOrigin.Begin);
            fileStream.Read(headerBuffer, 0, headerBuffer.Length);
            return headerBuffer;
        }

        // this decryption code is a ported/modified version of code used in residualvm myst3 engine code
        // https://github.com/residualvm/residualvm/blob/master/engines/myst3/archive.cpp
        const UInt32 decryptionAddKey = 0x3C6EF35F; // 1013904223
        const UInt32 decryptionMultKey = 0x0019660D; // 1664525
        private byte[] DecryptArchiveHeader(FileStream fileStream)
        {
            fileStream.Seek(0, SeekOrigin.Begin);
            UInt32 encryptedHeaderSize = fileStream.ReadUInt32LE(0);
            UInt32 headerSize = (encryptedHeaderSize ^ decryptionAddKey);
            var fileEnd = fileStream.Seek(0, SeekOrigin.End);
            if (headerSize > fileEnd)
                throw new Exception("Header size is larger than file, something went wrong");

            var headerBuffer = CopyHeader(fileStream, headerSize * 4);

            //File.WriteAllBytes("E:\\test\\" + Path.GetFileName(fileStream.Name) + "_encrypted", headerBuffer);

            UInt32 currentKey = 0;
            byte[] copyBuffer = new byte[4];
            UInt32 value = 0;

            int offset = 0;
            for (uint i = 0; i < headerSize; i++)
            {
                offset = (int)i * 4;

                currentKey += decryptionAddKey;

                copyBuffer[0] = headerBuffer[offset];
                copyBuffer[1] = headerBuffer[offset + 1];
                copyBuffer[2] = headerBuffer[offset + 2];
                copyBuffer[3] = headerBuffer[offset + 3];
                value = BitConverter.ToUInt32(copyBuffer, 0);

                value = value ^ currentKey;
                value.CopyToByteArrayLE(headerBuffer, offset);

                currentKey *= decryptionMultKey;
            }
            return headerBuffer;
        }

        public List<M3ArchiveFileEntry> ExtractFileEntriesFromArchive(byte[] headerData, bool containsSubFolders = true)
        {
            List<M3ArchiveFileEntry> entries = new List<M3ArchiveFileEntry>();

            int headerIndex = sizeof(UInt32);
            int metaDataStartIndex;
            byte[] folderNameBytes;
            string folderName = "";
            M3ArchiveFileEntry entry;
            while (headerIndex + sizeof(UInt32) < headerData.Length)
            {
                if (containsSubFolders)
                {
                    folderNameBytes = headerData.Skip(headerIndex).Take(sizeof(UInt32)).ToArray();
                    folderName = Encoding.ASCII.GetString(folderNameBytes);
                    headerIndex += sizeof(UInt32);
                }

                // directoryIndex is stored as 24 bit int
                UInt16 part = BitConverter.ToUInt16(headerData, headerIndex);
                uint directoryIndex = (uint)(part | (headerData[headerIndex + 2] << 16));
                uint subItemCount = headerData[headerIndex + 3];
                headerIndex += sizeof(UInt32);

                for (int i = 0; i < subItemCount; i++)
                {
                    // READ VALUES
                    entry = new M3ArchiveFileEntry();
                    entry.Folder = folderName;
                    entry.Offset = BitConverter.ToUInt32(headerData, headerIndex);
                    headerIndex += sizeof(UInt32);
                    entry.Size = BitConverter.ToUInt32(headerData, headerIndex);
                    headerIndex += sizeof(UInt32);
                    entry.MetaDataSize = BitConverter.ToUInt16(headerData, headerIndex);
                    headerIndex += sizeof(UInt16);
                    entry.CubeFace = (M3CubeFace)headerData[headerIndex];
                    headerIndex += sizeof(byte);
                    entry.Type = (Myst3ResourceType)headerData[headerIndex];
                    headerIndex += sizeof(byte);

                    metaDataStartIndex = headerIndex;
                    headerIndex += (sizeof(UInt32) * entry.MetaDataSize);
                    entry.MetaData = new byte[sizeof(UInt32) * entry.MetaDataSize];
                    // some of the archives cause the following line to go out of bounds
                    // not sure what the problem is (this is coded ported from ResidualVM)
                    // it's needed for the game, but not for a program like this, so I'm commenting it out
                    //Array.Copy(headerData, metaDataStartIndex, entry.MetaData, 0, sizeof(UInt32) * entry.MetaDataSize);
                    ReadMetaData(entry);

                    entries.Add(entry);
                }
            }

            return entries;
        }

        private void ReadMetaData(M3ArchiveFileEntry entry)
        {
            // MAKE USE OF META DATA
            if (entry.MetaDataSize == 2 && (entry.Type == Myst3ResourceType.SpotItem || entry.Type == Myst3ResourceType.LocalizedSpotItem))
            {
                // create SpotItemData
                entry.SpotItemData.U = BitConverter.ToUInt32(entry.MetaData, 0);
                entry.SpotItemData.V = BitConverter.ToUInt32(entry.MetaData, sizeof(UInt32));
            }
            else if (entry.MetaDataSize == 10 && (entry.Type == Myst3ResourceType.Movie || entry.Type == Myst3ResourceType.MultitrackMovie))
            {
                // create VideoData
            }
            else if (entry.Type == Myst3ResourceType.NumMetadata || entry.Type == Myst3ResourceType.TextMetadata)
            {
                // copy metadata to something accessible to this item
            }
            else if (entry.MetaDataSize != 0)
            {
                //throw new Exception("Metadata not read for type " + resType +  " size: " + metaDataSize);
            }
        }

        private IVirtualFolder CreateListingForArchive(string filePath, long fileEnd, byte[] headerData, bool containsSubFolders = true)
        {
            var entries = ExtractFileEntriesFromArchive(headerData, containsSubFolders);

            var archiveFileName = Path.GetFileName(filePath);
            var rootFolder = new VirtualFolder(archiveFileName);
            VirtualFolder currentFolder = null;

            int nodeCount = 0;
            int imageCount = 1;
            int spotImageCount = 1;
            int videoCount = 1;

            foreach(var entry in entries)
            {
                string fileName = entry.Type.ToString();

                // TRANSFORM FILE TYPE
                var fileType = FileType.Unknown;
                if (entry.Type == Myst3ResourceType.CubeFace ||
                    entry.Type == Myst3ResourceType.Frame ||
                    entry.Type == Myst3ResourceType.LocalizedFrame ||
                    entry.Type == Myst3ResourceType.SpotItem ||
                    entry.Type == Myst3ResourceType.LocalizedSpotItem
                    )
                {
                    fileType = FileType.Jpg;
                }
                if (entry.Type == Myst3ResourceType.Movie ||
                    entry.Type == Myst3ResourceType.MultitrackMovie ||
                    entry.Type == Myst3ResourceType.DialogMovie ||
                    entry.Type == Myst3ResourceType.StillMovie)
                {
                    fileType = FileType.Bink;
                }
                if (entry.Type == Myst3ResourceType.RawData)
                {
                    // could be bitmap,
                    //could be archetype ascii text file
                    // could be xet file
                    fileType = FileType.Bmp;
                    // if it starts with BM, then it's a bmp
                    // if it starts with XET it's a xet
                    // if it starts with ASCII it's a text file
                }


                var fileContent = new VirtualFileDataInArchive(filePath, fileType, entry.Offset, entry.Offset + entry.Size);

                if (entry.Type == Myst3ResourceType.CubeFace)
                {
                    if (entry.CubeFace == M3CubeFace.Back) // Back is always first
                    {
                        nodeCount++;
                        spotImageCount = 1;
                    }
                    fileName += "_" + nodeCount.ToString().PadLeft(3, '0') + "_" + entry.CubeFace.ToString().ToLower();
                }
                if(fileType == FileType.Bink)
                {
                    fileName += "_" + videoCount.ToString().PadLeft(3, '0');
                    videoCount++;

                }
                if (fileType == FileType.Jpg && entry.Type != Myst3ResourceType.CubeFace)
                {
                    if(entry.Type == Myst3ResourceType.SpotItem || entry.Type == Myst3ResourceType.LocalizedSpotItem)
                    {
                        fileName = nodeCount.ToString().PadLeft(3, '0') + "_SpotItem_" + spotImageCount;
                        spotImageCount++;
                    }
                    else
                    {
                        fileName += "_" + imageCount.ToString().PadLeft(4, '0');
                        imageCount++;
                    }
                }

                // create the listing
                //var vFile = new VirtualFileEntry(entry.Offset + "_" + (entry.Offset + entry.Size) + "_" + entry.Type, fileContent);
                var vFile = new VirtualFileEntry(fileName, fileContent);
                if (containsSubFolders)
                {
                    if (!string.IsNullOrEmpty(entry.Folder))
                    {
                        if (rootFolder.SubFolders.Any(x => x.Name.ToUpper() == entry.Folder.ToUpper()))
                        {
                            currentFolder = rootFolder.SubFolders.FirstOrDefault(x => x.Name.ToUpper() == entry.Folder.ToUpper()) as VirtualFolder;
                        }
                        else
                        {
                            currentFolder = new VirtualFolder(entry.Folder.ToUpper());
                            rootFolder.SubFolders.Add(currentFolder);
                        }
                        currentFolder.Files.Add(vFile);
                    }
                    else
                    {
                        rootFolder.Files.Add(vFile);
                    }
                }
                else
                {
                    rootFolder.Files.Add(vFile);
                }
            }

            return rootFolder;
        }
    }
}
