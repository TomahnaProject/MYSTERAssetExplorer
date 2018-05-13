using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    [KnownType(typeof(VirtualFolder))]
    [KnownType(typeof(VirtualFile))]
    public class VirtualFolder : IVirtualFolder
    {
        public string Name { get; set; }
        public List<IVirtualFolder> SubFolders { get; private set; }
        public List<IVirtualFile> Files { get; private set; }

        public VirtualFolder()
        {
            SubFolders = new List<IVirtualFolder>();
            Files = new List<IVirtualFile>();
        }

        public VirtualFolder(string name)
        {
            Name = name;
            SubFolders = new List<IVirtualFolder>();
            Files = new List<IVirtualFile>();
        }
    }
}
