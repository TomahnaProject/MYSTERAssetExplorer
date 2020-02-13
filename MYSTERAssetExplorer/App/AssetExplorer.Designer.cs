namespace MYSTERAssetExplorer.App
{
    partial class AssetExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetExplorer));
            this.openFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.previewGroup = new System.Windows.Forms.GroupBox();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.logOutput = new System.Windows.Forms.RichTextBox();
            this.MenuStrip = new System.Windows.Forms.ToolStrip();
            this.openFolder = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openViewer = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutButton = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.helpButton = new System.Windows.Forms.ToolStripLabel();
            this.findFileButton = new System.Windows.Forms.ToolStripLabel();
            this.Main_Footer = new System.Windows.Forms.SplitContainer();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Files_Preview = new System.Windows.Forms.SplitContainer();
            this.Folder_File = new System.Windows.Forms.SplitContainer();
            this.folderExplorer = new System.Windows.Forms.TreeView();
            this.contextMenuFolderExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSet = new System.Windows.Forms.ImageList(this.components);
            this.filterSmallImagesCheckbox = new System.Windows.Forms.CheckBox();
            this.fileExplorer = new System.Windows.Forms.ListView();
            this.fileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.offsetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuFileExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToNodeViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.previewGroup.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Footer)).BeginInit();
            this.Main_Footer.Panel1.SuspendLayout();
            this.Main_Footer.Panel2.SuspendLayout();
            this.Main_Footer.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Files_Preview)).BeginInit();
            this.Files_Preview.Panel1.SuspendLayout();
            this.Files_Preview.Panel2.SuspendLayout();
            this.Files_Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Folder_File)).BeginInit();
            this.Folder_File.Panel1.SuspendLayout();
            this.Folder_File.Panel2.SuspendLayout();
            this.Folder_File.SuspendLayout();
            this.contextMenuFolderExplorer.SuspendLayout();
            this.contextMenuFileExplorer.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFolderDialog
            // 
            this.openFolderDialog.FileName = "Select Folder";
            // 
            // previewGroup
            // 
            this.previewGroup.Controls.Add(this.previewPanel);
            this.previewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.previewGroup.Location = new System.Drawing.Point(0, 0);
            this.previewGroup.Margin = new System.Windows.Forms.Padding(0);
            this.previewGroup.MinimumSize = new System.Drawing.Size(333, 377);
            this.previewGroup.Name = "previewGroup";
            this.previewGroup.Padding = new System.Windows.Forms.Padding(1);
            this.previewGroup.Size = new System.Drawing.Size(537, 647);
            this.previewGroup.TabIndex = 28;
            this.previewGroup.TabStop = false;
            this.previewGroup.Text = "Asset Preview";
            // 
            // previewPanel
            // 
            this.previewPanel.AutoScroll = true;
            this.previewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.previewPanel.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.previewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(1, 16);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(535, 630);
            this.previewPanel.TabIndex = 1;
            this.previewPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.startDrag_MouseDown);
            // 
            // logOutput
            // 
            this.logOutput.BackColor = System.Drawing.Color.Black;
            this.logOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.logOutput.Location = new System.Drawing.Point(0, 0);
            this.logOutput.Margin = new System.Windows.Forms.Padding(0);
            this.logOutput.Name = "logOutput";
            this.logOutput.ReadOnly = true;
            this.logOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logOutput.Size = new System.Drawing.Size(1004, 31);
            this.logOutput.TabIndex = 2;
            this.logOutput.Text = "";
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.Gray;
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolder,
            this.toolStripSeparator1,
            this.openViewer,
            this.toolStripSeparator2,
            this.findFileButton,
            this.toolStripSeparator4,
            this.aboutButton,
            this.toolStripSeparator5,
            this.helpButton});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1004, 25);
            this.MenuStrip.TabIndex = 8;
            this.MenuStrip.Text = "Menu";
            // 
            // openFolder
            // 
            this.openFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(72, 22);
            this.openFolder.Text = "Open Folder";
            this.openFolder.Click += new System.EventHandler(this.openFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openViewer
            // 
            this.openViewer.Name = "openViewer";
            this.openViewer.Size = new System.Drawing.Size(106, 22);
            this.openViewer.Text = "Open Node Viewer";
            this.openViewer.Click += new System.EventHandler(this.launchNodeViewer_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutButton
            // 
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(40, 22);
            this.aboutButton.Text = "About";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // helpButton
            // 
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(35, 22);
            this.helpButton.Text = "Help!";
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // findFileButton
            // 
            this.findFileButton.Enabled = false;
            this.findFileButton.Name = "findFileButton";
            this.findFileButton.Size = new System.Drawing.Size(30, 22);
            this.findFileButton.Text = "Find";
            this.findFileButton.Click += new System.EventHandler(this.FindFileButton_Click);
            // 
            // Main_Footer
            // 
            this.Main_Footer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Footer.Location = new System.Drawing.Point(0, 0);
            this.Main_Footer.Margin = new System.Windows.Forms.Padding(0);
            this.Main_Footer.Name = "Main_Footer";
            this.Main_Footer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Main_Footer.Panel1
            // 
            this.Main_Footer.Panel1.Controls.Add(this.MenuStrip);
            this.Main_Footer.Panel1.Controls.Add(this.MainPanel);
            // 
            // Main_Footer.Panel2
            // 
            this.Main_Footer.Panel2.Controls.Add(this.logOutput);
            this.Main_Footer.Size = new System.Drawing.Size(1004, 715);
            this.Main_Footer.SplitterDistance = 680;
            this.Main_Footer.TabIndex = 29;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Controls.Add(this.Files_Preview);
            this.MainPanel.Location = new System.Drawing.Point(0, 30);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1004, 647);
            this.MainPanel.TabIndex = 29;
            // 
            // Files_Preview
            // 
            this.Files_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Files_Preview.Location = new System.Drawing.Point(0, 0);
            this.Files_Preview.Name = "Files_Preview";
            // 
            // Files_Preview.Panel1
            // 
            this.Files_Preview.Panel1.Controls.Add(this.Folder_File);
            // 
            // Files_Preview.Panel2
            // 
            this.Files_Preview.Panel2.Controls.Add(this.previewGroup);
            this.Files_Preview.Size = new System.Drawing.Size(1004, 647);
            this.Files_Preview.SplitterDistance = 463;
            this.Files_Preview.TabIndex = 29;
            // 
            // Folder_File
            // 
            this.Folder_File.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Folder_File.Location = new System.Drawing.Point(0, 0);
            this.Folder_File.Name = "Folder_File";
            // 
            // Folder_File.Panel1
            // 
            this.Folder_File.Panel1.Controls.Add(this.folderExplorer);
            // 
            // Folder_File.Panel2
            // 
            this.Folder_File.Panel2.Controls.Add(this.filterSmallImagesCheckbox);
            this.Folder_File.Panel2.Controls.Add(this.fileExplorer);
            this.Folder_File.Size = new System.Drawing.Size(463, 647);
            this.Folder_File.SplitterDistance = 229;
            this.Folder_File.TabIndex = 7;
            // 
            // folderExplorer
            // 
            this.folderExplorer.AllowDrop = true;
            this.folderExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.folderExplorer.ContextMenuStrip = this.contextMenuFolderExplorer;
            this.folderExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.folderExplorer.ImageKey = "folder-closed.ico";
            this.folderExplorer.ImageList = this.iconSet;
            this.folderExplorer.Location = new System.Drawing.Point(0, 0);
            this.folderExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.folderExplorer.MinimumSize = new System.Drawing.Size(100, 215);
            this.folderExplorer.Name = "folderExplorer";
            this.folderExplorer.SelectedImageIndex = 0;
            this.folderExplorer.Size = new System.Drawing.Size(229, 647);
            this.folderExplorer.TabIndex = 23;
            this.folderExplorer.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.nodeExplorer_AfterCollapse);
            this.folderExplorer.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.nodeExplorer_AfterExpand);
            this.folderExplorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.nodeExplorer_NodeMouseClick);
            // 
            // contextMenuFolderExplorer
            // 
            this.contextMenuFolderExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseAllToolStripMenuItem,
            this.expandAllToolStripMenuItem,
            this.extractFolderToolStripMenuItem});
            this.contextMenuFolderExplorer.Name = "contextMenuFolderExplorer";
            this.contextMenuFolderExplorer.Size = new System.Drawing.Size(146, 70);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.collapseAllToolStripMenuItem.Text = "Collapse All";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.collapseAllToolStripMenuItem_Click);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.expandAllToolStripMenuItem.Text = "Expand All";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.expandAllToolStripMenuItem_Click);
            // 
            // extractFolderToolStripMenuItem
            // 
            this.extractFolderToolStripMenuItem.Name = "extractFolderToolStripMenuItem";
            this.extractFolderToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.extractFolderToolStripMenuItem.Text = "Extract Folder";
            this.extractFolderToolStripMenuItem.Click += new System.EventHandler(this.extractFolderToolStripMenuItem_Click);
            // 
            // iconSet
            // 
            this.iconSet.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconSet.ImageStream")));
            this.iconSet.TransparentColor = System.Drawing.Color.Transparent;
            this.iconSet.Images.SetKeyName(0, "folder-closed.ico");
            this.iconSet.Images.SetKeyName(1, "folder-open.ico");
            this.iconSet.Images.SetKeyName(2, "file.ico");
            this.iconSet.Images.SetKeyName(3, "m3.ico");
            this.iconSet.Images.SetKeyName(4, "m4.ico");
            this.iconSet.Images.SetKeyName(5, "Picture.ico");
            this.iconSet.Images.SetKeyName(6, "lightning.ico");
            this.iconSet.Images.SetKeyName(7, "video.ico");
            this.iconSet.Images.SetKeyName(8, "script-binary.ico");
            this.iconSet.Images.SetKeyName(9, "tiledimage.ico");
            this.iconSet.Images.SetKeyName(10, "red-alert.ico");
            this.iconSet.Images.SetKeyName(11, "zone.png");
            // 
            // filterSmallImagesCheckbox
            // 
            this.filterSmallImagesCheckbox.AutoSize = true;
            this.filterSmallImagesCheckbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterSmallImagesCheckbox.Enabled = false;
            this.filterSmallImagesCheckbox.Location = new System.Drawing.Point(0, 0);
            this.filterSmallImagesCheckbox.Name = "filterSmallImagesCheckbox";
            this.filterSmallImagesCheckbox.Size = new System.Drawing.Size(230, 18);
            this.filterSmallImagesCheckbox.TabIndex = 1;
            this.filterSmallImagesCheckbox.Text = "Filter Small Images";
            this.filterSmallImagesCheckbox.UseVisualStyleBackColor = true;
            this.filterSmallImagesCheckbox.CheckedChanged += new System.EventHandler(this.filterSmallImages_CheckedChanged);
            // 
            // fileExplorer
            // 
            this.fileExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.fileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileColumn,
            this.sizeColumn,
            this.offsetColumn});
            this.fileExplorer.ContextMenuStrip = this.contextMenuFileExplorer;
            this.fileExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.fileExplorer.Location = new System.Drawing.Point(0, 24);
            this.fileExplorer.Name = "fileExplorer";
            this.fileExplorer.Size = new System.Drawing.Size(230, 623);
            this.fileExplorer.SmallImageList = this.iconSet;
            this.fileExplorer.TabIndex = 0;
            this.fileExplorer.UseCompatibleStateImageBehavior = false;
            this.fileExplorer.View = System.Windows.Forms.View.Details;
            this.fileExplorer.SelectedIndexChanged += new System.EventHandler(this.fileExplorer_SelectedIndexChanged);
            this.fileExplorer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fileExplorer_KeyDown);
            this.fileExplorer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.startDrag_MouseDown);
            // 
            // fileColumn
            // 
            this.fileColumn.Text = "File";
            this.fileColumn.Width = 89;
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "Size";
            this.sizeColumn.Width = 49;
            // 
            // offsetColumn
            // 
            this.offsetColumn.Text = "Offset";
            this.offsetColumn.Width = 94;
            // 
            // contextMenuFileExplorer
            // 
            this.contextMenuFileExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractSelectedFilesToolStripMenuItem,
            this.sendToNodeViewerToolStripMenuItem});
            this.contextMenuFileExplorer.Name = "contextMenuFolderExplorer";
            this.contextMenuFileExplorer.Size = new System.Drawing.Size(188, 48);
            // 
            // extractSelectedFilesToolStripMenuItem
            // 
            this.extractSelectedFilesToolStripMenuItem.Name = "extractSelectedFilesToolStripMenuItem";
            this.extractSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.extractSelectedFilesToolStripMenuItem.Text = "Extract Selected Files";
            this.extractSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.extractSelectedFilesToolStripMenuItem_Click);
            // 
            // sendToNodeViewerToolStripMenuItem
            // 
            this.sendToNodeViewerToolStripMenuItem.Name = "sendToNodeViewerToolStripMenuItem";
            this.sendToNodeViewerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.sendToNodeViewerToolStripMenuItem.Text = "Send To Node Viewer";
            this.sendToNodeViewerToolStripMenuItem.Click += new System.EventHandler(this.sendToNodeViewerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // AssetExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1004, 715);
            this.Controls.Add(this.Main_Footer);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssetExplorer";
            this.Text = "MYSTER (Exile / Revelation) Asset Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.previewGroup.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.Main_Footer.Panel1.ResumeLayout(false);
            this.Main_Footer.Panel1.PerformLayout();
            this.Main_Footer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_Footer)).EndInit();
            this.Main_Footer.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.Files_Preview.Panel1.ResumeLayout(false);
            this.Files_Preview.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Files_Preview)).EndInit();
            this.Files_Preview.ResumeLayout(false);
            this.Folder_File.Panel1.ResumeLayout(false);
            this.Folder_File.Panel2.ResumeLayout(false);
            this.Folder_File.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Folder_File)).EndInit();
            this.Folder_File.ResumeLayout(false);
            this.contextMenuFolderExplorer.ResumeLayout(false);
            this.contextMenuFileExplorer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFolderDialog;
        private System.Windows.Forms.ToolStrip MenuStrip;
        private System.Windows.Forms.ToolStripLabel openFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel openViewer;
        private System.Windows.Forms.RichTextBox logOutput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel aboutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel helpButton;
        private System.Windows.Forms.GroupBox previewGroup;
        private System.Windows.Forms.SplitContainer Main_Footer;
        private System.Windows.Forms.SplitContainer Files_Preview;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.SplitContainer Folder_File;
        private System.Windows.Forms.TreeView folderExplorer;
        private System.Windows.Forms.ListView fileExplorer;
        private System.Windows.Forms.ColumnHeader fileColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuFolderExplorer;
        private System.Windows.Forms.ToolStripMenuItem extractFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuFileExplorer;
        private System.Windows.Forms.ToolStripMenuItem extractSelectedFilesToolStripMenuItem;
        private System.Windows.Forms.ImageList iconSet;
        private System.Windows.Forms.ColumnHeader offsetColumn;
        private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog extractFileDialog;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.ToolStripLabel findFileButton;
        private System.Windows.Forms.ToolStripMenuItem sendToNodeViewerToolStripMenuItem;
        private System.Windows.Forms.CheckBox filterSmallImagesCheckbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

