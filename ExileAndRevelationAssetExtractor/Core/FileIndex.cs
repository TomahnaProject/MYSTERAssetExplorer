using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExileAndRevelationAssetExtractor.Core
{
    // meant to be read only; once the indexer figures out what/where a file is, then it shouldn't change around
    public class FileIndex
    {
        private int _id;
        private string _name;
        private FileType _type;
        private int _start;
        private int _end;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public FileType Type { get { return _type; } }
        public int Start { get { return _start; } }
        public int End { get { return _end; } }

        public FileIndex(int id, string name, FileType type, int start, int end)
        {
            _id = id;
            _name = name;
            _type = type;
            _start = start;
            _end = end;
        }
    }
}
