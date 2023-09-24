using ArchiveSystem.VirtualFileSystem;

namespace ArchiveSystem
{
    public interface IFileIndexerService
    {
        IVirtualFolder IndexFile(string filePath);
    }
}
