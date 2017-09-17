using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExtractor.Core
{
    public class GameList
    {
        public AssetRegistry Exile { get; set; }
        public AssetRegistry Revelation { get; set; }

        public GameList()
        {
            Exile = new AssetRegistry();
            Revelation = new AssetRegistry();
        }
    }
}
