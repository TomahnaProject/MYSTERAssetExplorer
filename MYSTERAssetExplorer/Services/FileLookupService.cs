using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public class FileLookupService
    {
        IVirtualFolder RootFolder;

        public FileLookupService(IVirtualFolder rootFolder)
        {
            RootFolder = rootFolder;
        }

        public IVirtualFile GetFile(out bool couldFind, VirtualFileAddress address)
        {
            couldFind = false;
            IVirtualFile file = null;

            var gameFolder = RootFolder.SubFolders.FirstOrDefault(
                x => string.Equals(x.Name, address.Game, StringComparison.OrdinalIgnoreCase));

            var game = (GameEnum)Enum.Parse(typeof(GameEnum), address.Game, true);
            if (game == GameEnum.Exile)
            {
                file = GetExileFile(out couldFind, gameFolder, address);
            }
            else if (game == GameEnum.Revelation)
            {
                file = GetRevelationFile(out couldFind, gameFolder, address);
            }

            if(file != null)
                couldFind = true;
            return file;
        }

        public IVirtualFile GetExileFile(out bool couldFind, IVirtualFolder gameFolder, VirtualFileAddress address)
        {
            if (string.IsNullOrEmpty(address.Scene))
            {
                couldFind = false;
                return null;
            }

            var sceneName = (ExileSceneProperName)Enum.Parse(typeof(ExileSceneProperName), address.Scene, true);
            var sceneCode = ((ExileSceneCode)sceneName).ToString();

            Type type = null;
            if (sceneName == ExileSceneProperName.Amateria)
                type = typeof(ExileAmateriaZoneCode);
            else if (sceneName == ExileSceneProperName.Edanna)
                type = typeof(ExileEdannaZoneCode);
            else if (sceneName == ExileSceneProperName.Jnanin)
                type = typeof(ExileJnaninZoneCode);
            else if (sceneName == ExileSceneProperName.Narayan)
                type = typeof(ExileNarayanZoneCode);
            else if (sceneName == ExileSceneProperName.Tomahna)
                type = typeof(ExileTomahnaZoneCode);
            else if (sceneName == ExileSceneProperName.Voltaic)
                type = typeof(ExileVoltaicZoneCode);

            var zoneName = Enum.Parse(type, address.Zone, true);
            string zoneCode = zoneName.ToString();

            var fileName = sceneCode + zoneCode + "nodes.m3a";

            if(gameFolder != null)
            {
                var dataFile = gameFolder.SubFolders.FirstOrDefault(x => x.Name == fileName);

                if(dataFile != null)
                {
                    var file = dataFile.Files.FirstOrDefault(x => x.Name == address.FileName);
                    if(file!=null)
                    {
                        couldFind = true;
                        return file;
                    }
                }
            }

            couldFind = false;
            return null;
        }

        public IVirtualFile GetRevelationFile(out bool couldFind, IVirtualFolder gameFolder, VirtualFileAddress address)
        {
            var sceneName = (RevelationScene)Enum.Parse(typeof(RevelationScene), address.Scene, true);
            int sceneCode = (int)sceneName;
            string sceneCodeStr = "w" + sceneCode.ToString("D1");

            Type type = null;
            if (sceneName == RevelationScene.TomahnaNight)
                type = typeof(RevelationTomahnaZone);
            else if (sceneName == RevelationScene.Haven)
                type = typeof(RevelationHavenZone);
            else if (sceneName == RevelationScene.Spire)
                type = typeof(RevelationSpireZone);
            else if (sceneName == RevelationScene.Serenia)
                type = typeof(RevelationSereniaZone);
            else if (sceneName == RevelationScene.TomahnaDay)
                type = typeof(RevelationTomahnaZone);
            //else if (sceneName == RevelationScene.Menu)
            //    type = typeof(RevelationTomahnaZone);

            var zoneName = Enum.Parse(type, address.Zone, true);
            int zoneCode = (int)zoneName;
            string zoneCodeStr = "z" + zoneCode.ToString("D2");
            string nodeCodeStr = "n" + address.Node;

            if (gameFolder != null)
            {
                var dataFile = GetSubFolder(gameFolder, "data.m4b");
                if (dataFile != null)
                {
                    var global = GetSubFolder(dataFile, "global");
                    if (global != null)
                    {
                        var sceneFolder = GetSubFolder(global, sceneCodeStr);
                        if (sceneFolder != null)
                        {
                            var zoneFolder = GetSubFolder(sceneFolder, zoneCodeStr);
                            if (zoneFolder != null)
                            {
                                var nodeFolder = GetSubFolder(zoneFolder, nodeCodeStr);
                                if (nodeFolder != null)
                                {
                                    var filename = sceneCodeStr + zoneCodeStr + nodeCodeStr + ".m4b";
                                    var fileNameFolder = GetSubFolder(nodeFolder, filename);
                                    if (fileNameFolder != null)
                                    {
                                        var cubeFolder = GetSubFolder(fileNameFolder, "cube");
                                        if (cubeFolder != null)
                                        {
                                            var layerDefaultFolder = GetSubFolder(cubeFolder, "layer_default.m4b");
                                            if (layerDefaultFolder != null)
                                            {
                                                var setDefaultFolder = GetSubFolder(layerDefaultFolder, "set_default");
                                                if(setDefaultFolder != null)
                                                {
                                                    // finally the files
                                                    var file = setDefaultFolder.Files.FirstOrDefault(x => x.Name == address.FileName);
                                                    if (file != null)
                                                    {
                                                        couldFind = true;
                                                        return file;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            couldFind = false;
            return null;
        }

        private IVirtualFolder GetSubFolder(IVirtualFolder parentFolder, string name)
        {
            return parentFolder.SubFolders.FirstOrDefault(x => x.Name == name);
        }
    }
}
