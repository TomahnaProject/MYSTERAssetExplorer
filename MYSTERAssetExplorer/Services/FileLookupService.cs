using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public class FileLookupService
    {
        VirtualFolder rootFolder;

        private void ExampleUse()
        {
            bool couldFind = false;
            var file = GetFile(out couldFind, "Exile","Amateria","Cave","010","0001.jpg");
        }

        public VirtualFileIndex GetFile(out bool couldFind, string game, string scene, string zone, string node, string image)
        {
            couldFind = false;
            VirtualFileIndex file = null;


            var gameFolder = rootFolder.SubFolders.FirstOrDefault(x => string.Equals(x.Name, game, StringComparison.OrdinalIgnoreCase));
            gameFolder.SubFolders.Where(x=>x.Name == "SceneName");

            couldFind = true;
            return file;
        }

        //public VirtualFileIndex GetExileFile(out bool couldFind, string game, string scene, string zone, string node, string image)
        //{
        //    String oemString = Enum.GetName(typeof(GroupTypes), GroupTypes.OEM);
        //}
        //public VirtualFileIndex GetRevelationFile(out bool couldFind, string game, string scene, string zone, string node, string image)
        //{

        //}
    }
}
