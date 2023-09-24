using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ArchiveSystem.VirtualFileSystem
{
    [KnownType(typeof(VirtualFolder))]
    [KnownType(typeof(VirtualFileEntry))]
    public class VirtualFolder : IVirtualFolder
    {
        public string Name { get; set; }
        public List<IVirtualFolder> SubFolders { get; private set; }
        public List<IVirtualFileEntry> Files { get; private set; }

        public VirtualFolder()
        {
            SubFolders = new List<IVirtualFolder>();
            Files = new List<IVirtualFileEntry>();
        }

        public VirtualFolder(string name)
        {
            Name = name;
            SubFolders = new List<IVirtualFolder>();
            Files = new List<IVirtualFileEntry>();
        }
    }
}
