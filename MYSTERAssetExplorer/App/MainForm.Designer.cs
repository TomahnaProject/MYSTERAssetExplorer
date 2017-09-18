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
            this.openFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.nextSelectionButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.previewGroup = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.extractGroup = new System.Windows.Forms.GroupBox();
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
            this.nodeListing = new System.Windows.Forms.TreeView();
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
            this.button4 = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.fileListing = new System.Windows.Forms.ListView();
            this.fileColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.offsetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.previewGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.extractGroup.SuspendLayout();
            this.NodePropertiesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeNumber)).BeginInit();
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
            this.previewGroup.Controls.Add(this.pictureBox1);
            this.previewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.previewGroup.Location = new System.Drawing.Point(0, 0);
            this.previewGroup.Margin = new System.Windows.Forms.Padding(0);
            this.previewGroup.MinimumSize = new System.Drawing.Size(333, 377);
            this.previewGroup.Name = "previewGroup";
            this.previewGroup.Padding = new System.Windows.Forms.Padding(0);
            this.previewGroup.Size = new System.Drawing.Size(440, 377);
            this.previewGroup.TabIndex = 28;
            this.previewGroup.TabStop = false;
            this.previewGroup.Text = "Asset Preview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(200, 215);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(440, 362);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.extractGroup.Size = new System.Drawing.Size(440, 316);
            this.extractGroup.TabIndex = 27;
            this.extractGroup.TabStop = false;
            this.extractGroup.Text = "Extract Assets";
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
            this.NodePropertiesGroup.Size = new System.Drawing.Size(222, 690);
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
            this.listBox3.Size = new System.Drawing.Size(213, 60);
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
            this.listBox2.Size = new System.Drawing.Size(213, 242);
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
            this.listBox1.Size = new System.Drawing.Size(213, 60);
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
            // nodeListing
            // 
            this.nodeListing.AllowDrop = true;
            this.nodeListing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nodeListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeListing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.nodeListing.Location = new System.Drawing.Point(0, 0);
            this.nodeListing.Margin = new System.Windows.Forms.Padding(0);
            this.nodeListing.MinimumSize = new System.Drawing.Size(100, 215);
            this.nodeListing.Name = "nodeListing";
            this.nodeListing.Size = new System.Drawing.Size(100, 690);
            this.nodeListing.TabIndex = 22;
            this.nodeListing.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.nodeListing_ItemDrag);
            this.nodeListing.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nodeListing_AfterSelect);
            this.nodeListing.DragDrop += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragDrop);
            this.nodeListing.DragEnter += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragEnter);
            this.nodeListing.DragOver += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragOver);
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
            this.logOutput.Size = new System.Drawing.Size(1004, 43);
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
            this.ControlPanel.Size = new System.Drawing.Size(666, 690);
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
            this.splitContainer2.Size = new System.Drawing.Size(666, 690);
            this.splitContainer2.SplitterDistance = 222;
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
            this.splitContainer3.Size = new System.Drawing.Size(440, 690);
            this.splitContainer3.SplitterDistance = 370;
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
            this.splitContainerFooter.SplitterDistance = 723;
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
            this.MainPanel.Size = new System.Drawing.Size(1004, 690);
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
            this.splitContainerFileListings.Size = new System.Drawing.Size(1004, 690);
            this.splitContainerFileListings.SplitterDistance = 334;
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
            this.splitContainer1.Panel2.Controls.Add(this.nodeListing);
            this.splitContainer1.Size = new System.Drawing.Size(334, 690);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 29;
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
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.fileListing);
            this.splitContainer4.Size = new System.Drawing.Size(232, 690);
            this.splitContainer4.SplitterDistance = 101;
            this.splitContainer4.TabIndex = 7;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.MinimumSize = new System.Drawing.Size(100, 215);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(101, 690);
            this.treeView1.TabIndex = 23;
            // 
            // fileListing
            // 
            this.fileListing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.fileListing.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileColumn,
            this.sizeColumn,
            this.offsetColumn});
            this.fileListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListing.Location = new System.Drawing.Point(0, 0);
            this.fileListing.Name = "fileListing";
            this.fileListing.Size = new System.Drawing.Size(127, 690);
            this.fileListing.TabIndex = 0;
            this.fileListing.UseCompatibleStateImageBehavior = false;
            // 
            // fileColumn
            // 
            this.fileColumn.Text = "File";
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "Size";
            // 
            // offsetColumn
            // 
            this.offsetColumn.Text = "offset";
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.extractGroup.ResumeLayout(false);
            this.extractGroup.PerformLayout();
            this.NodePropertiesGroup.ResumeLayout(false);
            this.NodePropertiesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeNumber)).EndInit();
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
        private System.Windows.Forms.TreeView nodeListing;
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
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView fileListing;
        private System.Windows.Forms.ColumnHeader fileColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ColumnHeader offsetColumn;
    }
}

