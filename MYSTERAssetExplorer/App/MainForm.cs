using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.App
{
    public partial class MainForm : Form
    {
        MYSTERAssetExplorerApp app;
        NodeViewer viewer;
        PanoBuilder builder;

        public MainForm()
        {
            InitializeComponent();

            var uiContext = new UIContext();
            uiContext.WriteToConsole += WriteToConsole;
            uiContext.ListFiles += FillListBox;
            uiContext.PopulateNodes += FillTreeView;
            app = new MYSTERAssetExplorerApp(uiContext);

            viewer = new NodeViewer(LoadImageToViewer);
            builder = new PanoBuilder();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //viewer.Show();
        }

        private void openFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
            nodeNumber.Value = 0;
        }

        private void OpenFolder()
        {
            openFolderDialog.FileName = "Select Folder";
            openFolderDialog.CheckPathExists = true;
            openFolderDialog.ShowReadOnly = false;
            openFolderDialog.ReadOnlyChecked = true;
            openFolderDialog.CheckFileExists = false;
            openFolderDialog.ValidateNames = false;

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                app.SetWorkingDirectory(openFolderDialog.FileName);
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            //app.SortDataFiles();
        }

        private void WriteToConsole(Color color, string message)
        {
            logOutput.AppendText(message + "\r\n",color);
        }

        private void FillListBox(List<string> files)
        {
            fileListing.Items.Clear();
            fileListing.Items.AddRange(files.ToArray());
        }

        private void FillTreeView(TreeNode[] nodes)
        {
            nodeListing.Nodes.Clear();
            nodeListing.Nodes.AddRange(nodes);
        }

        private void launchNodeViewer_Click(object sender, EventArgs e)
        {
            viewer.Show();
        }

        private void LoadImageToViewer()
        {
            //string[] list = fileListing.SelectedItems.Cast<string>().ToArray();

            //// add path data so the images can be found
            //var nodeDir = ""; //app.GetWorkspace().NodeDir;
            //for(int i = 0; i<list.Length; i++)
            //    list[i] = Path.Combine(nodeDir, list[i]);

            //var imageSet = CubeMapImageSet.FillFromArray(list);
            //viewer.SetNode(imageSet);
            //app.SetCurrentSet(imageSet); // hackiness
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //app.SortDataFiles();
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            viewer.Show();
        }

        private void fileListing_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strItem;
            //foreach (string selecteditem in fileListing.SelectedItems)
            //{
            //    WriteToConsole(selecteditem);
            //}
        }

        private void nextSelectionButton_Click(object sender, EventArgs e)
        {
            NextSelection();
        }

        private void NextSelection()
        {
            //if (!Directory.Exists(app.GetWorkspace().RootDir))
            //    return;

            //var lastSelectedIndex = -1;
            //if (fileListing.SelectedItems.Count > 0)
            //{
            //    var i = fileListing.SelectedItems[fileListing.SelectedItems.Count - 1];
            //    lastSelectedIndex = fileListing.Items.IndexOf(i);
            //}

            //fileListing.SelectedItems.Clear();
            //fileListing.SelectedItems.Add(fileListing.Items[lastSelectedIndex + 1]);
            //fileListing.SelectedItems.Add(fileListing.Items[lastSelectedIndex + 2]);
            //fileListing.SelectedItems.Add(fileListing.Items[lastSelectedIndex + 3]);
            //fileListing.SelectedItems.Add(fileListing.Items[lastSelectedIndex + 4]);
            //fileListing.SelectedItems.Add(fileListing.Items[lastSelectedIndex + 5]);
            //fileListing.SelectedItems.Add(fileListing.Items[lastSelectedIndex + 6]);

            //viewer.Show();
            //viewer.ActivateLoadNode();

            //var nextNode = (int)nodeNumber.Value + 1;
            //nodeNumber.Value = nextNode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConstructPano();
        }

        private void ConstructPano()
        {
            //if (!Directory.Exists(app.GetWorkspace().PanoDir))
            //    Directory.CreateDirectory(app.GetWorkspace().PanoDir);
            //int nodeNumber = (int)this.nodeNumber.Value;
            //var panoName = panoNameInput.Text + "_" + nodeNumber.ToString("D3");

            //WriteToConsole(Color.Yellow, "Building Pano " + panoName);
            //builder.BuildPanorama(app.GetWorkspace().PanoDir, panoName, app.GetCurrentSet());
            //WriteToConsole(Color.LimeGreen, "Pano Completed!");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuickBuild();
        }

        private void QuickBuild()
        {
            NextSelection();
            ConstructPano();
        }

        private void BuildAllPanos()
        {
            int nodeCount = (fileListing.Items.Count / 6);
            int counter = 0;
            while(counter < nodeCount)
            {
                QuickBuild();
                counter++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuildAllPanos();
        }

        private void nodeListing_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void nodeListing_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void nodeListing_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = nodeListing.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = nodeListing.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }

        private void nodeListing_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void nodeListing_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = nodeListing.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            nodeListing.SelectedNode = nodeListing.GetNodeAt(targetPoint);
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            app.SaveRegistry();
        }
    }
}
