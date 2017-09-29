using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public interface IVirtualFolder
    {
        string Name { get; set; }
        List<IVirtualFolder> SubFolders { get; }
        List<IVirtualFile> Files { get; }
    }

    public class VirtualFolder : IVirtualFolder
    {
        public string Name { get; set; }
        public List<IVirtualFolder> SubFolders { get; private set; }
        public List<IVirtualFile> Files { get; private set; }

        public VirtualFolder(string name)
        {
            Name = name;
            SubFolders = new List<IVirtualFolder>();
            Files = new List<IVirtualFile>();
        }
    }
}
