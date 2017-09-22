using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYSTERAssetExplorer.Core
{
    // meant to be read only; once the indexer figures out what/where a file is, then it shouldn't change around
    public class VirtualFileIndex
    {
        private int _id;
        private string _name;
        private FileType _type;
        private long _start;
        private long _end;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public FileType Type { get { return _type; } }
        public long Start { get { return _start; } }
        public long End { get { return _end; } }

        public VirtualFileIndex(int id, string name, FileType type, long start, long end)
        {
            _id = id;
            _name = name;
            _type = type;
            _start = start;
            _end = end;
        }

        public long GetSize()
        {
            return End - Start;
        }
    }
}
