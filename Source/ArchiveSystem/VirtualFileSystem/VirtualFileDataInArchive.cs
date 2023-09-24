using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveSystem.VirtualFileSystem
{
    public class VirtualFileDataInArchive : IVirtualFileData
    {
        public FileType Type { get; set; }
        public string ArchiveFilePath { get; set; }
        public long Start { get; private set; }
        public long End { get; private set; }

        public VirtualFileDataInArchive(string archiveFilePath, FileType type, long startOffset, long endOffset)
        {
            this.ArchiveFilePath = archiveFilePath;
            this.Type = type;
            this.Start = startOffset;
            this.End = endOffset;
        }
    }

}
