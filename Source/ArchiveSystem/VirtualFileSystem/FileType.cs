using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveSystem.VirtualFileSystem
{
    public class FileType
    {
        public string Name { get; private set; }
        public string Extension { get; private set; }

        public static List<FileType> SupportedFiles { get; set; } = new List<FileType>()
        {
            new FileType("unknown","unk"),
            new FileType("binary","bin"),
            new FileType("jpg","jpg"),
            new FileType("m3archive","m3a"),
            new FileType("m4archive","m4b"),
            new FileType("zap","zap"),
            new FileType("bink","bik"),
            new FileType("bitmap","bmp"),
            new FileType("text","txt"),
        };


        public FileType(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }


        public static FileType GetFileTypeByExension(string extension)
        {
            if (extension.StartsWith("."))
                extension = extension.Remove(0, 1);
            var fileType = SupportedFiles.Where(x => x.Extension.ToLower() == extension.ToLower()).FirstOrDefault();
            if (fileType == null)
                throw new FormatException(extension + " is not a supported file format");
            return fileType;
        }
        public static FileType GetFileTypeByName(string name)
        {
            var fileType = SupportedFiles.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (fileType == null)
                throw new FormatException(name + " is not a supported file format");
            return fileType;
        }

        public bool NameIs(string name)
        {
            return this.Name.ToLower() == name.ToLower();
        }

        public bool ExtensionIs(string extension)
        {
            return this.Extension.ToLower() == extension.ToLower();
        }
    }
}
