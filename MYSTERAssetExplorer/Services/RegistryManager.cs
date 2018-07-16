using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public class RegistryManager
    {
        public GameRegistry Registry { get; set; }

        public RegistryManager()
        {
            Registry = new GameRegistry();
        }

        public void AddNode(GameIdentity game, Node node)
        {
            AssetRegistry reg;
            switch (game)
            {
                case GameIdentity.Revelation:
                    reg = Registry.Revelation;
                    break;
                default:
                    reg = Registry.Exile;
                    break;
            }
            reg.Nodes.Add(node);
        }

        public AssetRegistry CreateFakeRegistry()
        {
            var registry = new AssetRegistry();
            var node01 = new Node();
            node01.Scene = "Amateria";
            node01.Zone = "TO";
            node01.Number = "010";

            var cubeMap = new CubeMapImageSet();
            cubeMap.Back.File = "0001.jpg";
            cubeMap.Bottom.File = "0002.jpg";
            cubeMap.Front.File = "0003.jpg";
            cubeMap.Left.File = "0004.jpg";
            cubeMap.Right.File = "0005.jpg";
            cubeMap.Top.File = "0006.jpg";
            node01.CubeMaps.Color = cubeMap;

            registry.Nodes.Add(node01);
            return registry;
        }
    }
}
