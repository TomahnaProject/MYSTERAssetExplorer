using MYSTER.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.App
{
    public class RegistryTreeViewManager
    {
        public Action<TreeNode[]> PopulateNodes { get; set; }

        public RegistryTreeViewManager()
        {
        }

        public void RegenTreeView(GameRegistry registry)
        {
            var games = new List<TreeNode>();
            var exileNodes = NodesForAssetRegistry(registry.Exile);
            games.Add(new TreeNode("Exile", exileNodes.ToArray()));
            var revNodes = NodesForAssetRegistry(registry.Revelation);
            games.Add(new TreeNode("Revelation", revNodes.ToArray()));
            PopulateNodes(games.ToArray());
        }

        private List<TreeNode> NodesForAssetRegistry(AssetRegistry registry)
        {
            var registry_tNodes = new List<TreeNode>();

            var nodesByScene = registry.Nodes.GroupBy(x => x.Scene);

            foreach (var scene in nodesByScene)
            {
                var sceneName = scene.FirstOrDefault().Scene;
                var scene_tNodes = new List<TreeNode>();
                var nodesByZones = scene.GroupBy(x => x.Zone);

                foreach (var zone in nodesByZones)
                {
                    var zoneName = zone.FirstOrDefault().Zone;
                    var zone_tNodes = new List<TreeNode>();
                    var orderedNodes = zone.OrderBy(x => x.Number);

                    foreach (var node in orderedNodes)
                    {
                        var nodeName = node.Number;
                        var treeNode = new TreeNode(nodeName);
                        treeNode.Tag = node;
                        zone_tNodes.Add(treeNode);
                    }
                    scene_tNodes.Add(new TreeNode(zoneName, zone_tNodes.ToArray()));
                }
                registry_tNodes.Add(new TreeNode(sceneName, scene_tNodes.ToArray()));
            }
            return registry_tNodes;
        }
    }
}
