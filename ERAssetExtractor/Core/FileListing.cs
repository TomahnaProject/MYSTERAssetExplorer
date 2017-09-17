using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERAssetExtractor.Core
{
    public class FileListing
    {
        List<FileIndex> files;

        public FileListing()
        {
            files = new List<FileIndex>();
        }

        public void Add(FileIndex file)
        {
            files.Add(file);
        }

        public List<FileIndex> GetList()
        {
            return files.ToList();
        }
    }
}
