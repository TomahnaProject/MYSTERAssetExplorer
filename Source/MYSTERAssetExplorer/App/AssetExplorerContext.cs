using ArchiveSystem.VirtualFileSystem;
using MYSTER.Services;

namespace MYSTERAssetExplorer.App
{
    public class AssetExplorerContext
    {
        public readonly string M3A_FileExtension = ".m3a";
        public readonly string M4B_FileExtension = ".m4b";

        public IVirtualFolder VirtualFiles;
        public string CacheDirectory { get; set; }
        public string DataDirectory { get; set; }
        public string ExtractionDirectory { get; set; }
        public CacheSerializationService CacheService { get; set; }
    }
}
