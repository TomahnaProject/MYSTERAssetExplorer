using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveSystem.VirtualFileSystem
{
    public interface IVirtualFileData
    {
        FileType Type { get; }
    }

}
