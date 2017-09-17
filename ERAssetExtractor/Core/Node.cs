using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExtractor.Core
{
    public class Node
    {
        public string Scene { get; set; }
        public string Area { get; set; }
        public int Id { get; set; }
        public CubeMapImageSet CubeMap { get; set; }
        public List<Sprite> Sprites { get; set; }
    }
}
