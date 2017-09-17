using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExtractor.Core
{
    public class NodeRegistry
    {
        public List<Node> Nodes { get; set; }

        public NodeRegistry()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }
    }
}
