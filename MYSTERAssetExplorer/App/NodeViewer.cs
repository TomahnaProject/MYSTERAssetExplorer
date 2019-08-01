using MYSTERAssetExplorer.Core;
using MYSTERAssetExplorer.Core.Model;
using MYSTERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static MYSTERAssetExplorer.Core.CubeMapImageSet;
using static MYSTERAssetExplorer.Core.Node;

namespace MYSTERAssetExplorer.App
{
    public partial class NodeViewer : Form
    {
        public NodeViewerApp App { get; private set; }

        public NodeViewer()
        {
            InitializeComponent();

            nodeProp_ClassificationInput.DataSource = Enum.GetValues(typeof(Node.NodeType));

            App = new NodeViewerApp();
            App.PopulateNodes += PopulateNodeExplorer;
            App.PopulateImages += PopulateImages;
            App.Launch += Launch;
        }

        public void Launch()
        {
            this.Show();
            App.LoadRegistry(); ;
        }

        private void NodeViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }

        private void PopulateNodeExplorer(TreeNode[] nodes)
        {
            nodeExplorer.Nodes.Clear();
            nodeExplorer.Nodes.AddRange(nodes);
        }

        public void Populate(Node node)
        {
            if (node == null)
                return;

            PopulateFields(node);
            // load up the images
            // use extraction service to 

            PopulateImages(node);
        }

        public void WriteInputToNode(Node node)
        {
            node.Scene = nodeProp_SceneInput.Text;
            node.Zone = nodeProp_ZoneInput.Text;
            node.Number = nodeProp_NumberInput.Text;
            //NodeType type;
            //Enum.TryParse<NodeType>(nodeProp_ClassificationInput.SelectedValue.ToString(), out type);
            node.Type = (NodeType)nodeProp_ClassificationInput.SelectedValue;
            node.Rotation.Yaw = (double)nodeProp_rotationZ.Value;
            node.Position.X = (double)nodeProp_PosX.Value;
            node.Position.Y = (double)nodeProp_PosY.Value;
            node.Position.Z = (double)nodeProp_PosZ.Value;
            node.CubeMaps.DepthRange = (double)nodeProp_Depth.Value;
        }

        public void PopulateFields(Node node)
        {
            nodeProp_SceneInput.Text = node.Scene;
            nodeProp_ZoneInput.Text = node.Zone;
            nodeProp_NumberInput.Text = node.Number;
            nodeProp_ClassificationInput.SelectedItem = node.Type;
            nodeProp_rotationZ.Value = (decimal)node.Rotation.Yaw;
            nodeProp_PosX.Value = (decimal)node.Position.X;
            nodeProp_PosY.Value = (decimal)node.Position.Y;
            nodeProp_PosZ.Value = (decimal)node.Position.Z;
            nodeProp_Depth.Value = (decimal)node.CubeMaps.DepthRange;
            mapTypeColor.Select();
        }

        public void PopulateImages(Node node)
        {
            // some kind of check to validate images?
            var imageSet = node.CubeMaps.Color;

            backImage.BackgroundImage = Utils.LoadBitmapFromMemory(App.LookupFileImageData(node, imageSet.Back.File));
            bottomImage.BackgroundImage = Utils.LoadBitmapFromMemory(App.LookupFileImageData(node, imageSet.Bottom.File));
            frontImage.BackgroundImage = Utils.LoadBitmapFromMemory(App.LookupFileImageData(node, imageSet.Front.File));
            leftImage.BackgroundImage = Utils.LoadBitmapFromMemory(App.LookupFileImageData(node, imageSet.Left.File));
            rightImage.BackgroundImage = Utils.LoadBitmapFromMemory(App.LookupFileImageData(node, imageSet.Right.File));
            topImage.BackgroundImage = Utils.LoadBitmapFromMemory(App.LookupFileImageData(node, imageSet.Top.File));

            backImage.Tag = imageSet.Back.File;
            bottomImage.Tag = imageSet.Bottom.File;
            frontImage.Tag = imageSet.Front.File;
            leftImage.Tag = imageSet.Left.File;
            rightImage.Tag = imageSet.Right.File;
            topImage.Tag = imageSet.Top.File;

            fileNameLabel_Back.Text = "Back: " + imageSet.Back.File;
            fileNameLabel_Bottom.Text = "Bottom: " + imageSet.Bottom.File;
            fileNameLabel_Front.Text = "Front: " + imageSet.Front.File;
            fileNameLabel_Left.Text = "Left: " + imageSet.Left.File;
            fileNameLabel_Right.Text = "Right: " + imageSet.Right.File;
            fileNameLabel_Top.Text = "Top: " + imageSet.Top.File;
        }

