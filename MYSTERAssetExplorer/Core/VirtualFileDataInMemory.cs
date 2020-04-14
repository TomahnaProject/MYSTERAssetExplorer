using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public class VirtualFileDataInMemory : IVirtualFileData
    {
        public FileType Type { get; set; }
        public byte[] Data;
        public VirtualFileDataInMemory(FileType type, byte[] data)
        {
            this.Type = type;
            Data = data;
        }
    }
}
