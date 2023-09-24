using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
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
