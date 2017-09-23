using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYSTERAssetExplorer.Core;
using System.IO;

namespace MYSTERAssetExplorer.Services
{
    public class M3AFileIndexingService : IFileIndexerService
    {
        public readonly byte[] jpgStart = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46 };
        public readonly byte[] jpgEnd = new byte[] { 0xFF, 0xD9 };
        public readonly byte[] binkStart = new byte[] { 0x42, 0x49, 0x4B };

        public class FileMarker
        {
            public FileMarkerType Type;
            public int Index;
            public FileMarker(int index, FileMarkerType type)
            {
                Type = type;
                Index = index;
            }
        }

        public enum FileMarkerType
        {
            JpgStart,
            JpgEnd,
            BinkStart,
            BinkEnd,
        }

        public VirtualFolder IndexFile(string filePath)
        {
            List<FileMarker> potentialMarkers = FilePotentialMarkers(filePath);
            List<FileMarker> markers = GetConfirmedMarkers(filePath, potentialMarkers);
            return CreateListing(markers, filePath);
        }

        private List<FileMarker> FilePotentialMarkers(string filePath)
        {
            List<FileMarker> markers = new List<FileMarker>();

            int BUFFER_SIZE = 4096;
            byte[] buffer = new byte[BUFFER_SIZE];
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int fileLength = (int)fileStream.Length;
                int bufferCount = fileLength / buffer.Length;

                int count = 0;
                int bufferOffset = 0;
                int returnedBufferSize = 0;
                int offset;
                while (count <= bufferCount)
                {
                    bufferOffset = count * BUFFER_SIZE;
                    fileStream.Seek(bufferOffset, SeekOrigin.Begin);
                    returnedBufferSize = fileStream.Read(buffer, 0, buffer.Length);
                    count++;

                    //check and handle end of file
                    if (returnedBufferSize < BUFFER_SIZE)
                    {
                        buffer = new byte[returnedBufferSize];
                        // need to manually do this again to get that last bit of the file
                        fileStream.Seek(bufferOffset, SeekOrigin.Begin);
                        fileStream.Read(buffer, 0, buffer.Length);
                    }

                    //search buffer for the start of markers/headers
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        offset = bufferOffset + i;

                        if (i < (buffer.Length-1))
                        {
                            if (buffer[i] == jpgStart[0])
                            {
                                if(buffer[i + 1] == jpgStart[1])
                                    markers.Add(new FileMarker(offset, FileMarkerType.JpgStart));
                                else if (buffer[i + 1] == jpgEnd[1])
                                    markers.Add(new FileMarker(offset, FileMarkerType.JpgEnd));
                            }
                        }
                        else
                        {
                            if (buffer[i] == jpgStart[0])
                                markers.Add(new FileMarker(offset, FileMarkerType.JpgStart));
                        }
                    }
                }
            }
            finally
            {
                fileStream.Close();
            }
            return markers;
        }

        private List<FileMarker> GetConfirmedMarkers(string filePath, List<FileMarker> potentialMarkers)
        {
            List<FileMarker> confirmedMarkers = new List<FileMarker>();
            int headerRegionSize = 64;
            byte[] headerRegion = new byte[headerRegionSize];

            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int fileLength = (int)fileStream.Length;
                int headerRegionReturnSize = 64;
                foreach (var marker in potentialMarkers)
                {
                    if(marker.Index < fileLength)
                    {
                        fileStream.Seek(marker.Index, SeekOrigin.Begin);
                        fileStream.Read(headerRegion, 0, headerRegion.Length);
                    }
                    else
                    {
                        fileStream.Seek(marker.Index, SeekOrigin.Begin);
                        // headerRegionReturnSize should always be at least 1
                        headerRegionReturnSize = fileStream.Read(headerRegion, 0, headerRegion.Length);
                    }

                    if (headerRegionReturnSize < jpgEnd.Length) // too small for jpg marker
                        continue;

                    if (headerRegion[0] == jpgStart[0])
                    {
                        if (headerRegion[1] == jpgStart[1])
                        {
                            if (headerRegionReturnSize < jpgStart.Length) // prefer to find a full header
                                continue;

                            if (headerRegion[2] == jpgStart[2])
                                if (headerRegion[3] == jpgStart[3])
                                    if (headerRegion[4] == jpgStart[4])
                                        if (headerRegion[5] == jpgStart[5])
                                            if (headerRegion[6] == jpgStart[6])
                                                confirmedMarkers.Add(new FileMarker(marker.Index, FileMarkerType.JpgStart));
                        }
                        else if (headerRegion[1] == jpgEnd[1])
                        {
                            confirmedMarkers.Add(new FileMarker(marker.Index, FileMarkerType.JpgEnd));
                        }
                    }
                }
            }
            finally
            {
                fileStream.Close();
            }

            return confirmedMarkers;
        }


        private VirtualFolder CreateListing(List<FileMarker> markers, string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var fileCount = 0;
            var folder = new VirtualFolder(fileName);
            FileMarker currentFile = null;

            foreach (var marker in markers)
            {
                if (currentFile == null)
                {
                    if (marker.Type == FileMarkerType.JpgStart || marker.Type == FileMarkerType.BinkStart)
                        currentFile = marker;
                }
                else if (currentFile.Type == FileMarkerType.JpgStart)
                {
                    if (marker.Type == FileMarkerType.JpgEnd)
                    {
                        fileCount += 1;
                        // add 2 to the ending index to include end of file bytes/marker
                        folder.Files.Add(new VirtualFileIndex(fileCount, fileCount.ToString("D4") + ".jpg", FileType.Jpg, currentFile.Index, (marker.Index - 1) + 2, filePath));
                        currentFile = null;
                    }
                }

            }
            return folder;
        }
    }
}
