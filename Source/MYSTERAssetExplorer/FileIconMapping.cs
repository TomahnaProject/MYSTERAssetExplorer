using ArchiveSystem.VirtualFileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer
{
    public class FileIconMapping
    {
        private static Dictionary<string, uint> Mapping = new Dictionary<string, uint>(StringComparer.OrdinalIgnoreCase)
        {
            {"FolderOpen",0},
            {"FolderClosed",1},
            {"Unknown",2},
            {"M3A",3},
            {"M4A",4},
            {"Jpg",5},
            {"Zap",6},
            {"Bink",7},
            {"Binary",8},
            {"Bmp",9},
            {"Text",10},
        };


        public static uint GetIconIndexForFileType(string fileTypeName)
        {
            uint index = 2;
            Mapping.TryGetValue(fileTypeName, out index);
            return index;

        }

        public static uint GetIconIndexForFileType(FileType type)
        {
            return GetIconIndexForFileType(type.Name);
        }
    }
}
