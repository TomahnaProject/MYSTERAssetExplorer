using ERAssetExplorer.Core;
using ERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExplorer.App
{
    public class ERAssetExplorerContext
    {
        public string DataDirectory { get; set; }
        public string CurrentNode { get; set; }

        public List<IMedia> Files { get; set; }


        public VirtualFileListing files;
        public VirtualFileIndexerService indexer;
        public VirtualFileExtractionService extractor;
        public RegistryManager registryManager;
        public RegistryPersistenceService registryPersistence;
        public IUIContext uiContext;
    }
}
