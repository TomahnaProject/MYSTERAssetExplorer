using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERAssetExtractor.Core
{
    public class VirtualFileListing
    {
        List<VirtualFileIndex> files;

        public VirtualFileListing()
        {
            files = new List<VirtualFileIndex>();
        }

        public void Add(VirtualFileIndex file)
        {
            files.Add(file);
        }

        public List<VirtualFileIndex> GetList()
        {
            return files.ToList();
        }
    }
}
