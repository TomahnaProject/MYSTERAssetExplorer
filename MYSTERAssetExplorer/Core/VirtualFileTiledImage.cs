using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public class VirtualFileTiledImage
    {
        public string Name { get; set; }
        public List<VirtualFileIndex> Tiles { get; set; }

        public VirtualFileTiledImage()
        {
            Tiles = new List<VirtualFileIndex>();
        }
    }
}
