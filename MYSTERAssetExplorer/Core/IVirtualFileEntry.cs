using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public interface IVirtualFileEntry
    {
        string Name { get; }
        //string ParentPath { get; }
        IVirtualFileData FileData { get; }
    }
}
