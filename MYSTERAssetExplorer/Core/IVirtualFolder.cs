using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public interface IVirtualFolder
    {
        string Name { get; set; }
        List<IVirtualFolder> SubFolders { get; }
        List<IVirtualFile> Files { get; }
    }
}
