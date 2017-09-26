using MYSTERAssetExplorer.Core;
using MYSTERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.App
{
    public class AssetExplorerContext
    {
        //UI
        public IUIContext uiContext;

        // Asset Explorer
        public VirtualFolder VirtualFiles;
        public string DataDirectory { get; set; }
        public string ExtractionDirectory { get; set; }

        // Node Viewer
        public RegistryManager registryManager;
        public RegistryPersistenceService registryPersistence;
    }
}
