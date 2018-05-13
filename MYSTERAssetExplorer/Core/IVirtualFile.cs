using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public interface IVirtualFile
    {
        string Name { get; }
        //string ParentPath { get; }
        IVirtualFileContentDetails ContentDetails { get; }
    }
}
