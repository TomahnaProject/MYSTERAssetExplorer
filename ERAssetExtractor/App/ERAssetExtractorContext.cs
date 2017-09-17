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
        public FileListing files;
        public FileIndexerService indexer;
        public FileExtractionService extractor;
        public WorkspaceModificationService workspaceModServ;
        public RegistryManager registryManager;
        public IUIContext uiContext;

        public List<IMedia> Files { get; set; }
    }
}
