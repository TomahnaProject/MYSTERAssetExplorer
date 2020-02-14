namespace MYSTERAssetExplorer.App
{
    partial class NodeViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeViewer));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nodeExplorer = new System.Windows.Forms.TreeView();
            this.contextMenuNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractCubeFacesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontImage = new System.Windows.Forms.Panel();
            this.fileNameLabel_Front = new System.Windows.Forms.Label();
            this.bottomImage = new System.Windows.Forms.Panel();
            this.fileNameLabel_Bottom = new System.Windows.Forms.Label();
            this.leftImage = new System.Windows.Forms.Panel();
            this.fileNameLabel_Left = new System.Windows.Forms.Label();
            this.rightImage = new System.Windows.Forms.Panel();
            this.fileNameLabel_Right = new System.Windows.Forms.Label();
            this.topImage = new System.Windows.Forms.Panel();
            this.fileNameLabel_Top = new System.Windows.Forms.Label();
            this.backImage = new System.Windows.Forms.Panel();
            this.fileNameLabel_Back = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NodePropertiesGroup = new System.Windows.Forms.GroupBox();
            this.nodeProp_NumberInput = new System.Windows.Forms.TextBox();
            this.nodeProp_Depth = new System.Windows.Forms.NumericUpDown();
            this.nodeProp_ClassificationInput = new System.Windows.Forms.ComboBox();
            this.nodeProp_rotationZ = new System.Windows.Forms.NumericUpDown();
            this.label_PosZ = new System.Windows.Forms.Label();
            this.label_PosY = new System.Windows.Forms.Label();
            this.label_PosX = new System.Windows.Forms.Label();
            this.nodeProp_PosZ = new System.Windows.Forms.NumericUpDown();
            this.nodeProp_PosY = new System.Windows.Forms.NumericUpDown();
            this.nodeProp_PosX = new System.Windows.Forms.NumericUpDown();
            this.label_DepthRange = new System.Windows.Forms.Label();
            this.mapTypeDepth = new System.Windows.Forms.RadioButton();
            this.mapTypeColor = new System.Windows.Forms.RadioButton();
            this.label_Classification = new System.Windows.Forms.Label();
            this.label_Rotation = new System.Windows.Forms.Label();
            this.label_Position = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label_Scene = new System.Windows.Forms.Label();
            this.nodeProp_ZoneInput = new System.Windows.Forms.TextBox();
            this.nodeProp_SceneInput = new System.Windows.Forms.TextBox();
            this.label_Number = new System.Windows.Forms.Label();
            this.label_Zone = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExportAllCubemaps = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.separateImagesCheckbox = new System.Windows.Forms.CheckBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.nodeViewerMenuStrip = new System.Windows.Forms.ToolStrip();
            this.loadRegistry = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveRegistry = new System.Windows.Forms.ToolStripLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuNodeViewer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.extractCubemapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuNode.SuspendLayout();
            this.frontImage.SuspendLayout();
            this.bottomImage.SuspendLayout();
            this.leftImage.SuspendLayout();
            this.rightImage.SuspendLayout();
            this.topImage.SuspendLayout();
            this.backImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.NodePropertiesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_Depth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_rotationZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosX)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.nodeViewerMenuStrip.SuspendLayout();
            this.contextMenuNodeViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.nodeExplorer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.frontImage);
            this.splitContainer1.Panel2.Controls.Add(this.bottomImage);
            this.splitContainer1.Panel2.Controls.Add(this.leftImage);
            this.splitContainer1.Panel2.Controls.Add(this.rightImage);
            this.splitContainer1.Panel2.Controls.Add(this.topImage);
            this.splitContainer1.Panel2.Controls.Add(this.backImage);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.listBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1549, 865);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 18;
            // 
            // nodeExplorer
            // 
            this.nodeExplorer.AllowDrop = true;
            this.nodeExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nodeExplorer.ContextMenuStrip = this.contextMenuNode;
            this.nodeExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.nodeExplorer.Location = new System.Drawing.Point(0, 0);
            this.nodeExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.nodeExplorer.MinimumSize = new System.Drawing.Size(100, 231);
            this.nodeExplorer.Name = "nodeExplorer";
            this.nodeExplorer.Size = new System.Drawing.Size(253, 865);
            this.nodeExplorer.TabIndex = 23;
            this.nodeExplorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.nodeExplorer_NodeMouseClick);
            // 
            // contextMenuNode
            // 
            this.contextMenuNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.removeNodeToolStripMenuItem,
            this.extractCubeFacesToolStripMenuItem,
            this.extractNodeToolStripMenuItem});
            this.contextMenuNode.Name = "contextMenuNode";
            this.contextMenuNode.Size = new System.Drawing.Size(173, 92);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeNodeToolStripMenuItem.Text = "Delete";
            this.removeNodeToolStripMenuItem.Click += new System.EventHandler(this.removeNodeToolStripMenuItem_Click);
            // 
            // extractCubeFacesToolStripMenuItem
            // 
            this.extractCubeFacesToolStripMenuItem.Name = "extractCubeFacesToolStripMenuItem";
            this.extractCubeFacesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.extractCubeFacesToolStripMenuItem.Text = "Extract Cube Faces";
            // 
            // extractNodeToolStripMenuItem
            // 
            this.extractNodeToolStripMenuItem.Name = "extractNodeToolStripMenuItem";
            this.extractNodeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.extractNodeToolStripMenuItem.Text = "Extract Cubemap";
            // 
            // frontImage
            // 
            this.frontImage.AllowDrop = true;
            this.frontImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.frontImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.frontImage.Controls.Add(this.fileNameLabel_Front);
            this.frontImage.Location = new System.Drawing.Point(330, 340);
            this.frontImage.Name = "frontImage";
            this.frontImage.Size = new System.Drawing.Size(320, 320);
            this.frontImage.TabIndex = 31;
            this.frontImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragDrop);
            this.frontImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragEnter);
            this.frontImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturePanel_MouseDown);
            // 
            // fileNameLabel_Front
            // 
            this.fileNameLabel_Front.AutoSize = true;
            this.fileNameLabel_Front.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel_Front.Location = new System.Drawing.Point(10, 9);
            this.fileNameLabel_Front.Name = "fileNameLabel_Front";
            this.fileNameLabel_Front.Size = new System.Drawing.Size(35, 14);
            this.fileNameLabel_Front.TabIndex = 1;
            this.fileNameLabel_Front.Text = "Front";
            // 
            // bottomImage
            // 
            this.bottomImage.AllowDrop = true;
            this.bottomImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.bottomImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottomImage.Controls.Add(this.fileNameLabel_Bottom);
            this.bottomImage.Location = new System.Drawing.Point(330, 660);
            this.bottomImage.Name = "bottomImage";
            this.bottomImage.Size = new System.Drawing.Size(320, 320);
            this.bottomImage.TabIndex = 32;
            this.bottomImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragDrop);
            this.bottomImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragEnter);
            this.bottomImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturePanel_MouseDown);
            // 
            // fileNameLabel_Bottom
            // 
            this.fileNameLabel_Bottom.AutoSize = true;
            this.fileNameLabel_Bottom.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel_Bottom.Location = new System.Drawing.Point(6, 6);
            this.fileNameLabel_Bottom.Name = "fileNameLabel_Bottom";
            this.fileNameLabel_Bottom.Size = new System.Drawing.Size(46, 14);
            this.fileNameLabel_Bottom.TabIndex = 0;
            this.fileNameLabel_Bottom.Text = "Bottom";
            // 
            // leftImage
            // 
            this.leftImage.AllowDrop = true;
            this.leftImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.leftImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftImage.Controls.Add(this.fileNameLabel_Left);
            this.leftImage.Location = new System.Drawing.Point(10, 340);
            this.leftImage.Name = "leftImage";
            this.leftImage.Size = new System.Drawing.Size(320, 320);
            this.leftImage.TabIndex = 34;
            this.leftImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragDrop);
            this.leftImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragEnter);
            this.leftImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturePanel_MouseDown);
            // 
            // fileNameLabel_Left
            // 
            this.fileNameLabel_Left.AutoSize = true;
            this.fileNameLabel_Left.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel_Left.Location = new System.Drawing.Point(7, 9);
            this.fileNameLabel_Left.Name = "fileNameLabel_Left";
            this.fileNameLabel_Left.Size = new System.Drawing.Size(26, 14);
            this.fileNameLabel_Left.TabIndex = 1;
            this.fileNameLabel_Left.Text = "Left";
            // 
            // rightImage
            // 
            this.rightImage.AllowDrop = true;
            this.rightImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.rightImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightImage.Controls.Add(this.fileNameLabel_Right);
            this.rightImage.Location = new System.Drawing.Point(650, 340);
            this.rightImage.Name = "rightImage";
            this.rightImage.Size = new System.Drawing.Size(320, 320);
            this.rightImage.TabIndex = 33;
            this.rightImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragDrop);
            this.rightImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragEnter);
            this.rightImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturePanel_MouseDown);
            // 
            // fileNameLabel_Right
            // 
            this.fileNameLabel_Right.AutoSize = true;
            this.fileNameLabel_Right.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel_Right.Location = new System.Drawing.Point(6, 9);
            this.fileNameLabel_Right.Name = "fileNameLabel_Right";
            this.fileNameLabel_Right.Size = new System.Drawing.Size(35, 14);
            this.fileNameLabel_Right.TabIndex = 2;
            this.fileNameLabel_Right.Text = "Right";
            // 
            // topImage
            // 
            this.topImage.AllowDrop = true;
            this.topImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.topImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topImage.Controls.Add(this.fileNameLabel_Top);
            this.topImage.Location = new System.Drawing.Point(330, 20);
            this.topImage.Name = "topImage";
            this.topImage.Size = new System.Drawing.Size(320, 320);
            this.topImage.TabIndex = 30;
            this.topImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragDrop);
            this.topImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragEnter);
            this.topImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturePanel_MouseDown);
            // 
            // fileNameLabel_Top
            // 
            this.fileNameLabel_Top.AutoSize = true;
            this.fileNameLabel_Top.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel_Top.Location = new System.Drawing.Point(10, 2);
            this.fileNameLabel_Top.Name = "fileNameLabel_Top";
            this.fileNameLabel_Top.Size = new System.Drawing.Size(26, 14);
            this.fileNameLabel_Top.TabIndex = 2;
            this.fileNameLabel_Top.Text = "Top";
            // 
            // backImage
            // 
            this.backImage.AllowDrop = true;
            this.backImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.backImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backImage.Controls.Add(this.fileNameLabel_Back);
            this.backImage.Location = new System.Drawing.Point(970, 340);
            this.backImage.Name = "backImage";
            this.backImage.Size = new System.Drawing.Size(320, 320);
            this.backImage.TabIndex = 32;
            this.backImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragDrop);
            this.backImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picturePanel_DragEnter);
            this.backImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picturePanel_MouseDown);
            // 
            // fileNameLabel_Back
            // 
            this.fileNameLabel_Back.AutoSize = true;
            this.fileNameLabel_Back.BackColor = System.Drawing.Color.Transparent;
            this.fileNameLabel_Back.Location = new System.Drawing.Point(6, 9);
            this.fileNameLabel_Back.Name = "fileNameLabel_Back";
            this.fileNameLabel_Back.Size = new System.Drawing.Size(32, 14);
            this.fileNameLabel_Back.TabIndex = 2;
            this.fileNameLabel_Back.Text = "Back";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(971, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NodePropertiesGroup);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 334);
            this.panel1.TabIndex = 18;
            // 
            // NodePropertiesGroup
            // 
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_NumberInput);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_Depth);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_ClassificationInput);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_rotationZ);
            this.NodePropertiesGroup.Controls.Add(this.label_PosZ);
            this.NodePropertiesGroup.Controls.Add(this.label_PosY);
            this.NodePropertiesGroup.Controls.Add(this.label_PosX);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_PosZ);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_PosY);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_PosX);
            this.NodePropertiesGroup.Controls.Add(this.label_DepthRange);
            this.NodePropertiesGroup.Controls.Add(this.mapTypeDepth);
            this.NodePropertiesGroup.Controls.Add(this.mapTypeColor);
            this.NodePropertiesGroup.Controls.Add(this.label_Classification);
            this.NodePropertiesGroup.Controls.Add(this.label_Rotation);
            this.NodePropertiesGroup.Controls.Add(this.label_Position);
            this.NodePropertiesGroup.Controls.Add(this.SaveButton);
            this.NodePropertiesGroup.Controls.Add(this.label_Scene);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_ZoneInput);
            this.NodePropertiesGroup.Controls.Add(this.nodeProp_SceneInput);
            this.NodePropertiesGroup.Controls.Add(this.label_Number);
            this.NodePropertiesGroup.Controls.Add(this.label_Zone);
            this.NodePropertiesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodePropertiesGroup.ForeColor = System.Drawing.Color.Gainsboro;
            this.NodePropertiesGroup.Location = new System.Drawing.Point(0, 0);
            this.NodePropertiesGroup.Margin = new System.Windows.Forms.Padding(1);
            this.NodePropertiesGroup.Name = "NodePropertiesGroup";
            this.NodePropertiesGroup.Size = new System.Drawing.Size(324, 334);
            this.NodePropertiesGroup.TabIndex = 24;
            this.NodePropertiesGroup.TabStop = false;
            this.NodePropertiesGroup.Text = "Node Identity";
            // 
            // nodeProp_NumberInput
            // 
            this.nodeProp_NumberInput.Location = new System.Drawing.Point(9, 120);
            this.nodeProp_NumberInput.Name = "nodeProp_NumberInput";
            this.nodeProp_NumberInput.Size = new System.Drawing.Size(184, 22);
            this.nodeProp_NumberInput.TabIndex = 37;
            // 
            // nodeProp_Depth
            // 
            this.nodeProp_Depth.DecimalPlaces = 1;
            this.nodeProp_Depth.Location = new System.Drawing.Point(228, 293);
            this.nodeProp_Depth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_Depth.Name = "nodeProp_Depth";
            this.nodeProp_Depth.Size = new System.Drawing.Size(74, 22);
            this.nodeProp_Depth.TabIndex = 36;
            // 
            // nodeProp_ClassificationInput
            // 
            this.nodeProp_ClassificationInput.FormattingEnabled = true;
            this.nodeProp_ClassificationInput.Location = new System.Drawing.Point(9, 162);
            this.nodeProp_ClassificationInput.Name = "nodeProp_ClassificationInput";
            this.nodeProp_ClassificationInput.Size = new System.Drawing.Size(184, 22);
            this.nodeProp_ClassificationInput.TabIndex = 35;
            // 
            // nodeProp_rotationZ
            // 
            this.nodeProp_rotationZ.DecimalPlaces = 1;
            this.nodeProp_rotationZ.Location = new System.Drawing.Point(92, 207);
            this.nodeProp_rotationZ.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_rotationZ.Name = "nodeProp_rotationZ";
            this.nodeProp_rotationZ.Size = new System.Drawing.Size(74, 22);
            this.nodeProp_rotationZ.TabIndex = 34;
            // 
            // label_PosZ
            // 
            this.label_PosZ.AutoSize = true;
            this.label_PosZ.Location = new System.Drawing.Point(9, 295);
            this.label_PosZ.Name = "label_PosZ";
            this.label_PosZ.Size = new System.Drawing.Size(13, 14);
            this.label_PosZ.TabIndex = 33;
            this.label_PosZ.Text = "Z";
            // 
            // label_PosY
            // 
            this.label_PosY.AutoSize = true;
            this.label_PosY.Location = new System.Drawing.Point(9, 271);
            this.label_PosY.Name = "label_PosY";
            this.label_PosY.Size = new System.Drawing.Size(13, 14);
            this.label_PosY.TabIndex = 32;
            this.label_PosY.Text = "Y";
            // 
            // label_PosX
            // 
            this.label_PosX.AutoSize = true;
            this.label_PosX.Location = new System.Drawing.Point(9, 249);
            this.label_PosX.Name = "label_PosX";
            this.label_PosX.Size = new System.Drawing.Size(13, 14);
            this.label_PosX.TabIndex = 31;
            this.label_PosX.Text = "X";
            // 
            // nodeProp_PosZ
            // 
            this.nodeProp_PosZ.DecimalPlaces = 1;
            this.nodeProp_PosZ.Location = new System.Drawing.Point(26, 293);
            this.nodeProp_PosZ.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_PosZ.Name = "nodeProp_PosZ";
            this.nodeProp_PosZ.Size = new System.Drawing.Size(74, 22);
            this.nodeProp_PosZ.TabIndex = 30;
            // 
            // nodeProp_PosY
            // 
            this.nodeProp_PosY.DecimalPlaces = 1;
            this.nodeProp_PosY.Location = new System.Drawing.Point(26, 269);
            this.nodeProp_PosY.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_PosY.Name = "nodeProp_PosY";
            this.nodeProp_PosY.Size = new System.Drawing.Size(74, 22);
            this.nodeProp_PosY.TabIndex = 29;
            // 
            // nodeProp_PosX
            // 
            this.nodeProp_PosX.DecimalPlaces = 1;
            this.nodeProp_PosX.Location = new System.Drawing.Point(26, 245);
            this.nodeProp_PosX.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_PosX.Name = "nodeProp_PosX";
            this.nodeProp_PosX.Size = new System.Drawing.Size(74, 22);
            this.nodeProp_PosX.TabIndex = 28;
            // 
            // label_DepthRange
            // 
            this.label_DepthRange.AutoSize = true;
            this.label_DepthRange.Location = new System.Drawing.Point(225, 271);
            this.label_DepthRange.Name = "label_DepthRange";
            this.label_DepthRange.Size = new System.Drawing.Size(77, 14);
            this.label_DepthRange.TabIndex = 27;
            this.label_DepthRange.Text = "Depth Range";
            // 
            // mapTypeDepth
            // 
            this.mapTypeDepth.AutoSize = true;
            this.mapTypeDepth.Location = new System.Drawing.Point(228, 245);
            this.mapTypeDepth.Name = "mapTypeDepth";
            this.mapTypeDepth.Size = new System.Drawing.Size(85, 18);
            this.mapTypeDepth.TabIndex = 26;
            this.mapTypeDepth.TabStop = true;
            this.mapTypeDepth.Text = "Depth Map";
            this.mapTypeDepth.UseVisualStyleBackColor = true;
            // 
            // mapTypeColor
            // 
            this.mapTypeColor.AutoSize = true;
            this.mapTypeColor.Location = new System.Drawing.Point(228, 226);
            this.mapTypeColor.Name = "mapTypeColor";
            this.mapTypeColor.Size = new System.Drawing.Size(80, 18);
            this.mapTypeColor.TabIndex = 25;
            this.mapTypeColor.TabStop = true;
            this.mapTypeColor.Text = "Color Map";
            this.mapTypeColor.UseVisualStyleBackColor = true;
            this.mapTypeColor.CheckedChanged += new System.EventHandler(this.mapTypeColor_CheckedChanged);
            // 
            // label_Classification
            // 
            this.label_Classification.AutoSize = true;
            this.label_Classification.Location = new System.Drawing.Point(9, 144);
            this.label_Classification.Name = "label_Classification";
            this.label_Classification.Size = new System.Drawing.Size(79, 14);
            this.label_Classification.TabIndex = 24;
            this.label_Classification.Text = "Classification";
            // 
            // label_Rotation
            // 
            this.label_Rotation.AutoSize = true;
            this.label_Rotation.Location = new System.Drawing.Point(9, 209);
            this.label_Rotation.Name = "label_Rotation";
            this.label_Rotation.Size = new System.Drawing.Size(77, 14);
            this.label_Rotation.TabIndex = 23;
            this.label_Rotation.Text = "Yaw Rotation";
            // 
            // label_Position
            // 
            this.label_Position.AutoSize = true;
            this.label_Position.Location = new System.Drawing.Point(23, 228);
            this.label_Position.Name = "label_Position";
            this.label_Position.Size = new System.Drawing.Size(51, 14);
            this.label_Position.TabIndex = 22;
            this.label_Position.Text = "Position";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.SaveButton.Location = new System.Drawing.Point(213, 37);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(97, 36);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save Changes";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label_Scene
            // 
            this.label_Scene.AutoSize = true;
            this.label_Scene.Location = new System.Drawing.Point(9, 18);
            this.label_Scene.Name = "label_Scene";
            this.label_Scene.Size = new System.Drawing.Size(39, 14);
            this.label_Scene.TabIndex = 20;
            this.label_Scene.Text = "Scene";
            // 
            // nodeProp_ZoneInput
            // 
            this.nodeProp_ZoneInput.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeProp_ZoneInput.Location = new System.Drawing.Point(9, 78);
            this.nodeProp_ZoneInput.Name = "nodeProp_ZoneInput";
            this.nodeProp_ZoneInput.Size = new System.Drawing.Size(184, 21);
            this.nodeProp_ZoneInput.TabIndex = 19;
            // 
            // nodeProp_SceneInput
            // 
            this.nodeProp_SceneInput.Location = new System.Drawing.Point(9, 36);
            this.nodeProp_SceneInput.Name = "nodeProp_SceneInput";
            this.nodeProp_SceneInput.Size = new System.Drawing.Size(184, 22);
            this.nodeProp_SceneInput.TabIndex = 8;
            // 
            // label_Number
            // 
            this.label_Number.AutoSize = true;
            this.label_Number.Location = new System.Drawing.Point(9, 102);
            this.label_Number.Name = "label_Number";
            this.label_Number.Size = new System.Drawing.Size(50, 14);
            this.label_Number.TabIndex = 18;
            this.label_Number.Text = "Number";
            // 
            // label_Zone
            // 
            this.label_Zone.AutoSize = true;
            this.label_Zone.Location = new System.Drawing.Point(9, 60);
            this.label_Zone.Name = "label_Zone";
            this.label_Zone.Size = new System.Drawing.Size(34, 14);
            this.label_Zone.TabIndex = 9;
            this.label_Zone.Text = "Zone";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(5, 663);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 350);
            this.panel2.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExportAllCubemaps);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 350);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // ExportAllCubemaps
            // 
            this.ExportAllCubemaps.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ExportAllCubemaps.Location = new System.Drawing.Point(21, 23);
            this.ExportAllCubemaps.Name = "ExportAllCubemaps";
            this.ExportAllCubemaps.Size = new System.Drawing.Size(261, 58);
            this.ExportAllCubemaps.TabIndex = 1;
            this.ExportAllCubemaps.Text = "Export All Cubemaps";
            this.ExportAllCubemaps.UseVisualStyleBackColor = false;
            this.ExportAllCubemaps.Click += new System.EventHandler(this.ExportAllCubemaps_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(680, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 14);
            this.label6.TabIndex = 26;
            this.label6.Text = "Associated Images";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(656, 666);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 350);
            this.panel3.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.separateImagesCheckbox);
            this.groupBox2.Controls.Add(this.exportButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 350);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // separateImagesCheckbox
            // 
            this.separateImagesCheckbox.AutoSize = true;
            this.separateImagesCheckbox.Location = new System.Drawing.Point(29, 20);
            this.separateImagesCheckbox.Name = "separateImagesCheckbox";
            this.separateImagesCheckbox.Size = new System.Drawing.Size(118, 18);
            this.separateImagesCheckbox.TabIndex = 21;
            this.separateImagesCheckbox.Text = "Separate Images";
            this.separateImagesCheckbox.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.exportButton.Location = new System.Drawing.Point(29, 72);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(261, 58);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Export Panorama";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(683, 50);
            this.listBox2.Margin = new System.Windows.Forms.Padding(0);
            this.listBox2.MinimumSize = new System.Drawing.Size(100, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(288, 270);
            this.listBox2.TabIndex = 25;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Controls.Add(this.splitContainer1);
            this.MainPanel.Location = new System.Drawing.Point(0, 26);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1549, 865);
            this.MainPanel.TabIndex = 18;
            // 
            // nodeViewerMenuStrip
            // 
            this.nodeViewerMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nodeViewerMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.nodeViewerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadRegistry,
            this.toolStripSeparator1,
            this.saveRegistry});
            this.nodeViewerMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.nodeViewerMenuStrip.Name = "nodeViewerMenuStrip";
            this.nodeViewerMenuStrip.Size = new System.Drawing.Size(1549, 25);
            this.nodeViewerMenuStrip.TabIndex = 25;
            this.nodeViewerMenuStrip.Text = "toolStrip1";
            // 
            // loadRegistry
            // 
            this.loadRegistry.Name = "loadRegistry";
            this.loadRegistry.Size = new System.Drawing.Size(123, 22);
            this.loadRegistry.Text = "Load Custom Registry";
            this.loadRegistry.Click += new System.EventHandler(this.loadRegistry_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // saveRegistry
            // 
            this.saveRegistry.Name = "saveRegistry";
            this.saveRegistry.Size = new System.Drawing.Size(121, 22);
            this.saveRegistry.Text = "Save Custom Registry";
            this.saveRegistry.Click += new System.EventHandler(this.saveRegistry_Click);
            // 
            // contextMenuNodeViewer
            // 
            this.contextMenuNodeViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.extractCubemapsToolStripMenuItem});
            this.contextMenuNodeViewer.Name = "contextMenuNodeViewer";
            this.contextMenuNodeViewer.Size = new System.Drawing.Size(170, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem1.Text = "Add Node";
            // 
            // extractCubemapsToolStripMenuItem
            // 
            this.extractCubemapsToolStripMenuItem.Name = "extractCubemapsToolStripMenuItem";
            this.extractCubemapsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.extractCubemapsToolStripMenuItem.Text = "Extract Cubemaps";
            this.extractCubemapsToolStripMenuItem.Click += new System.EventHandler(this.extractCubemapsToolStripMenuItem_Click);
            // 
            // openFolderDialog
            // 
            this.openFolderDialog.FileName = "Select Folder";
            // 
            // NodeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1549, 891);
            this.Controls.Add(this.nodeViewerMenuStrip);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "NodeViewer";
            this.Text = "Node Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NodeViewer_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuNode.ResumeLayout(false);
            this.frontImage.ResumeLayout(false);
            this.frontImage.PerformLayout();
            this.bottomImage.ResumeLayout(false);
            this.bottomImage.PerformLayout();
            this.leftImage.ResumeLayout(false);
            this.leftImage.PerformLayout();
            this.rightImage.ResumeLayout(false);
            this.rightImage.PerformLayout();
            this.topImage.ResumeLayout(false);
            this.topImage.PerformLayout();
            this.backImage.ResumeLayout(false);
            this.backImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.NodePropertiesGroup.ResumeLayout(false);
            this.NodePropertiesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_Depth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_rotationZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosX)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.nodeViewerMenuStrip.ResumeLayout(false);
            this.nodeViewerMenuStrip.PerformLayout();
            this.contextMenuNodeViewer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView nodeExplorer;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_Scene;
        private System.Windows.Forms.TextBox nodeProp_ZoneInput;
        private System.Windows.Forms.TextBox nodeProp_SceneInput;
        private System.Windows.Forms.Label label_Number;
        private System.Windows.Forms.Label label_Zone;
        private System.Windows.Forms.ToolStrip nodeViewerMenuStrip;
        private System.Windows.Forms.ToolStripLabel loadRegistry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel saveRegistry;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox separateImagesCheckbox;
        private System.Windows.Forms.Label label_Rotation;
        private System.Windows.Forms.Label label_Position;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_Classification;
        private System.Windows.Forms.RadioButton mapTypeDepth;
        private System.Windows.Forms.RadioButton mapTypeColor;
        private System.Windows.Forms.Label label_DepthRange;
        private System.Windows.Forms.ContextMenuStrip contextMenuNode;
        private System.Windows.Forms.ToolStripMenuItem extractNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown nodeProp_rotationZ;
        private System.Windows.Forms.Label label_PosZ;
        private System.Windows.Forms.Label label_PosY;
        private System.Windows.Forms.Label label_PosX;
        private System.Windows.Forms.NumericUpDown nodeProp_PosZ;
        private System.Windows.Forms.NumericUpDown nodeProp_PosY;
        private System.Windows.Forms.NumericUpDown nodeProp_PosX;
        private System.Windows.Forms.NumericUpDown nodeProp_Depth;
        private System.Windows.Forms.ComboBox nodeProp_ClassificationInput;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TextBox nodeProp_NumberInput;
        private System.Windows.Forms.Panel topImage;
        private System.Windows.Forms.Panel backImage;
        private System.Windows.Forms.Panel bottomImage;
        private System.Windows.Forms.Panel leftImage;
        private System.Windows.Forms.Panel rightImage;
        protected System.Windows.Forms.GroupBox NodePropertiesGroup;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label fileNameLabel_Bottom;
        private System.Windows.Forms.Label fileNameLabel_Left;
        private System.Windows.Forms.Label fileNameLabel_Right;
        private System.Windows.Forms.Label fileNameLabel_Top;
        private System.Windows.Forms.Label fileNameLabel_Back;
        private System.Windows.Forms.Panel frontImage;
        private System.Windows.Forms.Label fileNameLabel_Front;
        private System.Windows.Forms.ToolStripMenuItem extractCubeFacesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuNodeViewer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractCubemapsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFolderDialog;
        private System.Windows.Forms.Button ExportAllCubemaps;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}