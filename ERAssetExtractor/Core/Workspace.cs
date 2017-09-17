using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExtractor.Core
{
    public class Workspace
    {
        public string RootDir { get; set; }

        // segregation of various elements 
        public string SpriteDir { get; set; }
        public string NodeDir { get; set; }
        public string VideoDir { get; set; }
        public string OtherDir { get; set; }

        // output for constructed stuff
        public string PanoDir { get; set; }
    }
}
