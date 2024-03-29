﻿using ArchiveSystem.VirtualFileSystem;
using MYSTER.Core;
using System;
using System.Linq;

namespace MYSTER.Services
{
    public class FileLookupService
    {
        IVirtualFolder RootFolder;

        public FileLookupService(IVirtualFolder rootFolder)
        {
            RootFolder = rootFolder;
        }

        public IVirtualFileEntry GetFile(out bool couldFind, VirtualFileAddress address)
        {
            couldFind = false;
            IVirtualFileEntry file = null;

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

        public IVirtualFileEntry GetExileFile(out bool couldFind, IVirtualFolder gameFolder, VirtualFileAddress address)
        {
            if (string.IsNullOrEmpty(address.Scene))
            {
                couldFind = false;
                return null;
            }

            ExileSceneCode sceneCode;
            ExileSceneProperName scene;

            if (address.Scene.Length < 3)
            {
                // verify it's proper scenecode
                sceneCode = (ExileSceneCode) Enum.Parse(typeof(ExileSceneCode), address.Scene, true);
                scene = (ExileSceneProperName)sceneCode;
            }
            else
            {
                // get the scenecode from the proper name
                scene = (ExileSceneProperName)Enum.Parse(typeof(ExileSceneProperName), address.Scene, true);
                sceneCode = (ExileSceneCode)scene;
            }

            Type type = null;
            if (scene == ExileSceneProperName.Amateria)
                type = typeof(ExileAmateriaZoneCode);
            else if (scene == ExileSceneProperName.Edanna)
                type = typeof(ExileEdannaZoneCode);
            else if (scene == ExileSceneProperName.Jnanin)
                type = typeof(ExileJnaninZoneCode);
            else if (scene == ExileSceneProperName.Narayan)
                type = typeof(ExileNarayanZoneCode);
            else if (scene == ExileSceneProperName.Tomahna)
                type = typeof(ExileTomahnaZoneCode);
            else if (scene == ExileSceneProperName.Voltaic)
                type = typeof(ExileVoltaicZoneCode);

            var zoneName = Enum.Parse(type, address.Zone, true);
            string zoneCode = zoneName.ToString();

            var fileName = sceneCode + zoneCode + "nodes.m3a";

            if(gameFolder != null)
            {
                var dataFile = gameFolder.SubFolders.FirstOrDefault(x => x.Name == fileName);

                if(dataFile != null)
                {
                    var file = dataFile.Files.FirstOrDefault(x => x.FileName == address.FileName);
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

        public IVirtualFileEntry GetRevelationFile(out bool couldFind, IVirtualFolder gameFolder, VirtualFileAddress address)
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
                                            IVirtualFolder layerDefaultFolder;
                                            if (address.FileName.Contains("_depth"))
                                                layerDefaultFolder = GetSubFolder(cubeFolder, "z_layer_default.m4b");
                                            else
                                                layerDefaultFolder = GetSubFolder(cubeFolder, "layer_default.m4b");
                                            if (layerDefaultFolder != null)
                                            {
                                                var setDefaultFolder = GetSubFolder(layerDefaultFolder, "set_default");
                                                if(setDefaultFolder != null)
                                                {
                                                    var fileName = address.FileName.Replace(".jpg","").Replace("_depth", "");
                                                    // finally the files
                                                    var file = setDefaultFolder.Files.FirstOrDefault(x => x.FileName == fileName);

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
