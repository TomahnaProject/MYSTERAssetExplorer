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
        public readonly string M3A_FileExtension = ".m3a";
        public readonly string M4B_FileExtension = ".m4b";

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
