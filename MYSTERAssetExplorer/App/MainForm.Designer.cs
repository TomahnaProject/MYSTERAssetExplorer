namespace MYSTERAssetExplorer.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.nextSelectionButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.previewGroup = new System.Windows.Forms.GroupBox();
            this.previewWindow = new System.Windows.Forms.PictureBox();
            this.extractGroup = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RemoveNode = new System.Windows.Forms.Button();
            this.AddNode = new System.Windows.Forms.Button();
            this.NodePropertiesGroup = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nodeProp_ZoneInput = new System.Windows.Forms.TextBox();
            this.nodeNumber = new System.Windows.Forms.NumericUpDown();
            this.nodeProp_SceneInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeExplorer = new System.Windows.Forms.TreeView();
            this.contextMenuNodeExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractAllChildNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutput = new System.Windows.Forms.RichTextBox();
            this.MenuStrip = new System.Windows.Forms.ToolStrip();
            this.openFolder = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveButton = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openViewer = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutButton = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.helpButton = new System.Windows.Forms.ToolStripLabel();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainerFooter = new System.Windows.Forms.SplitContainer();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.splitContainerFileListings = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.folderExplorer = new System.Windows.Forms.TreeView();
            this.contextMenuFolderExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSet = new System.Windows.Forms.ImageList(this.components);
            this.fileExplorer = new System.Windows.Forms.ListView();
            this.fileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.offsetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuFileExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewWindow)).BeginInit();
            this.extractGroup.SuspendLayout();
            this.NodePropertiesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeNumber)).BeginInit();
            this.contextMenuNodeExplorer.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFooter)).BeginInit();
            this.splitContainerFooter.Panel1.SuspendLayout();
            this.splitContainerFooter.Panel2.SuspendLayout();
            this.splitContainerFooter.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFileListings)).BeginInit();
            this.splitContainerFileListings.Panel1.SuspendLayout();
            this.splitContainerFileListings.Panel2.SuspendLayout();
            this.splitContainerFileListings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.contextMenuFolderExplorer.SuspendLayout();
            this.contextMenuFileExplorer.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFolderDialog
            // 
            this.openFolderDialog.FileName = "Select Folder";
            // 
            // nextSelectionButton
            // 
            this.nextSelectionButton.Location = new System.Drawing.Point(0, 0);
            this.nextSelectionButton.Name = "nextSelectionButton";
            this.nextSelectionButton.Size = new System.Drawing.Size(100, 22);
            this.nextSelectionButton.TabIndex = 7;
            this.nextSelectionButton.Text = "Next";
            this.nextSelectionButton.UseVisualStyleBackColor = true;
            this.nextSelectionButton.Click += new System.EventHandler(this.nextSelectionButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 22);
            this.button2.TabIndex = 19;
            this.button2.Text = "Previous";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // previewGroup
            // 
            this.previewGroup.Controls.Add(this.previewWindow);
            this.previewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.previewGroup.Location = new System.Drawing.Point(0, 0);
            this.previewGroup.Margin = new System.Windows.Forms.Padding(0);
            this.previewGroup.MinimumSize = new System.Drawing.Size(333, 377);
            this.previewGroup.Name = "previewGroup";
            this.previewGroup.Padding = new System.Windows.Forms.Padding(0);
            this.previewGroup.Size = new System.Drawing.Size(343, 377);
            this.previewGroup.TabIndex = 28;
            this.previewGroup.TabStop = false;
            this.previewGroup.Text = "Asset Preview";
            // 
            // previewWindow
            // 
            this.previewWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.previewWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewWindow.Image = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.previewWindow.InitialImage = null;
            this.previewWindow.Location = new System.Drawing.Point(0, 15);
            this.previewWindow.Margin = new System.Windows.Forms.Padding(0);
            this.previewWindow.MinimumSize = new System.Drawing.Size(200, 215);
            this.previewWindow.Name = "previewWindow";
            this.previewWindow.Size = new System.Drawing.Size(343, 362);
            this.previewWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.previewWindow.TabIndex = 0;
            this.previewWindow.TabStop = false;
            // 
            // extractGroup
            // 
            this.extractGroup.Controls.Add(this.button4);
            this.extractGroup.Controls.Add(this.label5);
            this.extractGroup.Controls.Add(this.button3);
            this.extractGroup.Controls.Add(this.checkBox1);
            this.extractGroup.Controls.Add(this.button1);
            this.extractGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extractGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.extractGroup.Location = new System.Drawing.Point(0, 0);
            this.extractGroup.Name = "extractGroup";
            this.extractGroup.Size = new System.Drawing.Size(343, 321);
            this.extractGroup.TabIndex = 27;
            this.extractGroup.TabStop = false;
            this.extractGroup.Text = "Extract Assets";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(32, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 24);
            this.button4.TabIndex = 30;
            this.button4.Text = "Extract This File";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "OutputFolder";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(32, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 24);
            this.button3.TabIndex = 28;
            this.button3.Text = "Extract All Nodes";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 272);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(186, 18);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Extract Cube Faces Separately";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Extract This Node";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RemoveNode
            // 
            this.RemoveNode.Location = new System.Drawing.Point(281, 647);
            this.RemoveNode.Name = "RemoveNode";
            this.RemoveNode.Size = new System.Drawing.Size(91, 25);
            this.RemoveNode.TabIndex = 25;
            this.RemoveNode.Text = "Remove";
            this.RemoveNode.UseVisualStyleBackColor = true;
            // 
            // AddNode
            // 
            this.AddNode.Location = new System.Drawing.Point(193, 647);
            this.AddNode.Name = "AddNode";
            this.AddNode.Size = new System.Drawing.Size(82, 25);
            this.AddNode.TabIndex = 24;
            this.AddNode.Text = "Add";
            this.AddNode.UseVisualStyleBackColor = true;
            // 
            // NodePropertiesGroup
            // 
            this.NodePropertiesGroup.Controls.Add(this.label7);
            this.NodePropertiesGroup.Controls.Add(this.listBox3);
            this.NodePropertiesGroup.Controls.Add(this.label6);
            this.NodePropertiesGroup.Controls.Add(this.listBox2);
            this.NodePropertiesGroup.Controls.Add(this.label4);
            this.NodePropertiesGroup.Controls.Add(this.listBox1);
            this.NodePropertiesGroup.Controls.Add(this.label3);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_ZoneInput);
            this.NodePropertiesGroup.Controls.Add(this.nodeNumber);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_SceneInput);
            this.NodePropertiesGroup.Controls.Add(this.label2);
            this.NodePropertiesGroup.Controls.Add(this.label1);
            this.NodePropertiesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodePropertiesGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.NodePropertiesGroup.Location = new System.Drawing.Point(0, 0);
            this.NodePropertiesGroup.Name = "NodePropertiesGroup";
            this.NodePropertiesGroup.Size = new System.Drawing.Size(173, 699);
            this.NodePropertiesGroup.TabIndex = 23;
            this.NodePropertiesGroup.TabStop = false;
            this.NodePropertiesGroup.Text = "Node Properties";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 14);
            this.label7.TabIndex = 28;
            this.label7.Text = "DepthMap Cube Files";
            // 
            // listBox3
            // 
            this.listBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 14;
            this.listBox3.Location = new System.Drawing.Point(3, 271);
            this.listBox3.Margin = new System.Windows.Forms.Padding(0);
            this.listBox3.MinimumSize = new System.Drawing.Size(100, 4);
            this.listBox3.Name = "listBox3";
            this.listBox3.ScrollAlwaysVisible = true;
            this.listBox3.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox3.Size = new System.Drawing.Size(164, 60);
            this.listBox3.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "Other Images";
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(3, 412);
            this.listBox2.Margin = new System.Windows.Forms.Padding(0);
            this.listBox2.MinimumSize = new System.Drawing.Size(100, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(164, 242);
            this.listBox2.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cube Files";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(3, 157);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.MinimumSize = new System.Drawing.Size(100, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(164, 60);
            this.listBox1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "Scene";
            // 
            // nodeProp_ZoneInput
            // 
            this.nodeProp_ZoneInput.Location = new System.Drawing.Point(9, 78);
            this.nodeProp_ZoneInput.Name = "nodeProp_ZoneInput";
            this.nodeProp_ZoneInput.Size = new System.Drawing.Size(184, 22);
            this.nodeProp_ZoneInput.TabIndex = 19;
            // 
            // nodeNumber
            // 
            this.nodeNumber.Location = new System.Drawing.Point(9, 118);
            this.nodeNumber.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeNumber.Name = "nodeNumber";
            this.nodeNumber.Size = new System.Drawing.Size(184, 22);
            this.nodeNumber.TabIndex = 17;
            this.nodeNumber.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // nodeProp_SceneInput
            // 
            this.nodeProp_SceneInput.Location = new System.Drawing.Point(9, 34);
            this.nodeProp_SceneInput.Name = "nodeProp_SceneInput";
            this.nodeProp_SceneInput.Size = new System.Drawing.Size(184, 22);
            this.nodeProp_SceneInput.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zone";
            // 
            // nodeExplorer
            // 
            this.nodeExplorer.AllowDrop = true;
            this.nodeExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nodeExplorer.ContextMenuStrip = this.contextMenuNodeExplorer;
            this.nodeExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.nodeExplorer.Location = new System.Drawing.Point(0, 0);
            this.nodeExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.nodeExplorer.MinimumSize = new System.Drawing.Size(100, 215);
            this.nodeExplorer.Name = "nodeExplorer";
            this.nodeExplorer.Size = new System.Drawing.Size(143, 699);
            this.nodeExplorer.TabIndex = 22;
            this.nodeExplorer.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.nodeListing_ItemDrag);
            this.nodeExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nodeListing_AfterSelect);
            this.nodeExplorer.DragDrop += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragDrop);
            this.nodeExplorer.DragEnter += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragEnter);
            this.nodeExplorer.DragOver += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragOver);
            // 
            // contextMenuNodeExplorer
            // 
            this.contextMenuNodeExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractNodeToolStripMenuItem,
            this.extractAllChildNodesToolStripMenuItem});
            this.contextMenuNodeExplorer.Name = "contextMenuFolderExplorer";
            this.contextMenuNodeExplorer.Size = new System.Drawing.Size(195, 48);
            // 
            // extractNodeToolStripMenuItem
            // 
            this.extractNodeToolStripMenuItem.Name = "extractNodeToolStripMenuItem";
            this.extractNodeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.extractNodeToolStripMenuItem.Text = "Extract Node";
            // 
            // extractAllChildNodesToolStripMenuItem
            // 
            this.extractAllChildNodesToolStripMenuItem.Name = "extractAllChildNodesToolStripMenuItem";
            this.extractAllChildNodesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.extractAllChildNodesToolStripMenuItem.Text = "Extract All Child Nodes";
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
            this.logOutput.Size = new System.Drawing.Size(1004, 34);
            this.logOutput.TabIndex = 2;
            this.logOutput.Text = "";
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.Gray;
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolder,
            this.toolStripSeparator3,
            this.saveButton,
            this.toolStripSeparator1,
            this.openViewer,
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
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(72, 22);
            this.openFolder.Text = "Open Folder";
            this.openFolder.Click += new System.EventHandler(this.openFolder_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(142, 22);
            this.saveButton.Text = "Save Changes To Registry";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
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
            this.openViewer.Click += new System.EventHandler(this.toolStripLabel1_Click_1);
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
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.splitContainer2);
            this.ControlPanel.Controls.Add(this.RemoveNode);
            this.ControlPanel.Controls.Add(this.AddNode);
            this.ControlPanel.Controls.Add(this.nextSelectionButton);
            this.ControlPanel.Controls.Add(this.button2);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(520, 699);
            this.ControlPanel.TabIndex = 23;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.NodePropertiesGroup);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(520, 699);
            this.splitContainer2.SplitterDistance = 173;
            this.splitContainer2.TabIndex = 29;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.previewGroup);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.extractGroup);
            this.splitContainer3.Size = new System.Drawing.Size(343, 699);
            this.splitContainer3.SplitterDistance = 374;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainerFooter
            // 
            this.splitContainerFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFooter.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFooter.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerFooter.Name = "splitContainerFooter";
            this.splitContainerFooter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFooter.Panel1
            // 
            this.splitContainerFooter.Panel1.Controls.Add(this.MenuStrip);
            this.splitContainerFooter.Panel1.Controls.Add(this.MainPanel);
            // 
            // splitContainerFooter.Panel2
            // 
            this.splitContainerFooter.Panel2.Controls.Add(this.logOutput);
            this.splitContainerFooter.Size = new System.Drawing.Size(1004, 770);
            this.splitContainerFooter.SplitterDistance = 732;
            this.splitContainerFooter.TabIndex = 29;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Controls.Add(this.splitContainerFileListings);
            this.MainPanel.Location = new System.Drawing.Point(0, 30);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1004, 699);
            this.MainPanel.TabIndex = 29;
            // 
            // splitContainerFileListings
            // 
            this.splitContainerFileListings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFileListings.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFileListings.Name = "splitContainerFileListings";
            // 
            // splitContainerFileListings.Panel1
            // 
            this.splitContainerFileListings.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainerFileListings.Panel2
            // 
            this.splitContainerFileListings.Panel2.Controls.Add(this.ControlPanel);
            this.splitContainerFileListings.Size = new System.Drawing.Size(1004, 699);
            this.splitContainerFileListings.SplitterDistance = 480;
            this.splitContainerFileListings.TabIndex = 29;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nodeExplorer);
            this.splitContainer1.Size = new System.Drawing.Size(480, 699);
            this.splitContainer1.SplitterDistance = 333;
            this.splitContainer1.TabIndex = 29;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.folderExplorer);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.fileExplorer);
            this.splitContainer4.Size = new System.Drawing.Size(333, 699);
            this.splitContainer4.SplitterDistance = 144;
            this.splitContainer4.TabIndex = 7;
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
            this.folderExplorer.Size = new System.Drawing.Size(144, 699);
            this.folderExplorer.TabIndex = 23;
            this.folderExplorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.folderExplorer_NodeMouseClick);
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
            this.iconSet.Images.SetKeyName(3, "Picture.ico");
            this.iconSet.Images.SetKeyName(4, "video.ico");
            this.iconSet.Images.SetKeyName(5, "lightning.ico");
            this.iconSet.Images.SetKeyName(6, "archives.ico");
            this.iconSet.Images.SetKeyName(7, "script-binary.ico");
            this.iconSet.Images.SetKeyName(8, "tiledimage.ico");
            this.iconSet.Images.SetKeyName(9, "red-alert.ico");
            this.iconSet.Images.SetKeyName(10, "zone.png");
            // 
            // fileExplorer
            // 
            this.fileExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.fileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileColumn,
            this.sizeColumn,
            this.offsetColumn});
            this.fileExplorer.ContextMenuStrip = this.contextMenuFileExplorer;
            this.fileExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.fileExplorer.Location = new System.Drawing.Point(0, 0);
            this.fileExplorer.Name = "fileExplorer";
            this.fileExplorer.Size = new System.Drawing.Size(185, 699);
            this.fileExplorer.SmallImageList = this.iconSet;
            this.fileExplorer.TabIndex = 0;
            this.fileExplorer.UseCompatibleStateImageBehavior = false;
            this.fileExplorer.View = System.Windows.Forms.View.Details;
            this.fileExplorer.SelectedIndexChanged += new System.EventHandler(this.fileExplorer_SelectedIndexChanged);
            // 
            // fileColumn
            // 
            this.fileColumn.Text = "File";
            this.fileColumn.Width = 130;
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "Size";
            // 
            // offsetColumn
            // 
            this.offsetColumn.Text = "Offset";
            // 
            // contextMenuFileExplorer
            // 
            this.contextMenuFileExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractSelectedFilesToolStripMenuItem});
            this.contextMenuFileExplorer.Name = "contextMenuFolderExplorer";
            this.contextMenuFileExplorer.Size = new System.Drawing.Size(183, 26);
            // 
            // extractSelectedFilesToolStripMenuItem
            // 
            this.extractSelectedFilesToolStripMenuItem.Name = "extractSelectedFilesToolStripMenuItem";
            this.extractSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.extractSelectedFilesToolStripMenuItem.Text = "Extract Selected Files";
            this.extractSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.extractSelectedFilesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1004, 770);
            this.Controls.Add(this.splitContainerFooter);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "MainForm";
            this.Text = "MYSTER (Exile / Revelation) Asset Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.previewGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewWindow)).EndInit();
            this.extractGroup.ResumeLayout(false);
            this.extractGroup.PerformLayout();
            this.NodePropertiesGroup.ResumeLayout(false);
            this.NodePropertiesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeNumber)).EndInit();
            this.contextMenuNodeExplorer.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainerFooter.Panel1.ResumeLayout(false);
            this.splitContainerFooter.Panel1.PerformLayout();
            this.splitContainerFooter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFooter)).EndInit();
            this.splitContainerFooter.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.splitContainerFileListings.Panel1.ResumeLayout(false);
            this.splitContainerFileListings.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFileListings)).EndInit();
            this.splitContainerFileListings.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
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
        private System.Windows.Forms.Button nextSelectionButton;
        private System.Windows.Forms.TextBox nodeProp_SceneInput;
        private System.Windows.Forms.RichTextBox logOutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nodeNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView nodeExplorer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel saveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel aboutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel helpButton;
        private System.Windows.Forms.Button RemoveNode;
        private System.Windows.Forms.Button AddNode;
        private System.Windows.Forms.GroupBox NodePropertiesGroup;
        private System.Windows.Forms.GroupBox extractGroup;
        private System.Windows.Forms.GroupBox previewGroup;
        private System.Windows.Forms.TextBox nodeProp_ZoneInput;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox previewWindow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.SplitContainer splitContainerFooter;
        private System.Windows.Forms.SplitContainer splitContainerFileListings;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TreeView folderExplorer;
        private System.Windows.Forms.ListView fileExplorer;
        private System.Windows.Forms.ColumnHeader fileColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuFolderExplorer;
        private System.Windows.Forms.ToolStripMenuItem extractFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuFileExplorer;
        private System.Windows.Forms.ToolStripMenuItem extractSelectedFilesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuNodeExplorer;
        private System.Windows.Forms.ToolStripMenuItem extractNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractAllChildNodesToolStripMenuItem;
        private System.Windows.Forms.ImageList iconSet;
        private System.Windows.Forms.ColumnHeader offsetColumn;
        private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
    }
}

