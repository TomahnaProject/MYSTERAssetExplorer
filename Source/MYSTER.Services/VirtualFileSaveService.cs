using ArchiveSystem.VirtualFileSystem;
using System.IO;

namespace MYSTER.Services
{
    public class VirtualFileSaveService
    {
        public void SaveFile(string filePath, string fileName, FileType type, byte[] data)
        {
            string extension = "";
            if (type == FileType.Jpg)
                extension = ".jpg";
            else if (type == FileType.Bink)
                extension = ".bik";

            if (!fileName.Contains(extension))
                fileName += extension;

            var savePath = Path.Combine(filePath, fileName);

            if (type == FileType.Jpg)
                ImageSaveService.Save(savePath, data);
            else
                File.WriteAllBytes(savePath, data);
        }

        public string SaveFolder(string filePath, string folderName)
        {
            string path = "";
            if (Directory.Exists(filePath))
            {
                path = Path.Combine(filePath, folderName);
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}
