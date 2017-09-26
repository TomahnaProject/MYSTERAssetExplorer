using MYSTERAssetExplorer.Core;
using MYSTERAssetExplorer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        AssetExplorerApp app;
        NodeViewer viewer;
        PanoBuilder builder;

        public MainForm()
        {
            InitializeComponent();
            previewWindow.InitialImage = Properties.Resources.picture_icon_large;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var uiContext = new UIContext();
            uiContext.WriteToConsole += WriteToConsole;
            uiContext.ListFiles += FillListView;
            //uiContext.PopulateNodes += PopulateNodeExplorer;
            uiContext.PopulateFolders += PopulateFolderExplorer;
            app = new AssetExplorerApp(uiContext);

            viewer = new NodeViewer(LoadImageToViewer);
            builder = new PanoBuilder();

            //viewer.Show();
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

        private void FillListView(List<VirtualFileIndex> files)
        {
            fileExplorer.Items.Clear();

            foreach(var file in files)
            {
                var item = new ListViewItem(file.Name, 1);
                var subItems = new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(item, (file.End - file.Start).ToString()),
                    new ListViewItem.ListViewSubItem(item, file.Start.ToString())
                };

                item.SubItems.AddRange(subItems);
                fileExplorer.Items.Add(item);
            }
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            app.SaveRegistry();
            //todo check if everything went okay
            MessageBox.Show("registry changes have been saved");
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Utility used to view and extract assets of Myst 3 Exile, and Myst 4 Revelation.\r\nCreated in 2017 by James Thomas");
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

        private void folderExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            fileExplorer.Items.Clear();
            VirtualFolder nodeFolderInfo = (VirtualFolder)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (VirtualFolder folder in nodeFolderInfo.SubFolders)
            {
                if (folder == null)
                    continue;

                item = new ListViewItem(folder.Name, 0);
                item.Tag = folder;
                if (folder.Name.Contains(".m4b"))
                    item.ImageIndex = (int)FileType.M4B;
                else if (folder.Name.Contains(".m3a"))
                    item.ImageIndex = (int)FileType.M3A;
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    //new ListViewItem.ListViewSubItem(item, "Folder"),
                    new ListViewItem.ListViewSubItem(item, ""),
                };

                item.SubItems.AddRange(subItems);
                fileExplorer.Items.Add(item);
            }

            foreach (var tiledImage in nodeFolderInfo.TiledImages)
            {
                item = new ListViewItem(tiledImage.Name,9);
                item.Tag = tiledImage;
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    //new ListViewItem.ListViewSubItem(item, "File"),
                    new ListViewItem.ListViewSubItem(item, ""),
                    new ListViewItem.ListViewSubItem(item, tiledImage.Tiles.Count().ToString() + " images")
                };

                item.SubItems.AddRange(subItems);
                fileExplorer.Items.Add(item);
            }

            foreach (var file in nodeFolderInfo.Files)
            {
                item = new ListViewItem(file.Name, (int) file.Type);
                item.Tag = file;
                subItems = new ListViewItem.ListViewSubItem[]
                {
                    //new ListViewItem.ListViewSubItem(item, "File"),
                    new ListViewItem.ListViewSubItem(item, Utils.GetBytesReadable(file.End - file.Start)),
                    new ListViewItem.ListViewSubItem(item, "(" + file.Start + ", " + file.End +")")
                };

                item.SubItems.AddRange(subItems);
                fileExplorer.Items.Add(item);
            }

            //fileExplorer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void PopulateFolderExplorer(List<VirtualFolder> folders)
        {
            Invoke(new Action(() =>
            {
                folderExplorer.Nodes.Clear();
                foreach (var folder in folders)
                {
                    if (folder != null)
                    {
                        var folderNode = new TreeNode(folder.Name);
                        folderNode.Tag = folder;
                        BuildTreeNode(folderNode, folder.SubFolders);
                        folderExplorer.Nodes.Add(folderNode);
                    }
                }
            }));
        }

        private void BuildTreeNode(TreeNode nodeToAddTo, List<VirtualFolder> subFolders)
        {
            TreeNode childNode;
            List<VirtualFolder> subSubFolders;
            foreach (var subFolder in subFolders)
            {
                if (subFolder == null)
                {
                    continue;
                }
                childNode = new TreeNode(subFolder.Name, 0, 0);
                childNode.Tag = subFolder;
                childNode.ImageKey = "folder";
                if (subFolder.Name.Contains(".m4b"))
                    childNode.ImageIndex = (int)FileType.M4B;
                else if (subFolder.Name.Contains(".m3a"))
                    childNode.ImageIndex = (int)FileType.M3A;

                subSubFolders = subFolder.SubFolders;
                if (subSubFolders.Count != 0)
                {
                    BuildTreeNode(childNode, subSubFolders);
                }
                nodeToAddTo.Nodes.Add(childNode);
            }
        }

        private void extractFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void extractSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extractFileDialog.InitialDirectory = app.GetExtractionDirectory();
            extractFileDialog.FileName = "SelectedFiles";
            extractFileDialog.Title = "Save As";
            if (extractFileDialog.ShowDialog() == DialogResult.OK)
            {
                var extractionPath = Path.GetDirectoryName(extractFileDialog.FileName);
                app.SetExtractionDirectory(extractionPath);

                if (extractionPath.Length < 1)
                {
                    MessageBox.Show("leave a name in the filename field (doesn't matter what, it won't be used)");
                    return;
                }

                WriteToConsole(Color.LightBlue, "Extracting Selected Files to " + extractionPath);

                List<VirtualFileIndex> files = new List<VirtualFileIndex>();
                List<VirtualFileTiledImage> tiledImages = new List<VirtualFileTiledImage>();

                foreach (ListViewItem item in fileExplorer.SelectedItems)
                {
                    if (item.Tag is VirtualFileIndex)
                        files.Add(item.Tag as VirtualFileIndex);
                    else if (item.Tag is VirtualFileTiledImage)
                        tiledImages.Add(item.Tag as VirtualFileTiledImage);
                }
                ExtractFiles(extractionPath, files);
                ExtractTiledImages(extractionPath, tiledImages);
            }
        }

        private void ExtractFiles(string extractionPath, List<VirtualFileIndex> files)
        {
            var saveService = new VirtualFileSaveService();
            var extractor = new VirtualFileExtractionService();
            foreach (var file in files)
            {
                WriteToConsole(Color.LightBlue, "Extracting " + file.Name);
                var fileData = extractor.CopyFile(file);
                var fileType = file.Type;

                if (file.Type == FileType.Zap)
                {
                    fileData = ConversionService.ConvertFromZapToJpg(fileData);
                    fileType = FileType.Jpg;
                }
                saveService.SaveFile(extractionPath, file.Name, fileType, fileData);
            }
        }

        private void ExtractTiledImages(string extractionPath, List<VirtualFileTiledImage> tiledImages)
        {
            var saveService = new VirtualFileSaveService();
            var extractor = new VirtualFileExtractionService();
            foreach (var tiledImage in tiledImages)
            {
                WriteToConsole(Color.LightBlue, "Extracting " + tiledImage.Name);
                var fileData = extractor.GetImageDataFromVirtualFileTiledImage(tiledImage);
                saveService.SaveFile(extractionPath, tiledImage.Name, FileType.Jpg, fileData);
            }
        }

        private void fileExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 1)
            {
                ListViewItem selected = fileExplorer.SelectedItems[0];
                if (selected.Tag is VirtualFolder)
                    return;

                if (selected.Tag is VirtualFileIndex)
                {
                    var file = selected.Tag as VirtualFileIndex;
                    if (!(file.Type == FileType.Jpg || file.Type == FileType.Zap))
                        return;
                }
                var imageData = GetDataForImageFile(selected);
                SetImageDataIntoPreviewWindow(selected.Text, imageData);
            }
            else
            {
                previewWindow.Image = previewWindow.InitialImage;
            }
        }

        private byte[] GetDataForImageFile(ListViewItem item)
        {
            byte[] imageData = new byte[0];
            var extractor = new VirtualFileExtractionService();
            if (item.Tag is VirtualFileIndex)
            {
                var file = item.Tag as VirtualFileIndex;
                imageData = extractor.GetImageDataFromVirtualFile(file);
            }
            else if (item.Tag is VirtualFileTiledImage)
            {
                var tiledImage = item.Tag as VirtualFileTiledImage;
                WriteToConsole(Color.Yellow, "Assembling Tiled Image: '" + tiledImage.Name + "'");
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                imageData = extractor.GetImageDataFromVirtualFileTiledImage(tiledImage);
                stopwatch.Stop();
                WriteToConsole(Color.Green, "'"+ tiledImage.Name + "' assembled in " + stopwatch.ElapsedMilliseconds + "ms");
            }
            return imageData;
        }

        private void SetImageDataIntoPreviewWindow(string imageName, byte[] imageData)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(imageData))
            {
                try
                {
                    bmp = new Bitmap(ms);
                    previewWindow.Image = bmp;
                }
                catch (Exception ex)
                {
                    previewWindow.Image = previewWindow.InitialImage;
                    WriteToConsole(Color.Red, "ERROR: '" + imageName + "' could not be shown ( " + ex.Message + " )");
                }
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

        private void findFileButton_Click_1(object sender, EventArgs e)
        {
            app.FindFile();
        }
    }
}
