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
        public static readonly byte[] JPG_HEADER = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46 };
        public static readonly byte[] JPG_FOOTER = new byte[] { 0xFF, 0xD9 };
        public static readonly byte[] BINK_HEADER = new byte[] { 0x42, 0x49, 0x4B, 0x69 };

        private static List<FileIdentifier> FileIdentifiers = new List<FileIdentifier>()
        {
            new FileIdentifier(M3AFileType.Jpg, FileBoundaryType.Start, JPG_HEADER),
            new FileIdentifier(M3AFileType.Jpg, FileBoundaryType.End, JPG_FOOTER),
            new FileIdentifier(M3AFileType.Bink, FileBoundaryType.Start, BINK_HEADER),
        };

        public class FileIdentifier
        {
            public M3AFileType FileType { get; }
            public FileBoundaryType Boundary { get; }
            public byte[] FilePattern { get; }

            public FileIdentifier(M3AFileType fileType, FileBoundaryType boundary, byte[] filePattern)
            {
                FileType = fileType;
                Boundary = boundary;
                FilePattern = filePattern;
            }
        }

        public enum M3AFileType
        {
            Unknown,
            Jpg,
            Bink
        }

        public enum FileBoundaryType
        {
            Start,
            End
        }

        public class FileMarker
        {
            public M3AFileType Type;
            public uint BeginOffset;
            public uint EndOffset;
        }

        public IVirtualFolder IndexFile(string filePath)
        {
            List<FileMarker> markers = GetMarkers(filePath);
            return CreateListing(markers, filePath);
        }

        private List<FileMarker> GetMarkers(string filePath)
        {
            List<FileMarker> markers = new List<FileMarker>();

            markers = ScanThroughFile(filePath);

            return markers;
        }

        private class FileIdentifierMatch
        {
            public FileIdentifier Identifier;
            public uint FileOffset;
            public byte[] AdditionalData;
        }

        private List<FileIdentifierMatch> FindFileIdentifiersInBufferBoundary(byte[] previousBuffer, byte[] currentBuffer, uint fileOffset)
        {
            List<FileIdentifierMatch> results = new List<FileIdentifierMatch>();

            byte[] boundary = new byte[previousBuffer.Length + currentBuffer.Length];
            previousBuffer.CopyTo(boundary, 0);
            currentBuffer.CopyTo(boundary, previousBuffer.Length);
            int fidLength = 0;
            foreach (var fid in FileIdentifiers)
            {
                fidLength = fid.FilePattern.Length;
                for (uint i = (uint)(previousBuffer.Length - fidLength + 1); i < previousBuffer.Length; i++)
                {
                    if (EqualsPatternAtPosition(boundary, fid.FilePattern, i))
                    {
                        byte[] additionalData = null;
                        if (fid.FileType == M3AFileType.Bink)
                        {
                            additionalData = boundary.Skip((int)i).ToArray();
                        }
                        results.Add(new FileIdentifierMatch() { Identifier = fid, FileOffset = (fileOffset - i), AdditionalData = additionalData});
                    }
                }
            }
            return results;
        }


        private List<FileIdentifierMatch> FindFileIdentifiersInBuffer(byte[] data, uint fileOffset)
        {
            List<FileIdentifierMatch> results = new List<FileIdentifierMatch>();

            for (uint i = 0; i < data.Length; i++)
            {
                foreach (var fid in FileIdentifiers)
                {
                    if (EqualsPatternAtPosition(data, fid.FilePattern, i))
                    {
                        byte[] additionalData = null;
                        if (fid.FileType == M3AFileType.Bink)
                        {
                            additionalData = data.Skip((int)i).ToArray();
                        }
                        results.Add(new FileIdentifierMatch() { Identifier = fid, FileOffset = fileOffset + i, AdditionalData = additionalData });
                    }
                }
            }
            return results;
        }
        
        /*
        randdata

        jpgheader
        jpgdata
        jpgfooter

        binkheader(filesize)
        binkdata

        jpgheader
        jpgdata
        jpgfooter

        randdata

        binkheader(filesize)
        binkdata

        randdata
        */

        private class FileMarkerMachine
        {
            List<FileMarker> markers = new List<FileMarker>();
            FileMarker currentFile = null;

            public void AddFileIdentifierMatch(FileIdentifierMatch match)
            {
                if (currentFile == null)
                {
                    // the scanner is proceeding to the next file
                    if (match.Identifier.Boundary == FileBoundaryType.Start)
                    {
                        // check if data leading up to this file was an adjacent file, or a gap
                        var previousFile = markers.LastOrDefault();
                        uint gapStart = 0;
                        uint gapEnd = 0;
                        bool precededByGap = false;

                        if (previousFile != null)
                        {
                            if (previousFile.EndOffset != (match.FileOffset - 1))
                            {
                                precededByGap = true;
                                gapStart = previousFile.EndOffset + 1;
                                gapEnd = match.FileOffset - 1;
                            }
                        }
                        else
                        {
                            if (0 < match.FileOffset)
                            {
                                // bunch of binary stuff at beginning of file
                                precededByGap = true;
                                gapStart = 0;
                                gapEnd = match.FileOffset - 1;
                            }
                        }

                        if(precededByGap)
                        {
                            var gap = new FileMarker();
                            gap.Type = M3AFileType.Unknown;
                            gap.BeginOffset = gapStart;
                            gap.EndOffset = gapEnd;
                            markers.Add(gap);
                        }

                        // proceed to open filemarker to enclose the oncoming file
                        currentFile = new FileMarker();
                        currentFile.Type = match.Identifier.FileType;
                        currentFile.BeginOffset = match.FileOffset;

                        if (currentFile.Type == M3AFileType.Bink)
                        {
                            // read header and mark end of bink file
                            uint length = FindEndOffsetOfBinkFile(match.AdditionalData);
                            currentFile.EndOffset = match.FileOffset + length - 1; // bink length!
                            markers.Add(currentFile);
                            currentFile = null;
                        }
                    }
                }
                else
                {
                    // the scanner is inside a file, be on look out for end of file
                    if (match.Identifier.Boundary == FileBoundaryType.End)
                    {
                        if (currentFile.Type == M3AFileType.Jpg)
                        {
                            currentFile.EndOffset = match.FileOffset + (uint)match.Identifier.FilePattern.Length - 1;
                            markers.Add(currentFile);
                            currentFile = null;
                        }
                    }
                }
            }

            public void EndOfFile(uint fileLength)
            {
                if (currentFile != null)
                    throw new Exception("Error: expected end for jpg or bink file");
                var previousFile = markers.Last();
                if(previousFile.EndOffset < fileLength)
                {
                    var gap = new FileMarker();
                    gap.Type = M3AFileType.Unknown;
                    gap.BeginOffset = previousFile.EndOffset;
                    gap.EndOffset = fileLength;
                    markers.Add(gap);
                }

                foreach (var marker in markers)
                {
                    if(marker.EndOffset > fileLength)
                    {
                        marker.EndOffset = 0;
                        //throw new Exception("File ending is malformed");
                    }
                }
            }

            public List<FileMarker> GetMarkers()
            {
                return markers;
            }
        }
        
        private List<FileMarker> ScanThroughFile(string filePath)
        {

            FileMarkerMachine machine = new FileMarkerMachine();
            
            const int BUFFER_SIZE = 4096;
            const int BUFFER_OVERLAP = 10;

            byte[] buffer = new byte[BUFFER_SIZE];
            byte[] copyBuffer = new byte[BUFFER_OVERLAP];
            // a file identifer might get cut off by the end of the buffer
            // so keep a copy of the end of previous loop's buffer
            byte[] endOfPreviousBuffer = new byte[BUFFER_OVERLAP];
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                uint fileLength = (uint)fileStream.Length;
                uint bufferCount = (uint)fileLength / (uint)buffer.Length;

                uint loopCount = 0;
                uint currentFileOffset = 0;
                int returnedBufferSize = 0;
                bool endOfFile = false;

                List<FileIdentifierMatch> matches = new List<FileIdentifierMatch>();

                while (loopCount <= bufferCount)
                {
                    buffer.Skip(BUFFER_SIZE - BUFFER_OVERLAP).Take(BUFFER_OVERLAP).ToArray().CopyTo(copyBuffer, 0);
                    currentFileOffset = loopCount * BUFFER_SIZE;
                    fileStream.Seek(currentFileOffset, SeekOrigin.Begin);
                    returnedBufferSize = fileStream.Read(buffer, 0, buffer.Length);
                    loopCount++;

                    //check and handle end of file
                    if (returnedBufferSize < BUFFER_SIZE)
                    {
                        buffer = buffer.Take(returnedBufferSize).ToArray();
                        endOfFile = true;
                    }                   

                    matches = FindFileIdentifiersInBufferBoundary(endOfPreviousBuffer, buffer, currentFileOffset);
                    matches.AddRange(FindFileIdentifiersInBuffer(buffer, currentFileOffset));
                    
                    foreach(var match in matches)
                    {
                        machine.AddFileIdentifierMatch(match);
                    }

                    if(endOfFile)
                    {
                        machine.EndOfFile(fileLength);
                    }

                    //// in case there is unknown data at start of file
                    //if(loopCount == 0 &  matches.Count < 1)
                    //{
                    //    var match = new FileIdentifierMatch();
                    //    match.FileOffset = 0;
                    //    match.Identifier = new FileIdentifier(M3AFileType.Unknown, FileBoundaryType.Start, null);
                    //    machine.AddFileIdentifierMatch(match);
                    //}

                    copyBuffer.CopyTo(endOfPreviousBuffer, 0);
                }
            }
            finally
            {
                fileStream.Close();
            }

            return machine.GetMarkers();
        }

        private static uint FindEndOffsetOfBinkFile(byte[] startOfBinkFile)
        {
            byte[] fileLengthData = startOfBinkFile.Skip(4).Take(4).ToArray();

            //int num = 45943;
            //var hex = BitConverter.GetBytes(num);


            // bink stores the file's lenght as 4 bytes
            // when the last bytes bits are 0, then it is a uint16 number
            // when the last bytes bits are used, then it is a uint32 number
            uint fileLength = 0;
            if (fileLengthData[2] == 0 && fileLengthData[3] == 0)
            {
                fileLength = BitConverter.ToUInt16(fileLengthData, 0);
            }
            else
            {
                fileLength = BitConverter.ToUInt32(fileLengthData, 0);
            }

            //Bink uses INT32 - Little Endian (DCBA)
            return fileLength + 8; // the file length does not include length of header
        }



        /*
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
        */

        private bool EqualsPatternAtPosition(byte[] source, byte[] pattern, uint position)
        {
            for (uint i = 0; i < pattern.Length; ++i)
                if (position + i >= source.Length || source[position + i] != pattern[i])
                    return false;
            return true;
        }

        private VirtualFolder CreateListing(List<FileMarker> markers, string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var folder = new VirtualFolder(fileName);
            var fileCount = 0;
            var jpgCount = 0;
            var binkCount = 0;
            var binCount = 0;
            string countLabel = "";
            VirtualFileArchive archiveIndex = null;

            foreach (var marker in markers)
            {
                countLabel = "";
                FileType type = FileType.Unknown;
                string fileExtension = ".unknown";
                if (marker.Type == M3AFileType.Jpg)
                {
                    type = FileType.Jpg;
                    fileExtension = ".jpg";
                    jpgCount += 1;
                    countLabel = jpgCount.ToString("D4");
                }
                else if(marker.Type == M3AFileType.Bink)
                {
                    type = FileType.Bink;
                    fileExtension = ".bik";
                    binkCount += 1;
                    countLabel = binkCount.ToString("D4");
                }
                else
                {
                    binCount += 1;
                    countLabel = binCount.ToString("D4");
                }

                archiveIndex = new VirtualFileArchive(filePath, type, marker.BeginOffset, marker.EndOffset);
                folder.Files.Add(new VirtualFile(countLabel + fileExtension, archiveIndex));
            }
            return folder;
        }
    }
}