        private void loadRegistry_Click(object sender, EventArgs e)
        {
            App.LoadRegistry();
        }

        private void saveRegistry_Click(object sender, EventArgs e)
        {
            App.SaveRegistry();
        }

        private void nodeExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            Node selectedNodeEntry = (Node)newSelected.Tag;
            App.SetSelectedNode(selectedNodeEntry);
            Populate(selectedNodeEntry);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (App.SelectedNode == null)
                App.SetSelectedNode(new Node());

            WriteInputToNode(App.SelectedNode);

            // temporary hack to get save to work without selecting something
            //var nodePath = nodeExplorer.SelectedNode.FullPath;
            //var gameType = nodePath.Contains("Exile") ? GameEnum.Exile : GameEnum.Revelation;

            App.AddNodeToRegistry(GameEnum.Exile, App.SelectedNode);
            App.RefreshRegistryTree();
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = nodeExplorer.SelectedNode;
            App.RefreshRegistryTree();
        }

        private void removeNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nodeExplorer.SelectedNode == null)
                return;
            if (nodeExplorer.SelectedNode.Tag is Node)
            {
                var selectedNode = (Node)nodeExplorer.SelectedNode.Tag;
                var nodePath = nodeExplorer.SelectedNode.FullPath;
                var gameType = nodePath.Contains("Exile") ? GameEnum.Exile : GameEnum.Revelation;
                App.RemoveNodeFromRegistry(gameType, selectedNode);
                App.RefreshRegistryTree();
            }
        }

        private void picturePanel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel picPanel = (Panel)sender;
            picPanel.Select();
            var imageName = (string)picPanel.Tag;

            if (!string.IsNullOrEmpty(imageName))
                picPanel.DoDragDrop(sender, DragDropEffects.Copy);
        }

        private void picturePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)) &&
                (e.AllowedEffect & DragDropEffects.Copy) != 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void picturePanel_DragDrop(object sender, DragEventArgs e)
        {
            Panel originator = (Panel)e.Data.GetData(typeof(Panel));
            Panel destination = (Panel)sender;
            string relocatingImageFileName = (string)originator.Tag;
            string displacedImageFileName = (string)destination.Tag;

            //string imageFileName = e.Data.GetData(DataFormats.Text).ToString();
            if (App.SelectedNode == null)
                return;

            // perform a swap
            var cubeFace1 = new CubeFace() { File = relocatingImageFileName };
            var cubeFace2 = new CubeFace() { File = displacedImageFileName };
            if (sender == backImage)
                App.SelectedNode.CubeMaps.Color.Back = cubeFace1;
            if (sender == bottomImage)
                App.SelectedNode.CubeMaps.Color.Bottom = cubeFace1;
            if (sender == frontImage)
                App.SelectedNode.CubeMaps.Color.Front = cubeFace1;
            if (sender == leftImage)
                App.SelectedNode.CubeMaps.Color.Left = cubeFace1;
            if (sender == rightImage)
                App.SelectedNode.CubeMaps.Color.Right = cubeFace1;
            if (sender == topImage)
                App.SelectedNode.CubeMaps.Color.Top = cubeFace1;

            if (!string.IsNullOrEmpty(displacedImageFileName))
            {
                if (originator == backImage)
                    App.SelectedNode.CubeMaps.Color.Back = cubeFace2;
                if (originator == bottomImage)
                    App.SelectedNode.CubeMaps.Color.Bottom = cubeFace2;
                if (originator == frontImage)
                    App.SelectedNode.CubeMaps.Color.Front = cubeFace2;
                if (originator == leftImage)
                    App.SelectedNode.CubeMaps.Color.Left = cubeFace2;
                if (originator == rightImage)
                    App.SelectedNode.CubeMaps.Color.Right = cubeFace2;
                if (originator == topImage)
                    App.SelectedNode.CubeMaps.Color.Top = cubeFace2;
            }

            PopulateImages(App.SelectedNode);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (App.SelectedNode == null)
                return;

            saveFileDialog.Filter = "Jpeg (*.jpg) |*.jpg";
            saveFileDialog.FileName = App.SelectedNode.GetFullName();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.ValidateNames = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                App.ExportSelectedNode(saveFileDialog.FileName);
            }
        }

        private void BatchExport(string folderPath, List<Node> nodes)
        {
            if(Directory.Exists(folderPath))
            {
                foreach (var node in nodes)
                {
                    var fileSavePath = Path.Combine(folderPath, node.GetFullName() + ".jpg");
                    App.ExportCubemap(fileSavePath, node);
                }
            }
        }

        private void extractCubemapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var s = sender;
            var type = sender.GetType();
        }

        string exportDir = "";
        private void ExportAllCubemaps_Click(object sender, EventArgs e)
        {
            var fileNameText = "Select Folder";
            openFolderDialog.FileName = fileNameText;
            openFolderDialog.CheckPathExists = true;
            openFolderDialog.ShowReadOnly = false;
            openFolderDialog.ReadOnlyChecked = true;
            openFolderDialog.CheckFileExists = false;
            openFolderDialog.ValidateNames = false;
            openFolderDialog.InitialDirectory = exportDir;

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                exportDir = openFolderDialog.FileName.Replace(fileNameText, "");
            }

            if(!string.IsNullOrEmpty(exportDir))
            {
                var nodeList = this.App.GetNodeList();
                BatchExport(exportDir, nodeList);
            }
        }


        //public void SetImage(CubeFaceEnum face, IVirtualFile file)
        //{
        //    if(CubeFaceEnum.Back)
        //        backImage.BackgroundImage = file.
        //}






        //private void nodeListing_DragDrop(object sender, DragEventArgs e)
        //{
        //    // Retrieve the client coordinates of the drop location.
        //    Point targetPoint = nodeExplorer.PointToClient(new Point(e.X, e.Y));

        //    // Retrieve the node at the drop location.
        //    TreeNode targetNode = nodeExplorer.GetNodeAt(targetPoint);

        //    // Retrieve the node that was dragged.
        //    TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

        //    // Confirm that the node at the drop location is not 
        //    // the dragged node or a descendant of the dragged node.
        //    if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
        //    {
        //        // If it is a move operation, remove the node from its current 
        //        // location and add it to the node at the drop location.
        //        if (e.Effect == DragDropEffects.Move)
        //        {
        //            draggedNode.Remove();
        //            targetNode.Nodes.Add(draggedNode);
        //        }

        //        // If it is a copy operation, clone the dragged node 
        //        // and add it to the node at the drop location.
        //        else if (e.Effect == DragDropEffects.Copy)
        //        {
        //            targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
        //        }

        //        // Expand the node at the location 
        //        // to show the dropped node.
        //        targetNode.Expand();
        //    }
        //}

        //private bool ContainsNode(TreeNode node1, TreeNode node2)
        //{
        //    // Check the parent node of the second node.
        //    if (node2.Parent == null) return false;
        //    if (node2.Parent.Equals(node1)) return true;

        //    // If the parent node is not null or equal to the first node, 
        //    // call the ContainsNode method recursively using the parent of 
        //    // the second node.
        //    return ContainsNode(node1, node2.Parent);
        //}

        //private void nodeListing_ItemDrag(object sender, ItemDragEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        DoDragDrop(e.Item, DragDropEffects.Move);
        //    }
        //}

        //private void nodeListing_DragOver(object sender, DragEventArgs e)
        //{
        //    // Retrieve the client coordinates of the mouse position.
        //    Point targetPoint = nodeExplorer.PointToClient(new Point(e.X, e.Y));

        //    // Select the node at the mouse position.
        //    nodeExplorer.SelectedNode = nodeExplorer.GetNodeAt(targetPoint);
        //}
    }
}
