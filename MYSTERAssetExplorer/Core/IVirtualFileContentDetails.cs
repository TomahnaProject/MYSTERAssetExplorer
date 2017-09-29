using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public interface IVirtualFileContentDetails
    {
        FileType Type { get; }
    }

    public class ArchiveIndex : IVirtualFileContentDetails
    {
        public FileType Type { get; set; }
        public string ArchiveFilePath { get; set; }
        public long Start { get; private set; }
        public long End { get; private set; }

        public ArchiveIndex(string archiveFilePath, FileType type, long startOffset, long endOffset)
        {
            this.ArchiveFilePath = archiveFilePath;
            this.Type = type;
            this.Start = startOffset;
            this.End = endOffset;
        }
    }

    public class TiledImage : IVirtualFileContentDetails
    {
        public FileType Type { get; set; }
        public List<IVirtualFile> Tiles { get; private set; }

        public TiledImage()
        {
            // maybe should be paths or strings instead of direct references?
            Tiles = new List<IVirtualFile>();
        }
    }
}
