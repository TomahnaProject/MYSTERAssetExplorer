using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveSystem.VirtualFileSystem
{
    public class VirtualFileAddress
    {
        public VirtualFileAddress(string game, string scene, string zone, string nodeNumber, string fileName)
        {
            Game = game;
            Scene = scene;
            Zone = zone;
            Node = nodeNumber;
            FileName = fileName;
        }
        public string Game { get; set; }
        public string Scene { get; set; }
        public string Zone { get; set; }
        public string Node { get; set; }
        public string FileName { get; set; }
    }
}
