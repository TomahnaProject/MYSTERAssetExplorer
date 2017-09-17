using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExplorer.Core
{
    public class Node
    {
        public string Scene { get; set; }
        public string Zone { get; set; }
        public int Id { get; set; }
        public CubeMapImageSet CubeMap { get; set; }
        public List<Sprite> Sprites { get; set; }

        // for photogrammetry purposes
        public Vector3 Position { get; set; }
    }
}
