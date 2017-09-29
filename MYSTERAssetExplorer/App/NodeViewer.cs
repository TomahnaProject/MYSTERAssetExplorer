using MYSTERAssetExplorer.Core;
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

namespace MYSTERAssetExplorer.App
{
    public partial class NodeViewer : Form
    {
        AssetExplorerApp app;
        public NodeViewer()
        {
            InitializeComponent();
        }

        public void RegisterWithUIContext(IUIContext uiContext)
        {
            uiContext.PopulateNodes += PopulateNodeExplorer;
        }

        public void Launch(AssetExplorerApp app)
        {
            this.Show();
            this.app = app;
            app.LoadRegistry();
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

        public void SetNode(Node node)
        {
            if (node == null)
                return;

            // load up the form with this node's data
            // load up the images
            // use extraction service to 

            SetImages(node);
        }

        public void SetImages(Node node)
        {
            // some kind of check to validate images?
            var imageSet = node.CubeMaps.Color;

            backBox.Image = Utils.LoadBitmapFromMemory(LookupFileImageData(node, imageSet.Back.File));
            bottomBox.Image = Utils.LoadBitmapFromMemory(LookupFileImageData(node, imageSet.Bottom.File));
            frontBox.Image = Utils.LoadBitmapFromMemory(LookupFileImageData(node, imageSet.Front.File));
            leftBox.Image = Utils.LoadBitmapFromMemory(LookupFileImageData(node, imageSet.Left.File));
            rightBox.Image = Utils.LoadBitmapFromMemory(LookupFileImageData(node, imageSet.Right.File));
            topBox.Image = Utils.LoadBitmapFromMemory(LookupFileImageData(node, imageSet.Top.File));

            //backBox.Image = Utils.LoadBitmapToMemory(imageSet.Back.File);
            //bottomBox.Image = Utils.LoadBitmapToMemory(imageSet.Bottom.File);
            //frontBox.Image = Utils.LoadBitmapToMemory(imageSet.Front.File);
            //leftBox.Image = Utils.LoadBitmapToMemory(imageSet.Left.File);
            //rightBox.Image = Utils.LoadBitmapToMemory( imageSet.Right.File);
            //topBox.Image = Utils.LoadBitmapToMemory(imageSet.Top.File);
        }

        private byte[] LookupFileImageData(Node node, string fileName)
        {
            var fileAddress = new VirtualFileAddress(GameEnum.Exile.ToString(), node.Scene, node.Zone, node.Number, fileName);
            var file = app.FindFile(fileAddress);
            if(file !=  null)
            {
                return app.GetDataForFile(file);
            }
            return new byte[0];
        }

        private void loadRegistry_Click(object sender, EventArgs e)
        {
            app.LoadRegistry();
        }

        private void saveRegistry_Click(object sender, EventArgs e)
        {
            app.SaveRegistry();
        }

        private void nodeExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            Node selectedCubeNode = (Node) newSelected.Tag;
            SetNode(selectedCubeNode);
        }

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
