using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExplorer.Core
{
    public class GameRegistry
    {
        public AssetRegistry Exile { get; set; }
        public AssetRegistry Revelation { get; set; }

        public GameRegistry()
        {
            Exile = new AssetRegistry();
            Revelation = new AssetRegistry();
        }
    }
}
