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
        public class NodeRotation
        {
            [XmlAttribute]
            public double Yaw { get; set; }
        }

        [Serializable]
        public class NodeTranslation
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
        public class NodeCubeMaps
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

        public string GetFullName()
        {
            return Scene + "_" + Zone + "_" + Number;
        }

        // for photogrammetry purposes
        public NodeTranslation Position { get; set; }
        public NodeRotation Rotation { get; set; }

        public NodeCubeMaps CubeMaps { get; set; }
        public List<NodeSprite> Sprites { get; set; }

        public Node()
        {
            Position = new NodeTranslation();
            Rotation = new NodeRotation();
            Sprites = new List<NodeSprite>();
            CubeMaps = new NodeCubeMaps();
            CubeMaps.Color = new CubeMapImageSet();
         }
    }
}
