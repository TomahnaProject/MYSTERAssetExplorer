using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public class VirtualFileTiledImage : IVirtualFileContentDetails
    {
        public FileType Type { get; set; }
        public List<IVirtualFile> Tiles { get; private set; }

        public VirtualFileTiledImage()
        {
            // maybe should be paths or strings instead of direct references?
            Tiles = new List<IVirtualFile>();
        }
    }
}
