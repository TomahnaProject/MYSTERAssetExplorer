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

        [XmlIgnore]
        public CubeMapImageSet CubeMap { get; set; }
        [XmlIgnore]
        public CubeMapImageSet DepthMap { get; set; }

        [XmlAttribute]
        public string Scene { get; set; }
        [XmlAttribute]
        public string Zone { get; set; }
        [XmlAttribute]
        public string Number { get; set; }
        [XmlAttribute]
        public NodeType Type { get; set; }
        [XmlAttribute]
        public string Order { get; set; }

        [XmlAttribute]
        public double X { get; set; }
        [XmlAttribute]
        public double Y { get; set; }
        [XmlAttribute]
        public double Z { get; set; }

        [XmlAttribute]
        public double Yaw { get; set; }

        [XmlAttribute]
        public double Depth { get; set; }

        public string GetFullName()
        {
            return Scene + "_" + Zone + "_" + Number;
        }

        public Node()
        {
            CubeMap = new CubeMapImageSet();
         }
    }
}
