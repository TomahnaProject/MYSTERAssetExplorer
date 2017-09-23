using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public class VirtualFolder
    {
        public string Name { get; set; }
        public List<VirtualFolder> SubFolders { get; private set; }
        public List<VirtualFileIndex> Files { get; private set; }
        public List<VirtualFileTiledImage> TiledImages { get; private set; }

        public VirtualFolder(string name)
        {
            Name = name;
            SubFolders = new List<VirtualFolder>();
            Files = new List<VirtualFileIndex>();
            TiledImages = new List<VirtualFileTiledImage>();
        }
    }
}
