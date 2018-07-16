using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public class AssetRegistry
    {
        public List<Node> Nodes { get; set; }

        public AssetRegistry()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            var existingNode = Nodes.Where(x =>
                x.Scene.ToUpper() == node.Scene.ToUpper() &&
                x.Zone.ToUpper() == node.Zone.ToUpper() &&
                x.Number.ToUpper() == node.Number.ToUpper()
            ).FirstOrDefault();
           
            if(existingNode != null)
                Nodes.Remove(existingNode);
            Nodes.Add(node);
        }

        public List<Node> GetNodesByScene(string sceneName)
        {
            return Nodes.Where(x => x.Scene == sceneName).ToList();
        }

        public List<Node> GetNodesByZone(string sceneName, string zone)
        {
            return Nodes.Where(x => x.Scene == sceneName && x.Zone == zone).ToList();
        }
    }
}
