namespace ArchiveSystem.VirtualFileSystem
{
    public interface VirtualFileData
    {
        FileType FileType { get; }
        // dictionary for meta data -- resource type could go into it
        string ResourceType { get; }
    }

    public class VirtualFileDataInArchive : VirtualFileData
    {
        public FileType FileType { get; set; } // want to make this into a class rather than enum
        public string ResourceType { get; set; }
        public string ArchiveFilePath { get; set; }
        public long FileOffsetBegin { get; private set; }
        public long FileOffsetEnd { get; private set; }

        public VirtualFileDataInArchive(string archiveFilePath, FileType fileType, string resourceType, long startOffset, long endOffset)
        {
            this.ArchiveFilePath = archiveFilePath;
            this.ResourceType = resourceType;
            this.FileType = fileType;
            this.FileOffsetBegin = startOffset;
            this.FileOffsetEnd = endOffset;
        }
    }

    public class VirtualFileDataInMemory : VirtualFileData
    {
        public FileType FileType { get; set; }
        public string ResourceType { get; set; }
        public byte[] Data;
        public VirtualFileDataInMemory(FileType fileType, string resourceType, byte[] data)
        {
            this.ResourceType = resourceType;
            this.FileType = fileType;
            Data = data;
        }
    }
}
