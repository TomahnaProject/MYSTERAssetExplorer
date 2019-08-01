using MYSTERAssetExplorer.App;
using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public class RegistryPersistenceService
    {
        const string templateRegistryXML = @"<AssetRegistry><Nodes /></AssetRegistry>";

        const string regDir = "RegistryFiles";
        const string EXILE_REGISTRY_FILENAME = "ExileAssetRegistry.xml";
        const string REVELATION_REGISTRY_FILENAME = "RevelationAssetRegistry.xml";
        string exileRegistryFilePath = Path.Combine(regDir, EXILE_REGISTRY_FILENAME);
        string revelationRegistryFilePath = Path.Combine(regDir, REVELATION_REGISTRY_FILENAME);

        public GameRegistry GetDefaultRegistry()
        {
            var exileReg = GetEmbeddedResource(EXILE_REGISTRY_FILENAME);
            var revelationReg = GetEmbeddedResource(REVELATION_REGISTRY_FILENAME);

            var registry = new GameRegistry();
            registry.Exile = DeserializeRegistry(exileReg);
            registry.Revelation = DeserializeRegistry(revelationReg);
            return registry;
        }

        private string GetEmbeddedResource(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();

            string resourceName = assembly.GetManifestResourceNames()
              .Single(str => str.EndsWith(resource));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

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
            EnsureRegistryFolderExists();
            var registryText = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(registryText))
            {
                File.WriteAllText(filePath, templateRegistryXML);
                registryText = templateRegistryXML;
            }

            return DeserializeRegistry(registryText);
        }

        private AssetRegistry DeserializeRegistry(string registryText)
        {
            var serializationService = new AssetRegistrySerializationService();
            var assetRegistry = serializationService.DeserializeRegistry(registryText);
            return assetRegistry;
        }

        private void SaveRegistryFile(string filePath, AssetRegistry registry)
        {
            EnsureRegistryFolderExists();
            var serializer = new AssetRegistrySerializationService();
            var registryText = serializer.SerializeRegistry(registry);
            File.WriteAllText(filePath, registryText);
        }

        private void EnsureRegistryFolderExists()
        {
            if (!Directory.Exists(regDir))
                Directory.CreateDirectory(regDir);
        }
    }
}
