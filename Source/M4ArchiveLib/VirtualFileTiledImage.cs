using ArchiveSystem.VirtualFileSystem;
using System.Collections.Generic;

namespace M4ArchiveLib
{
    public class VirtualFileTiledImage : VirtualFileData
    {
        public FileType Type { get; set; }
        public List<IVirtualFileEntry> Tiles { get; private set; }

        public string FileType => throw new System.NotImplementedException();

        public string ResourceType => throw new System.NotImplementedException();

        FileType VirtualFileData.FileType => throw new System.NotImplementedException();

        public VirtualFileTiledImage()
        {
            // maybe should be paths or strings instead of direct references?
            Tiles = new List<IVirtualFileEntry>();
        }
    }
}
