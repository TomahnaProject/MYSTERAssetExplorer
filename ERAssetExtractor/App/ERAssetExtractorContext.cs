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

        public VirtualFileListing files;
        public VirtualFileIndexerService indexer;
        public VirtualFileExtractionService extractor;
        public WorkspaceModificationService workspaceModServ;
        public RegistryManager registryManager;
        public IUIContext uiContext;

        public List<IMedia> Files { get; set; }
    }
}
