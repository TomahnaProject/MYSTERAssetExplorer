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
        public string DataDirectory { get; set; }
        public string ExtractionDirectory { get; set; }
        public string CurrentNode { get; set; }

        public VirtualFolder VirtualFiles;
        public RegistryManager registryManager;
        public RegistryPersistenceService registryPersistence;
        public IUIContext uiContext;

        // i may want to remove these
        //public List<IMedia> Files { get; set; }
        public VirtualFileExtractionService extractor;
    }
}
