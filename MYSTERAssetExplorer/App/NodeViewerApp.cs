using MYSTERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MYSTERAssetExplorer.Core;
using MYSTERAssetExplorer.Core.Model;
using System.IO;

namespace MYSTERAssetExplorer.App
{
    public class NodeViewerApp
    {
        public AssetExplorerApp MainApp;

        RegistryManager registryManager;
        RegistryPersistenceService registryPersistence;
        RegistryTreeViewManager treeViewManager;
        CubeMapBuilder panoBuilder = new CubeMapBuilder();

        public Node SelectedNode { get; private set; }

        public Action<TreeNode[]> PopulateNodes { get; set; }
        public Action<Node> PopulateImages { get; set; }
        public Action<CubeFaceEnum, IVirtualFile> SetImage { get; set; }
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
        public void SetSelectedNode(Node node)
        {
            SelectedNode = node;
        }

        public byte[] LookupFileImageData(Node node, string fileName)
        {
            var fileAddress = new VirtualFileAddress(GameEnum.Exile.ToString(), node.Scene, node.Zone, node.Number, fileName);
            var file = FindFile(fileAddress);
            if (file != null)
            {
                var imageData = GetDataForFile(file);
                return imageData;
            }
            return new byte[0];
        }

        public void ExportSelectedNode(string fileSavePath)
        {
            ExportCubemap(fileSavePath, SelectedNode);
        }

        public CubemapImages GetCubemapImagesForImageSet(Node node, CubeMapImageSet imageSet)
        {
            var data = new CubemapImages();
            data.Back = Utils.LoadBitmapFromMemory(this.LookupFileImageData(node, imageSet.Back.File));
            data.Bottom = Utils.LoadBitmapFromMemory(this.LookupFileImageData(node, imageSet.Bottom.File));
            data.Front = Utils.LoadBitmapFromMemory(this.LookupFileImageData(node, imageSet.Front.File));
            data.Left = Utils.LoadBitmapFromMemory(this.LookupFileImageData(node, imageSet.Left.File));
            data.Right = Utils.LoadBitmapFromMemory(this.LookupFileImageData(node, imageSet.Right.File));
            data.Top = Utils.LoadBitmapFromMemory(this.LookupFileImageData(node, imageSet.Top.File));
            return data;
        }

        public void ExportCubemap(string fileSavePath, Node node)
        {
            var imageSet = node.CubeMaps.Color;
            CubemapImages images = GetCubemapImagesForImageSet(node, imageSet);

            Bitmap cubemap = new CubeMapBuilder().ConstructCubemap(images);
            ImageSaveService.Save(fileSavePath, cubemap);
        }

        public void AddNodeToRegistry(GameEnum game, Node node)
        {
            registryManager.AddNode(game, node);
        }

        public void RemoveNodeFromRegistry(GameEnum game, Node node)
        {
            registryManager.RemoveNode(game, node);
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

        internal void ReceiveImages(string game, string scene, string zone, List<IVirtualFile> files)
        {
            SelectedNode = new Node();
            SelectedNode.Scene = scene;
            SelectedNode.Zone = zone;

            if (files.Count > 5)
                SelectedNode.CubeMaps.Color.Top.File = files[5].Name;
            if (files.Count > 4)
                SelectedNode.CubeMaps.Color.Right.File = files[4].Name;
            if (files.Count > 3)
                SelectedNode.CubeMaps.Color.Left.File = files[3].Name;
            if (files.Count > 2)
                SelectedNode.CubeMaps.Color.Front.File = files[2].Name;
            if (files.Count > 1)
                SelectedNode.CubeMaps.Color.Bottom.File = files[1].Name;
            if (files.Count > 0)
                SelectedNode.CubeMaps.Color.Back.File = files[0].Name;

            PopulateImages(SelectedNode);
        }

        internal List<Node> GetNodeList()
        {
            var list = new List<Node>();
            list.AddRange(registryManager.Registry.Exile.Nodes);
            list.AddRange(registryManager.Registry.Revelation.Nodes);
            return list;
        }

        // for setting images from here

        //if (files.Count > 0)
        //    SetImage(CubeFaceEnum.Back, files[0]);
        //else if (files.Count > 1)
        //    SetImage(CubeFaceEnum.Bottom, files[1]);
        //else if (files.Count > 2)
        //    SetImage(CubeFaceEnum.Front, files[2]);
        //else if (files.Count > 3)
        //    SetImage(CubeFaceEnum.Left, files[3]);
        //else if (files.Count > 4)
        //    SetImage(CubeFaceEnum.Right, files[4]);
        //else if (files.Count > 5)
        //    SetImage(CubeFaceEnum.Top, files[5]);
    }
}
