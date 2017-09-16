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
            Mb4Start,
        }

        internal FileListing IndexM3AFile(string filePath)
        {
            List<FileMarker> markers = FindFileMarkers(filePath);
            return CreateListing(markers);
        }

        private List<FileMarker> FindFileMarkers(string filePath)
        {
            List<FileMarker> markers = new List<FileMarker>();


            int BUFFER_SIZE = 4096;
            byte[] buffer = new byte[BUFFER_SIZE];
            byte[] headerBuffer = new byte[3];
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int fileLength = (int)fileStream.Length;
                int bufferCount = fileLength / buffer.Length;

                int count = 0;
                int offset = 0;
                int returnedBufferSize = 0;
                int returnedHeaderBufferSize = 0;
                while (count < bufferCount)
                {
                    offset = count * BUFFER_SIZE;
                    fileStream.Seek(offset, SeekOrigin.Begin);
                    returnedBufferSize = fileStream.Read(buffer, 0, BUFFER_SIZE);
                    count++;

                    //check and handle end of file
                    if (returnedBufferSize < BUFFER_SIZE)
                    {
                    }

                    //search buffer for markers/headers
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        if (buffer[i] == jpgStart[0] || buffer[i] == binkStart[0])
                        {
                            // confirm it's actually a marker
                            var currentLocation = offset + i;
                            if (currentLocation + headerBuffer.Length > fileLength)
                                throw new Exception("Attempting to read beyond end of file");

                            fileStream.Seek(currentLocation, SeekOrigin.Begin);
                            fileStream.Read(headerBuffer, 0, headerBuffer.Length);

                            // determine type of marker
                            if (headerBuffer[0] == jpgStart[0])
                            {
                                if (headerBuffer[1] == jpgStart[1])
                                    markers.Add(new FileMarker(currentLocation, FileMarkerType.JpgStart));
                                else if (headerBuffer[1] == jpgEnd[1])
                                    markers.Add(new FileMarker(currentLocation, FileMarkerType.JpgEnd));
                            }
                            else if (headerBuffer[0] == binkStart[0])
                            {
                                if (headerBuffer[1] == binkStart[1])
                                    if (headerBuffer[2] == binkStart[2])
                                        markers.Add(new FileMarker(currentLocation, FileMarkerType.BinkStart));
                            }

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
                    if(marker.Type == FileMarkerType.JpgStart)
                    {
                        fileCount += 1;
                        listing.Add(new FileIndex(fileCount, fileCount.ToString("D4"), FileType.Bink, currentFile.Index, marker.Index -1));
                        currentFile = null;
                    }
                }
                else if (currentFile.Type == FileMarkerType.JpgStart)
                {
                    if (marker.Type == FileMarkerType.JpgEnd)
                    {
                        fileCount += 1;
                        listing.Add(new FileIndex(fileCount, fileCount.ToString("D4"), FileType.Jpg, currentFile.Index, marker.Index - 1));
                        currentFile = null;
                    }
                }

            }
            return listing;
        }

        internal FileListing IndexRevelationDataFile(string filePath)
        {
            byte[] fileData = ReadFile(filePath);
            throw new NotImplementedException();
        }

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }


    }
}
