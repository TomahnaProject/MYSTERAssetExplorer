using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveSystem.VirtualFileSystem
{
    // meant to be read only; once the indexer figures out what/where a file is, then it shouldn't change around
    public class VirtualFileEntry : IVirtualFileEntry
    {
        private string _name;
        private IVirtualFileData _fileData;


        public string Name { get { return _name; } }
        public IVirtualFileData FileData { get { return _fileData; } }

        public VirtualFileEntry(string name, IVirtualFileData fileData)
        {
            _name = name;
            _fileData = fileData;
        }
    }
}
