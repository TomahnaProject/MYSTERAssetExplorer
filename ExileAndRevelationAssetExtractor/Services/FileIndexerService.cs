using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExileAndRevelationAssetExtractor.Core;
using System.IO;

namespace ExileAndRevelationAssetExtractor.Services
{
    public class FileIndexerService
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
            Mb4Start,
        }

        internal FileListing IndexM3AFile(string filePath)
        {
            List<FileMarker> potentialMarkers = FilePotentialMarkers(filePath);
            List<FileMarker> markers = GetConfirmedMarkers(filePath, potentialMarkers);
            return CreateListing(markers);
        }

        internal FileListing IndexM4BDataFile(string filePath)
        {
            List<FileMarker> potentialMarkers = FilePotentialMarkers(filePath);
            List<FileMarker> markers = GetConfirmedMarkers(filePath, potentialMarkers);
            return CreateListing(markers);
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
                int offset = 0;
                int returnedBufferSize = 0;
                while (count < bufferCount)
                {
                    offset = count * BUFFER_SIZE;
                    fileStream.Seek(offset, SeekOrigin.Begin);
                    returnedBufferSize = fileStream.Read(buffer, 0, BUFFER_SIZE);
                    count++;

                    //check and handle end of file
                    if (returnedBufferSize < BUFFER_SIZE)
                    {
                        buffer = new byte[returnedBufferSize];
                    }

                    //search buffer for the start of markers/headers
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        if (buffer[i] == jpgStart[0])
                            markers.Add(new FileMarker(offset + i, FileMarkerType.JpgStart));
                        else if(buffer[i] == binkStart[0])
                            markers.Add(new FileMarker(offset + i, FileMarkerType.BinkStart));
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


                    if (headerRegion[0] == jpgStart[0])
                    {
                        if (headerRegionReturnSize < 2) // too small for jpg stuff
                            continue;

                        if (headerRegion[1] == jpgStart[1])
                        {
                            if (headerRegion[2] == jpgStart[2])
                                confirmedMarkers.Add(new FileMarker(marker.Index, FileMarkerType.JpgStart));
                        }
                        else if (headerRegion[1] == jpgEnd[1])
                        {
                            confirmedMarkers.Add(new FileMarker(marker.Index, FileMarkerType.JpgEnd));
                        }
                    }
                    else if (headerRegion[0] == binkStart[0])
                    {
                        if (headerRegionReturnSize < 8) // too small for bink
                            continue;

                        var text = Encoding.ASCII.GetString(headerRegion);
                        if (headerRegion[1] == binkStart[1])
                            if (headerRegion[2] == binkStart[2])
                            {
                                byte[] binkFileSizeBytes = new byte[]
                                {
                                    headerRegion[4],
                                    headerRegion[5],
                                    headerRegion[6],
                                    headerRegion[7]
                                };
                                // the size from the header does not include first 8 bytes
                                var rawFileSize = BitConverter.ToInt32(binkFileSizeBytes, 0);
                                //var divided = rawFileSize / 2;
                                var binkFileSize = rawFileSize + 8;

                                var start = marker.Index;
                                var end = marker.Index + binkFileSize;

                                if(end < 0)
                                {
                                    throw new Exception("NEGATIVE BINK FILE END");
                                }

                                confirmedMarkers.Add(new FileMarker(start, FileMarkerType.BinkStart));
                                confirmedMarkers.Add(new FileMarker(end + binkFileSize, FileMarkerType.BinkEnd));

                                // check for markers between these two indexes
                                List<FileMarker> invalid = potentialMarkers.Where(x => (start < x.Index && x.Index < end)).ToList();
                                foreach(FileMarker invalidMarker in invalid)
                                {
                                    invalidMarker.Index = 0;
                                }
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


        private FileListing CreateListing(List<FileMarker> markers)
        {
            var fileCount = 0;
            var listing = new FileListing();
            FileMarker currentFile = null;

            foreach (var marker in markers)
            {
                if (currentFile == null)
                {
                    if (marker.Type == FileMarkerType.JpgStart || marker.Type == FileMarkerType.BinkStart)
                        currentFile = marker;
                }
                else if(currentFile.Type == FileMarkerType.BinkStart)
                {
                    if(marker.Type == FileMarkerType.BinkEnd)
                    {
                        fileCount += 1;

                        listing.Add(new FileIndex(
                            fileCount, fileCount.ToString("D4"), FileType.Bink,
                            currentFile.Index, marker.Index));
                        currentFile = null;
                    }
                }
                else if (currentFile.Type == FileMarkerType.JpgStart)
                {
                    if (marker.Type == FileMarkerType.JpgEnd)
                    {
                        fileCount += 1;
                        // add 2 to the ending index to include end of file bytes/marker
                        listing.Add(new FileIndex(fileCount, fileCount.ToString("D4"), FileType.Jpg, currentFile.Index, (marker.Index - 1) + 2));
                        currentFile = null;
                    }
                }

            }
            return listing;
        }
    }
}
