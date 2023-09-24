using ArchiveSystem.VirtualFileSystem;

namespace MYSTER.Services
{
    public interface IFileIndexerService
    {
        IVirtualFolder IndexFile(string filePath);
    }
}
