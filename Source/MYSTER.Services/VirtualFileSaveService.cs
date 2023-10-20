using ArchiveSystem.VirtualFileSystem;
using System.IO;

namespace MYSTER.Services
{
    public class VirtualFileSaveService
    {
        public void SaveFile(string filePath, string fileName, FileType type, byte[] data)
        {
            if (!fileName.Contains(type.Extension))
                fileName += "." + type.Extension;

            var savePath = Path.Combine(filePath, fileName);

            if (type.Name == "jpg")
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
