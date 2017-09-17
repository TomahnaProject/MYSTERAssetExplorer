using ERAssetExtractor.Core;
using ERAssetExtractor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExtractor.App
{
    public class ERAssetExtractorContext
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
