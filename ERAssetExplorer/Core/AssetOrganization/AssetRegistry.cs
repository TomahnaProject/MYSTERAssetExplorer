using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExplorer.Core
{
    public class AssetRegistry
    {
        public List<Node> Nodes { get; set; }

        public AssetRegistry()
        {
            Nodes = new List<Node>();
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
