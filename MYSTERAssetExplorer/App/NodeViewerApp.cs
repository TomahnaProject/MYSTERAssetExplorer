using MYSTERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MYSTERAssetExplorer.Core;

namespace MYSTERAssetExplorer.App
{
    public class NodeViewerApp
    {
        public AssetExplorerApp MainApp;

        RegistryManager registryManager;
        RegistryPersistenceService registryPersistence;
        RegistryTreeViewManager treeViewManager;

        public Action<TreeNode[]> PopulateNodes { get; set; }
        public Action Launch { get; set; }

        public NodeViewerApp()
        {
            registryManager = new RegistryManager();
            registryPersistence = new RegistryPersistenceService();
            treeViewManager = new RegistryTreeViewManager();
        }

        public void WriteToConsole(Color color, string message)
        {
            MainApp.WriteToConsole(color, message);
        }

        public void RefreshRegistryTree()
        {
            // PopulateNodes is null during construction, so assign the handler here before it's used
            treeViewManager.PopulateNodes += PopulateNodes;
            treeViewManager.RegenTreeView(registryManager.Registry);
        }

        public void LoadRegistry()
        {
            WriteToConsole(Color.Orange, "Loading Registry...");
            var registry = registryPersistence.GetRegistryFromDisk();
            registryManager.Registry = registry;
            RefreshRegistryTree();
            WriteToConsole(Color.Green, "Registry Loaded Successfully!");
        }

        public void SaveRegistry()
        {
            WriteToConsole(Color.Orange, "Saving Registry...");
            registryPersistence.SaveRegistryToDisk(registryManager.Registry);
            WriteToConsole(Color.Green, "Registry Saved!");
        }

        internal IVirtualFile FindFile(VirtualFileAddress fileAddress)
        {
            return MainApp.FindFile(fileAddress);
        }

        internal byte[] GetDataForFile(IVirtualFile file)
        {
            return MainApp.GetDataForFile(file);
        }
    }
}
