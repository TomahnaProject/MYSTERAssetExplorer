using ArchiveSystem.VirtualFileSystem;
using MYSTER.Core;
using MYSTER.Core.Utils;
using MYSTER.Services;
using MYSTER.Services.Utils;
using MYSTERAssetExplorer.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.App
{
    public partial class AssetExplorer : Form
    {
        AssetExplorerApp app;
        CubeMapBuilder builder;

        bool filterSmallImages = false;

        public AssetExplorer()
        {
            InitializeComponent();
            this.assetExplorerMenuStrip.Renderer = new BorderlessToolstripRenderer();

            previewPanel.Tag = "";
            previewPanel.BackgroundImage = Properties.Resources.picture_icon_large;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " (ver " + GetVersion() + ")";
            ApplicationEntryBootstrap();
        }

        public void ApplicationEntryBootstrap()
        {
            var nodeViewer = new NodeViewer();
            var nodeApp = nodeViewer.App;

            app = new AssetExplorerApp();
            app.WriteToConsole += WriteToConsole;
            app.ListFiles += FillListView;
            app.PopulateFolders += PopulateFolderExplorer;

            // very important, swap references so they can communicate
            app.NodeApp = nodeApp;
            nodeApp.MainApp = app;
        }

        private void openFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void OpenFolder()
        {
            openFolderDialog.FileName = "Select Folder";
            openFolderDialog.CheckPathExists = true;
            openFolderDialog.ShowReadOnly = false;
            openFolderDialog.ReadOnlyChecked = true;
            openFolderDialog.CheckFileExists = false;
            openFolderDialog.ValidateNames = false;
            openFolderDialog.InitialDirectory = app.GetDataDirectory();

            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                app.SetDataDirectory(openFolderDialog.FileName);
            }
        }

        private void WriteToConsole(Color color, string message)
        {
            Invoke(new Action(() =>
            {
                logOutput.AppendText(message + "\r\n", color);
            }));
        }

        private void FillListView(List<IVirtualFileEntry> files)
        {
            fileExplorer.Items.Clear();

            foreach (var file in files)
            {
                var item = new ListViewItem(file.Name, 1);
                var subItems = new ListViewItem.ListViewSubItem[]
                {
                    //new ListViewItem.ListViewSubItem(item, (file.End - file.Start).ToString()),
                    //new ListViewItem.ListViewSubItem(item, file.Start.ToString())
                };

                item.SubItems.AddRange(subItems);
                fileExplorer.Items.Add(item);
            }
        }

        private void launchNodeViewer_Click(object sender, EventArgs e)
        {
            app.LaunchNodeViewer();
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            //app.SaveRegistry();
            //todo check if everything went okay
            MessageBox.Show("registry changes have been saved");
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MYSTER Asset Explorer");
            sb.AppendLine("Version " + GetVersion());
            sb.AppendLine("Release Date 4/15/2020");
            sb.AppendLine();
            sb.AppendLine("A utility to view and extract assets of Myst 3 Exile, and Myst 4 Revelation.");
            sb.AppendLine("Created by James Thomas");
            sb.AppendLine();
            sb.AppendLine("Released under the MIT license.");
            sb.AppendLine("Get the source code:");
            sb.AppendLine("https://github.com/julyfortoday/MYSTERAssetExplorer");

            MessageBox.Show(sb.ToString());
        }

        private string GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            var message = "You must select a folder containing .m3a and .m4b files.\r\n";
            message += "The app will show assets from whatever data files are available in that folder.\r\n";

            message += "\r\nThe app comes with a registry that maps the various asset files contained within the data files";
            message += " to the various nodes.\r\n";
            message += "\r\nAlterations to this registry can be saved, and loaded in subsequent sessions.\r\n";
            MessageBox.Show(message);
        }

        private string game = "";
        private string scene = "";
        private string zone = "";

        private void SetLocation(TreeNode node)
        {
            var level1 = node;
            var level2 = node;
            while (level1.Parent != null)
            {
                level2 = level1;
                level1 = level1.Parent;
            }
            var level1Name = level1.Text;
            var level2Name = level2.Text;

            game = level1Name;
            if (level1Name != level2Name)
            {
                if (level2Name.Length > 3)
                {
                    scene = level2Name.Substring(0, 2);
                    zone = level2Name.Substring(2, 2);
                }
            }
        }

        private void nodeExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            fileExplorer.Items.Clear();
            IVirtualFolder nodeFolderInfo = (IVirtualFolder)newSelected.Tag;

            SetLocation(newSelected);

            ListFolders(nodeFolderInfo);
            ListFiles(nodeFolderInfo);
            //fileExplorer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ListFolders(IVirtualFolder nodeFolderInfo)
        {
            foreach (IVirtualFolder folder in nodeFolderInfo.SubFolders)
            {
                ListViewItem item = null;
                ListViewItem.ListViewSubItem[] subItems;
                if (folder == null)
                    continue;

                item = new ListViewItem(folder.Name, 0);
                item.Tag = folder;
                if (folder.Name.CaseInsensitiveContains(app.M4B_FileExtension))
                    item.ImageIndex = (int)FileType.M4B;
                else if (folder.Name.Contains(app.M3A_FileExtension))
                    item.ImageIndex = (int)FileType.M3A;
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(item, ""),
                };

                item.SubItems.AddRange(subItems);
                fileExplorer.Items.Add(item);
            }
        }

        private void ListFiles(IVirtualFolder nodeFolderInfo)
        {
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            bool isSmallImage = true;

            foreach (var file in nodeFolderInfo.Files)
            {
                isSmallImage = true;
                item = new ListViewItem(file.Name, (int)file.FileData.Type);
                item.Tag = file;

                if (file.FileData is VirtualFileDataInArchive)
                {
                    var archiveIndex = file.FileData as VirtualFileDataInArchive;
                    var fileSizeInBytes = archiveIndex.End - archiveIndex.Start;
                    subItems = new ListViewItem.ListViewSubItem[]
                    {
                        new ListViewItem.ListViewSubItem(item, FormatUtils.GetBytesReadable(fileSizeInBytes)),
                        new ListViewItem.ListViewSubItem(item, "(" + archiveIndex.Start + ", " + archiveIndex.End +")")
                    };

                    // using a size cutoff for now, not reliable, but useful
                    // anything below 20KB is filtered out
                    // (I've never seen a cube face size fall below 30KB+)
                    isSmallImage = fileSizeInBytes < 20000;
                }
                else if (file.FileData is VirtualFileTiledImage)
                {
                    isSmallImage = false;
                    item.ImageIndex = 9;
                    var tiledImage = file.FileData as VirtualFileTiledImage;
                    subItems = new ListViewItem.ListViewSubItem[]
                    {
                        new ListViewItem.ListViewSubItem(item, ""),
                        new ListViewItem.ListViewSubItem(item, tiledImage.Tiles.Count().ToString() + " images")
                    };
                }
                else
                {
                    subItems = new ListViewItem.ListViewSubItem[0];
                }

                if (filterSmallImages)
                    if (isSmallImage)
                        continue;

                item.SubItems.AddRange(subItems);
                fileExplorer.Items.Add(item);
            }
        }

        private void PopulateFolderExplorer(List<IVirtualFolder> folders)
        {
            folders.Sort((x, y) => string.Compare(x.Name, y.Name));

            Invoke(new Action(() =>
            {
                folderExplorer.Nodes.Clear();
                foreach (var folder in folders)
                {
                    if (folder != null)
                    {
                        var folderNode = new TreeNode(folder.Name, 0, 1);
                        folderNode.Tag = folder;
                        BuildTreeNode(folderNode, folder.SubFolders);
                        folderExplorer.Nodes.Add(folderNode);
                    }
                }
            }));
        }

        private void BuildTreeNode(TreeNode nodeToAddTo, List<IVirtualFolder> subFolders)
        {
            subFolders.Sort((x, y) => string.Compare(x.Name, y.Name));

            TreeNode childNode;
            List<IVirtualFolder> subSubFolders;
            int iconIndex = 0;
            int selecedIndex = 0;
            foreach (var subFolder in subFolders)
            {
                if (subFolder == null)
                {
                    continue;
                }

                if (subFolder.Name.CaseInsensitiveContains(app.M4B_FileExtension))
                {
                    iconIndex = (int)FileType.M4B;
                    selecedIndex = iconIndex;
                }
                else if (subFolder.Name.CaseInsensitiveContains(app.M3A_FileExtension))
                {
                    iconIndex = (int)FileType.M3A;
                    selecedIndex = iconIndex;
                }
                else
                {
                    // normal folder
                    iconIndex = 0;
                    selecedIndex = 1;
                }
                childNode = new TreeNode(subFolder.Name, iconIndex, selecedIndex);
                childNode.Tag = subFolder;

                if (subFolder is VirtualFolder)
                {
                    subSubFolders = (subFolder as VirtualFolder).SubFolders;
                    if (subSubFolders.Count != 0)
                    {
                        BuildTreeNode(childNode, subSubFolders);
                    }
                    nodeToAddTo.Nodes.Add(childNode);
                }
            }
        }

        private void extractFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UseDialogToExtractFolder();
        }

        private void UseDialogToExtractFolder()
        {
            extractFileDialog.InitialDirectory = app.GetExtractionDirectory();
            extractFileDialog.FileName = "SelectedFolder";
            extractFileDialog.Title = "Save Folder";
            if (extractFileDialog.ShowDialog() == DialogResult.OK)
            {
                var extractionPath = Path.GetDirectoryName(extractFileDialog.FileName);
                app.SetExtractionDirectory(extractionPath);

                if (extractionPath.Length < 1)
                {
                    MessageBox.Show("leave a name in the filename field (doesn't matter what, it won't be used)");
                    return;
                }
                ExtractFolder(extractionPath);

            }
        }

        private void ExtractFolder(string savePath)
        {
            var node = folderExplorer.SelectedNode;
            if (node.Tag is IVirtualFolder)
            {
                var folder = node.Tag as IVirtualFolder;

                WriteToConsole(Color.LightBlue, "Extracting folder '" + folder.Name + "' to " + savePath);
                app.ExtractFolder(savePath, folder);
            }
        }

        private void extractSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UseDialogToExtractSelectedFiles();
        }

        private void UseDialogToExtractSelectedFiles()
        {
            extractFileDialog.InitialDirectory = app.GetExtractionDirectory();
            extractFileDialog.FileName = "SelectedFiles";
            extractFileDialog.Title = "Save Files";
            if (extractFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extractionPath = Path.GetDirectoryName(extractFileDialog.FileName);
                app.SetExtractionDirectory(extractionPath);

                if (extractionPath.Length < 1)
                {
                    MessageBox.Show("leave a name in the filename field (doesn't matter what, it won't be used)");
                    return;
                }
                ExtractSelectedFiles(extractionPath);
            }
        }

        private void ExtractSelectedFiles(string savePath)
        {
            WriteToConsole(Color.LightBlue, "Extracting Selected Files to " + savePath);

            List<IVirtualFileEntry> files = new List<IVirtualFileEntry>();

            foreach (ListViewItem item in fileExplorer.SelectedItems)
            {
                if (item.Tag is IVirtualFileEntry)
                {
                    files.Add(item.Tag as IVirtualFileEntry);
                }
            }
            app.ExtractFiles(savePath, files);
        }

        private void fileExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 1)
            {
                ListViewItem selected = fileExplorer.SelectedItems[0];
                if (selected.Tag is VirtualFolder)
                    return;

                HandleNewlySelectedItem(selected);
            }
            else
            {
                previewPanel.Tag = "";
                previewPanel.BackgroundImage = Properties.Resources.picture_icon_large;
            }
        }

        private void HandleNewlySelectedItem(ListViewItem selected)
        {
            if (!(selected.Tag is IVirtualFileEntry))
                return;

            var file = selected.Tag as IVirtualFileEntry;

            if ((file.FileData.Type == FileType.Jpg ||
                file.FileData.Type == FileType.Zap))
            {
                var imageData = app.GetDataForFile(file);
                SetImageDataIntoPreviewWindow(selected.Text, imageData);
            }
            else if (file.FileData.Type == FileType.Bink)
            {
                //var videoData = app.GetDataForFile(file);
                // PLAY VIDEO ONCE YOU HAVE MEDIA PLAYER
            }
            else if (file.FileData.Type == FileType.Unknown)
            {
                // AUDIO EVENTUALLY
            }
        }

        private void SetImageDataIntoPreviewWindow(string imageName, byte[] imageData)
        {
            try
            {
                Bitmap bmp = BitmapUtils.LoadBitmapFromMemory(imageData);
                previewPanel.BackgroundImage = bmp;
                previewPanel.Tag = imageName;
            }
            catch (Exception ex)
            {
                previewPanel.Tag = "";
                previewPanel.BackgroundImage = Properties.Resources.picture_icon_large;
                WriteToConsole(Color.Red, "ERROR: '" + imageName + "' could not be shown ( " + ex.Message + " )");
            }
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderExplorer.CollapseAll();
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //folderExplorer.ExpandAll(); // doesn't work well with rev's big data file
        }

        private void nodeExplorer_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == 0)
                e.Node.ImageIndex = 1;
        }

        private void nodeExplorer_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == 1)
                e.Node.ImageIndex = 0;
        }

        private void FindFileButton_Click(object sender, EventArgs e)
        {
            app.FindFile();
        }

        private void fileExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                fileExplorer.MultiSelect = true;
                foreach (ListViewItem item in fileExplorer.Items)
                {
                    item.Selected = true;
                }
            }
        }

        private void startDrag_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.Select();
            var imageName = (string)c.Tag;
            if (!string.IsNullOrEmpty(imageName))
            {
                c.DoDragDrop(imageName, DragDropEffects.Copy);
            }
            imageName = (string)previewPanel.Tag;
            if (!string.IsNullOrEmpty(imageName))
            {
                c.DoDragDrop(imageName, DragDropEffects.Copy);
            }
        }

        private void sendToNodeViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<IVirtualFileEntry> files = new List<IVirtualFileEntry>();

            foreach (ListViewItem item in fileExplorer.SelectedItems)
            {
                if (item.Tag is IVirtualFileEntry)
                {
                    files.Add(item.Tag as IVirtualFileEntry);
                }
            }

            app.SendImagesToNodeViewer(game, scene, zone, files);
        }

        private void filterSmallImages_CheckedChanged(object sender, EventArgs e)
        {
            filterSmallImages = filterSmallImagesCheckbox.Checked;
        }
    }
}
