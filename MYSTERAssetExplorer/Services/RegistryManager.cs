using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.Services
{
    public class RegistryManager
    {
        private IUIContext uiContext;
        public GameRegistry Registry { get; set; }

        public RegistryManager(IUIContext context)
        {
            uiContext = context;
            Registry = new GameRegistry();

            //CreateFakeRegistry();
        }

        public void RegenTreeView()
        {
            var nodesByAreas = Registry.Exile.Nodes.GroupBy(x => x.Zone);
            var scene_tNodes = new List<TreeNode>();

            foreach (var area in nodesByAreas)
            {
                var areaName = area.FirstOrDefault().Zone;
                var area_tNodes = new List<TreeNode>();
                foreach(var node in area)
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
            
            uiContext.PopulateNodes(scene_tNodes.ToArray());
        }

        public void CreateFakeRegistry()
        {
            //var exile = new AssetRegistry();
            //var node01 = new Node();
            //node01.Scene = "MA";
            //node01.Area = "TO";
            //node01.Id = 1;

            //var cubeMap = new CubeMapImageSet();
            //cubeMap.Back = "a";
            //cubeMap.Bottom = "b";
            //cubeMap.Front = "c";
            //cubeMap.Left = "d";
            //cubeMap.Right = "e";
            //cubeMap.Top = "f";
            //node01.CubeMap = cubeMap;

            //Registry.AddNode(node01);
        }
    }
}
