using MYSTERAssetExplorer.App;
using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public class RegistryPersistenceService
    {
        const string templateRegistryXML = @"<AssetRegistry><Nodes /></AssetRegistry>";

        const string regDir = "RegistryFiles";
        string exileRegistryFilePath = Path.Combine(regDir, "ExileAssetRegistry.xml");
        string revelationRegistryFilePath = Path.Combine(regDir, "RevelationAssetRegistry.xml");

        public GameRegistry GetRegistryFromDisk()
        {
            var registry = new GameRegistry();
            registry.Exile = LoadRegistryFile(exileRegistryFilePath);
            registry.Revelation = LoadRegistryFile(revelationRegistryFilePath);
            return registry;
        }

        public void SaveRegistryToDisk(GameRegistry registry)
        {
            SaveRegistryFile(exileRegistryFilePath, registry.Exile);
            SaveRegistryFile(revelationRegistryFilePath, registry.Revelation);
        }

        private AssetRegistry LoadRegistryFile(string filePath)
        {
            if (!Directory.Exists(regDir))
                Directory.CreateDirectory(regDir);

            var registryText = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(registryText))
            {
                File.WriteAllText(filePath, templateRegistryXML);
                registryText = templateRegistryXML;
            }

            var serializationService = new AssetRegistrySerializationService();
            var assetRegistry = serializationService.DeserializeRegistry(registryText);

            return assetRegistry;
        }

        private void SaveRegistryFile(string filePath, AssetRegistry registry)
        {
            var serializer = new AssetRegistrySerializationService();
            var registryText = serializer.SerializeRegistry(registry);
            File.WriteAllText(filePath, registryText);
        }
    }
}
