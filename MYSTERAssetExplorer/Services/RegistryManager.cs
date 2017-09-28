using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        }

        public AssetRegistry CreateFakeRegistry()
        {
            var registry = new AssetRegistry();
            var node01 = new Node();
            node01.Scene = "MA";
            node01.Zone = "TO";
            node01.Number = "010";

            var cubeMap = new CubeMapImageSet();
            cubeMap.Back.File = "a";
            cubeMap.Bottom.File = "b";
            cubeMap.Front.File = "c";
            cubeMap.Left.File = "d";
            cubeMap.Right.File = "e";
            cubeMap.Top.File = "f";
            node01.CubeMaps.Color = cubeMap;

            registry.Nodes.Add(node01);
            return registry;

        }
    }
}
