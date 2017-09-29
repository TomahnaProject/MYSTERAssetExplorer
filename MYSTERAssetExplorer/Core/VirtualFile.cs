using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYSTERAssetExplorer.Core
{
    public interface IVirtualFile
    {
        string Name { get; }
        //string ParentPath { get; }
        IVirtualFileContentDetails ContentDetails { get; }
    }

    // meant to be read only; once the indexer figures out what/where a file is, then it shouldn't change around
    public class VirtualFile : IVirtualFile
    {
        private string _name;
        private IVirtualFileContentDetails _contentDetails;


        public string Name { get { return _name; } }
        public IVirtualFileContentDetails ContentDetails { get { return _contentDetails; } }

        public VirtualFile(string name, IVirtualFileContentDetails contentDetails)
        {
            _name = name;
            _contentDetails = contentDetails;
        }
    }
}
