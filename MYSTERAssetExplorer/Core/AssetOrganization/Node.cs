using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYSTERAssetExplorer.Core
{
    [Serializable]
    public class Node
    {
        public enum NodeType
        {
            Normal,
            Variant,
            Partial,
        }

        [Serializable]
        public class NodeRotator
        {
            [XmlAttribute]
            public double Yaw { get; set; }
        }

        [Serializable]
        public class NodeTranslator
        {
            [XmlAttribute]
            public double X { get; set; }
            [XmlAttribute]
            public double Y { get; set; }
            [XmlAttribute]
            public double Z { get; set; }
        }

        [Serializable]
        public class NodeSprite
        {
            [XmlAttribute]
            public string File { get; set; }
        }

        [Serializable]
        public class NodeMaps
        {
            [XmlAttribute]
            public double DepthRange { get; set; }
            public CubeMapImageSet Color { get; set; }
            public CubeMapImageSet Depth { get; set; }
        }

        [XmlAttribute]
        public string Scene { get; set; }
        [XmlAttribute]
        public string Zone { get; set; }
        [XmlAttribute]
        public string Number { get; set; }
        [XmlAttribute]
        public NodeType Type { get; set; }

        // for photogrammetry purposes
        public NodeTranslator Position { get; set; }
        public NodeRotator Rotation { get; set; }

        public NodeMaps CubeMaps { get; set; }
        public List<NodeSprite> Sprites { get; set; }

        public Node()
        {
            Position = new NodeTranslator();
            Rotation = new NodeRotator();
            Sprites = new List<NodeSprite>();
            CubeMaps = new NodeMaps();
            CubeMaps.Color = new CubeMapImageSet();
         }
    }
}
