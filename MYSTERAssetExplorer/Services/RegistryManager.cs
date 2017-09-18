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
            node01.Id = 1;

            var cubeMap = new CubeMapImageSet();
            cubeMap.Back = "a";
            cubeMap.Bottom = "b";
            cubeMap.Front = "c";
            cubeMap.Left = "d";
            cubeMap.Right = "e";
            cubeMap.Top = "f";
            node01.CubeMap = cubeMap;

            registry.Nodes.Add(node01);
            return registry;

        }
    }
}
