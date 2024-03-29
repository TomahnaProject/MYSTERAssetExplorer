﻿using MYSTER.Core;
using MYSTER.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.App
{
    public partial class NodeViewer : Form
    {
        public NodeViewerApp App { get; private set; }

        public NodeViewer()
        {
            InitializeComponent();
            this.nodeViewerMenuStrip.Renderer = new BorderlessToolstripRenderer();

            nodeProp_ClassificationInput.DataSource = Enum.GetValues(typeof(NodeType));

            App = new NodeViewerApp();
            App.PopulateNodes += PopulateNodeExplorer;
            App.PopulateImages += PopulateImages;
            App.Launch += Launch;
        }

        public void Launch()
        {
            this.Show();
            App.LoadDefaultRegistry(); ;
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
            node.Yaw = (double)nodeProp_rotationZ.Value;
            node.X = (double)nodeProp_PosX.Value;
            node.Y = (double)nodeProp_PosY.Value;
            node.Z = (double)nodeProp_PosZ.Value;
            node.Depth = (double)nodeProp_Depth.Value;
        }

        public void PopulateFields(Node node)
        {
            nodeProp_SceneInput.Text = node.Scene;
            nodeProp_ZoneInput.Text = node.Zone;
            nodeProp_NumberInput.Text = node.Number;
            nodeProp_ClassificationInput.SelectedItem = node.Type;
            nodeProp_rotationZ.Value = (decimal)node.Yaw;
            nodeProp_PosX.Value = (decimal)node.X;
            nodeProp_PosY.Value = (decimal)node.Y;
            nodeProp_PosZ.Value = (decimal)node.Z;
            nodeProp_Depth.Value = (decimal)node.Depth;
            mapTypeColor.Select();
        }

        public void PopulateImages(Node node)
        {
            if (node == null)
                return;
            CubeMapImageSet imageSet = node.CubeMap;

            //if (mapTypeIsColor == true)
            //    imageSet = node.CubeMap;
            //else
            //    imageSet = node.CubeMaps.Depth;

            // some kind of check to validate images?
            CubemapImages data = App.GetCubemapImagesForImageSet(node, imageSet);

            var blank = Properties.Resources.picture_icon_large;
            backImage.BackgroundImage = data.Back != null ? data.Back : blank;
            bottomImage.BackgroundImage = data.Bottom != null ? data.Bottom : blank;
            frontImage.BackgroundImage = data.Front != null ? data.Front : blank;
            leftImage.BackgroundImage = data.Left != null ? data.Left : blank;
            rightImage.BackgroundImage = data.Right != null ? data.Right : blank;
            topImage.BackgroundImage = data.Top != null ? data.Top : blank;

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
            openFolderDialog.Filter = "Registry File (*.xml) |*.xml";
            openFolderDialog.CheckPathExists = true;
            openFolderDialog.CheckFileExists = false;
            openFolderDialog.ValidateNames = false;

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                App.LoadCustomRegistry(openFolderDialog.FileName);
            }
        }

        private void saveRegistry_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(App.SelectedGame))
                return;

            saveFileDialog.Filter = "Registry File (*.xml) |*.xml";
            saveFileDialog.FileName = App.SelectedGame;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.ValidateNames = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                App.SaveCustomRegistry(App.SelectedGame, saveFileDialog.FileName);
            }
        }

        private void nodeExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            TreeNode current = newSelected;
            while (current.Parent != null)
            {
                current = current.Parent;
            }
            App.SetSelectedGame(current.Text);

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
            var panel = (Panel)e.Data.GetData(typeof(Panel));
            var str = (String)e.Data.GetData(typeof(String));

            if (panel == null && str == null)
                return;

            Panel originator = null;
            string relocatingImageFileName = "";
            if (str != null)
            {
                relocatingImageFileName = str;
            }
            else
            {
                originator = (Panel)e.Data.GetData(typeof(Panel));
                relocatingImageFileName = (string)originator.Tag;
            }

            Panel destination = (Panel)sender;
            string displacedImageFileName = (string)destination.Tag;

            //string imageFileName = e.Data.GetData(DataFormats.Text).ToString();
            if (App.SelectedNode == null)
                return;

            // perform a swap
            var cubeFace1 = new CubeMapFace() { File = relocatingImageFileName };
            var cubeFace2 = new CubeMapFace() { File = displacedImageFileName };
            if (sender == backImage)
                App.SelectedNode.CubeMap.Back = cubeFace1;
            if (sender == bottomImage)
                App.SelectedNode.CubeMap.Bottom = cubeFace1;
            if (sender == frontImage)
                App.SelectedNode.CubeMap.Front = cubeFace1;
            if (sender == leftImage)
                App.SelectedNode.CubeMap.Left = cubeFace1;
            if (sender == rightImage)
                App.SelectedNode.CubeMap.Right = cubeFace1;
            if (sender == topImage)
                App.SelectedNode.CubeMap.Top = cubeFace1;

            if (originator != null)
                if (!string.IsNullOrEmpty(displacedImageFileName))
                {
                    if (originator == backImage)
                        App.SelectedNode.CubeMap.Back = cubeFace2;
                    if (originator == bottomImage)
                        App.SelectedNode.CubeMap.Bottom = cubeFace2;
                    if (originator == frontImage)
                        App.SelectedNode.CubeMap.Front = cubeFace2;
                    if (originator == leftImage)
                        App.SelectedNode.CubeMap.Left = cubeFace2;
                    if (originator == rightImage)
                        App.SelectedNode.CubeMap.Right = cubeFace2;
                    if (originator == topImage)
                        App.SelectedNode.CubeMap.Top = cubeFace2;
                }

            PopulateImages(App.SelectedNode);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (App.SelectedNode == null)
                return;

            var fileNameStart = App.SelectedNode.GetFullName();
            fileNameStart += GetImageFileNameTagForNode(App.SelectedNode);

            if (App.SelectedGame == "Revelation" && (!App.MapTypeColorSelected))
            {
                fileNameStart += "[depth]";
            }

            saveFileDialog.Filter = "PNG (*.png)|*.png|Jpeg (*.jpg) |*.jpg";
            saveFileDialog.FileName = fileNameStart;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.ValidateNames = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                App.ExportSelectedNode(saveFileDialog.FileName, separateImagesCheckbox.Checked, sphericalProjection.Checked);
            }
        }

        private string GetImageFileNameTagForNode(Node node)
        {
            string tag = "[cube]";
            if (separateImagesCheckbox.Checked)
                tag = "[face]";
            else if (sphericalProjection.Checked)
                tag = "[sphere]";
            return tag;
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
            openFolderDialog.Filter = "Png (*.png) |*.png";
            openFolderDialog.FileName = fileNameText;
            openFolderDialog.CheckPathExists = true;
            openFolderDialog.ShowReadOnly = false;
            openFolderDialog.ReadOnlyChecked = true;
            openFolderDialog.CheckFileExists = false;
            openFolderDialog.ValidateNames = false;
            openFolderDialog.InitialDirectory = exportDir;

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                exportDir = Path.GetDirectoryName(openFolderDialog.FileName.Replace(fileNameText, ""));
            }

            if (!string.IsNullOrEmpty(exportDir))
            {
                App.BatchExport(exportDir, sphericalProjection.Checked);
            }
        }

        private void mapTypeColor_CheckedChanged(object sender, EventArgs e)
        {
            if (mapTypeColor.Checked)
                App.MapTypeColorSelected = true;
            else
                App.MapTypeColorSelected = false;

            PopulateImages(App.SelectedNode);
        }

        private void separateImagesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (separateImagesCheckbox.Checked)
            {
                sphericalProjection.Checked = false;
                sphericalProjection.Enabled = false;
            }
            else
            {
                sphericalProjection.Checked = false;
                sphericalProjection.Enabled = true;
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
