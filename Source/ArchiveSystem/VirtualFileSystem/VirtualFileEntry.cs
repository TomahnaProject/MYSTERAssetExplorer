namespace ArchiveSystem.VirtualFileSystem
{
    public interface IVirtualFileEntry
    {
        string FileName { get; }
        //string ParentPath { get; }

        string FileExtension { get; }
        VirtualFileData FileData { get; }
    }

    // meant to be read only; once the indexer figures out what/where a file is, then it shouldn't change around
    public class VirtualFileEntry : IVirtualFileEntry
    {
        public string FileName { get; private set; }
        public string FileExtension { get; private set; }
        public VirtualFileData FileData { get; private set; }

        public VirtualFileEntry(string name, string fileExtension, VirtualFileData fileData)
        {
            FileName = name;
            FileData = fileData;
            FileExtension = fileExtension;
        }
    }
}
