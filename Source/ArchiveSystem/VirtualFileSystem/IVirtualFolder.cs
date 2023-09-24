using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ArchiveSystem.VirtualFileSystem
{
    public interface IVirtualFolder
    {
        string Name { get; set; }
        List<IVirtualFolder> SubFolders { get; }
        List<IVirtualFileEntry> Files { get; }
    }
}
