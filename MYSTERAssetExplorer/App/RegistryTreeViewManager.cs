using MYSTERAssetExplorer.Core;
using MYSTERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.App
{
    public class RegistryTreeViewManager
    {
        IUIContext _uiContext;
        public RegistryTreeViewManager(IUIContext uiContext)
        {
            _uiContext = uiContext;
        }

        public void RegenTreeView(GameRegistry registry)
        {

            var nodesByAreas = registry.Exile.Nodes.GroupBy(x => x.Zone);
            var scene_tNodes = new List<TreeNode>();

            foreach (var area in nodesByAreas)
            {
                var areaName = area.FirstOrDefault().Zone;
                var area_tNodes = new List<TreeNode>();
                foreach (var node in area)
                {
                    var nodeName = node.Id.ToString();
                    var nodeParts = new List<TreeNode>();
                    nodeParts.Add(new TreeNode("Back", (new TreeNode[1] { new TreeNode(node.CubeMap.Back) })));
                    nodeParts.Add(new TreeNode("Bottom", (new TreeNode[1] { new TreeNode(node.CubeMap.Bottom) })));
                    nodeParts.Add(new TreeNode("Front", (new TreeNode[1] { new TreeNode(node.CubeMap.Front) })));
                    nodeParts.Add(new TreeNode("Left", (new TreeNode[1] { new TreeNode(node.CubeMap.Left) })));
                    nodeParts.Add(new TreeNode("Right", (new TreeNode[1] { new TreeNode(node.CubeMap.Right) })));
                    nodeParts.Add(new TreeNode("Top", (new TreeNode[1] { new TreeNode(node.CubeMap.Top) })));
                    area_tNodes.Add(new TreeNode(nodeName, nodeParts.ToArray()));
                }

                scene_tNodes.Add(new TreeNode(areaName, area_tNodes.ToArray()));
            }

            _uiContext.PopulateNodes(scene_tNodes.ToArray());
        }
    }
}
