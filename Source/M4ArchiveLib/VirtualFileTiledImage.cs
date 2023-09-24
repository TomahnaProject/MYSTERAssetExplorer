using ArchiveSystem.VirtualFileSystem;
using System.Collections.Generic;

namespace M4ArchiveLib
{
    public class VirtualFileTiledImage : IVirtualFileData
    {
        public FileType Type { get; set; }
        public List<IVirtualFileEntry> Tiles { get; private set; }

        public VirtualFileTiledImage()
        {
            // maybe should be paths or strings instead of direct references?
            Tiles = new List<IVirtualFileEntry>();
        }
    }
}
