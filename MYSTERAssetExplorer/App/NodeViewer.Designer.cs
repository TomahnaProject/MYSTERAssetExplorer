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
            this.contextMenuNodeExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractAllChildNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomImage = new System.Windows.Forms.Panel();
            this.leftImage = new System.Windows.Forms.Panel();
            this.rightImage = new System.Windows.Forms.Panel();
            this.backImage = new System.Windows.Forms.Panel();
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
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.frontImage = new System.Windows.Forms.Panel();
            this.topImage = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.nodeViewerMenuStrip = new System.Windows.Forms.ToolStrip();
            this.loadRegistry = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveRegistry = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuNodeExplorer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.NodePropertiesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_Depth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_rotationZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeProp_PosX)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.nodeViewerMenuStrip.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.bottomImage);
            this.splitContainer1.Panel2.Controls.Add(this.leftImage);
            this.splitContainer1.Panel2.Controls.Add(this.rightImage);
            this.splitContainer1.Panel2.Controls.Add(this.backImage);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.listBox2);
            this.splitContainer1.Panel2.Controls.Add(this.frontImage);
            this.splitContainer1.Panel2.Controls.Add(this.topImage);
            this.splitContainer1.Size = new System.Drawing.Size(1549, 803);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 18;
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
            this.nodeExplorer.Size = new System.Drawing.Size(253, 803);
            this.nodeExplorer.TabIndex = 23;
            this.nodeExplorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.nodeExplorer_NodeMouseClick);
            // 
            // contextMenuNodeExplorer
            // 
            this.contextMenuNodeExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeToolStripMenuItem,
            this.extractNodeToolStripMenuItem,
            this.extractAllChildNodesToolStripMenuItem,
            this.removeNodeToolStripMenuItem});
            this.contextMenuNodeExplorer.Name = "contextMenuFolderExplorer";
            this.contextMenuNodeExplorer.Size = new System.Drawing.Size(195, 92);
            this.contextMenuNodeExplorer.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuNodeExplorer_Opening);
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            this.addNodeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addNodeToolStripMenuItem.Text = "Add Node";
            this.addNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
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
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.removeNodeToolStripMenuItem.Text = "Remove Node";
            this.removeNodeToolStripMenuItem.Click += new System.EventHandler(this.removeNodeToolStripMenuItem_Click);
            // 
            // bottomImage
            // 
            this.bottomImage.AllowDrop = true;
            this.bottomImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.bottomImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottomImage.Location = new System.Drawing.Point(331, 651);
            this.bottomImage.Name = "bottomImage";
            this.bottomImage.Size = new System.Drawing.Size(320, 320);
            this.bottomImage.TabIndex = 32;
            this.bottomImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picBox_DragDrop);
            this.bottomImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picBox_DragEnter);
            this.bottomImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            // 
            // leftImage
            // 
            this.leftImage.AllowDrop = true;
            this.leftImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.leftImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftImage.Location = new System.Drawing.Point(11, 331);
            this.leftImage.Name = "leftImage";
            this.leftImage.Size = new System.Drawing.Size(320, 320);
            this.leftImage.TabIndex = 34;
            this.leftImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picBox_DragDrop);
            this.leftImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picBox_DragEnter);
            this.leftImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            // 
            // rightImage
            // 
            this.rightImage.AllowDrop = true;
            this.rightImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.rightImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightImage.Location = new System.Drawing.Point(651, 331);
            this.rightImage.Name = "rightImage";
            this.rightImage.Size = new System.Drawing.Size(320, 320);
            this.rightImage.TabIndex = 33;
            this.rightImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picBox_DragDrop);
            this.rightImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picBox_DragEnter);
            this.rightImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            // 
            // backImage
            // 
            this.backImage.AllowDrop = true;
            this.backImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.backImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backImage.Location = new System.Drawing.Point(971, 331);
            this.backImage.Name = "backImage";
            this.backImage.Size = new System.Drawing.Size(320, 320);
            this.backImage.TabIndex = 32;
            this.backImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picBox_DragDrop);
            this.backImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picBox_DragEnter);
            this.backImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(971, 46);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 264);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NodePropertiesGroup);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 325);
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
            this.NodePropertiesGroup.Name = "NodePropertiesGroup";
            this.NodePropertiesGroup.Size = new System.Drawing.Size(325, 325);
            this.NodePropertiesGroup.TabIndex = 24;
            this.NodePropertiesGroup.TabStop = false;
            this.NodePropertiesGroup.Text = "Node Identity";
            // 
            // nodeProp_NumberInput
            // 
            this.nodeProp_NumberInput.Location = new System.Drawing.Point(9, 111);
            this.nodeProp_NumberInput.Name = "nodeProp_NumberInput";
            this.nodeProp_NumberInput.Size = new System.Drawing.Size(184, 20);
            this.nodeProp_NumberInput.TabIndex = 37;
            // 
            // nodeProp_Depth
            // 
            this.nodeProp_Depth.DecimalPlaces = 1;
            this.nodeProp_Depth.Location = new System.Drawing.Point(222, 290);
            this.nodeProp_Depth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_Depth.Name = "nodeProp_Depth";
            this.nodeProp_Depth.Size = new System.Drawing.Size(74, 20);
            this.nodeProp_Depth.TabIndex = 36;
            // 
            // nodeProp_ClassificationInput
            // 
            this.nodeProp_ClassificationInput.FormattingEnabled = true;
            this.nodeProp_ClassificationInput.Location = new System.Drawing.Point(9, 150);
            this.nodeProp_ClassificationInput.Name = "nodeProp_ClassificationInput";
            this.nodeProp_ClassificationInput.Size = new System.Drawing.Size(184, 21);
            this.nodeProp_ClassificationInput.TabIndex = 35;
            // 
            // nodeProp_rotationZ
            // 
            this.nodeProp_rotationZ.DecimalPlaces = 1;
            this.nodeProp_rotationZ.Location = new System.Drawing.Point(86, 200);
            this.nodeProp_rotationZ.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_rotationZ.Name = "nodeProp_rotationZ";
            this.nodeProp_rotationZ.Size = new System.Drawing.Size(74, 20);
            this.nodeProp_rotationZ.TabIndex = 34;
            // 
            // label_PosZ
            // 
            this.label_PosZ.AutoSize = true;
            this.label_PosZ.Location = new System.Drawing.Point(7, 292);
            this.label_PosZ.Name = "label_PosZ";
            this.label_PosZ.Size = new System.Drawing.Size(14, 13);
            this.label_PosZ.TabIndex = 33;
            this.label_PosZ.Text = "Z";
            // 
            // label_PosY
            // 
            this.label_PosY.AutoSize = true;
            this.label_PosY.Location = new System.Drawing.Point(7, 266);
            this.label_PosY.Name = "label_PosY";
            this.label_PosY.Size = new System.Drawing.Size(14, 13);
            this.label_PosY.TabIndex = 32;
            this.label_PosY.Text = "Y";
            // 
            // label_PosX
            // 
            this.label_PosX.AutoSize = true;
            this.label_PosX.Location = new System.Drawing.Point(7, 240);
            this.label_PosX.Name = "label_PosX";
            this.label_PosX.Size = new System.Drawing.Size(14, 13);
            this.label_PosX.TabIndex = 31;
            this.label_PosX.Text = "X";
            // 
            // nodeProp_PosZ
            // 
            this.nodeProp_PosZ.DecimalPlaces = 1;
            this.nodeProp_PosZ.Location = new System.Drawing.Point(27, 290);
            this.nodeProp_PosZ.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_PosZ.Name = "nodeProp_PosZ";
            this.nodeProp_PosZ.Size = new System.Drawing.Size(74, 20);
            this.nodeProp_PosZ.TabIndex = 30;
            // 
            // nodeProp_PosY
            // 
            this.nodeProp_PosY.DecimalPlaces = 1;
            this.nodeProp_PosY.Location = new System.Drawing.Point(27, 264);
            this.nodeProp_PosY.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_PosY.Name = "nodeProp_PosY";
            this.nodeProp_PosY.Size = new System.Drawing.Size(74, 20);
            this.nodeProp_PosY.TabIndex = 29;
            // 
            // nodeProp_PosX
            // 
            this.nodeProp_PosX.DecimalPlaces = 1;
            this.nodeProp_PosX.Location = new System.Drawing.Point(27, 238);
            this.nodeProp_PosX.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeProp_PosX.Name = "nodeProp_PosX";
            this.nodeProp_PosX.Size = new System.Drawing.Size(74, 20);
            this.nodeProp_PosX.TabIndex = 28;
            // 
            // label_DepthRange
            // 
            this.label_DepthRange.AutoSize = true;
            this.label_DepthRange.Location = new System.Drawing.Point(219, 274);
            this.label_DepthRange.Name = "label_DepthRange";
            this.label_DepthRange.Size = new System.Drawing.Size(71, 13);
            this.label_DepthRange.TabIndex = 27;
            this.label_DepthRange.Text = "Depth Range";
            // 
            // mapTypeDepth
            // 
            this.mapTypeDepth.AutoSize = true;
            this.mapTypeDepth.Location = new System.Drawing.Point(223, 250);
            this.mapTypeDepth.Name = "mapTypeDepth";
            this.mapTypeDepth.Size = new System.Drawing.Size(78, 17);
            this.mapTypeDepth.TabIndex = 26;
            this.mapTypeDepth.TabStop = true;
            this.mapTypeDepth.Text = "Depth Map";
            this.mapTypeDepth.UseVisualStyleBackColor = true;
            // 
            // mapTypeColor
            // 
            this.mapTypeColor.AutoSize = true;
            this.mapTypeColor.Location = new System.Drawing.Point(223, 227);
            this.mapTypeColor.Name = "mapTypeColor";
            this.mapTypeColor.Size = new System.Drawing.Size(73, 17);
            this.mapTypeColor.TabIndex = 25;
            this.mapTypeColor.TabStop = true;
            this.mapTypeColor.Text = "Color Map";
            this.mapTypeColor.UseVisualStyleBackColor = true;
            // 
            // label_Classification
            // 
            this.label_Classification.AutoSize = true;
            this.label_Classification.Location = new System.Drawing.Point(9, 134);
            this.label_Classification.Name = "label_Classification";
            this.label_Classification.Size = new System.Drawing.Size(68, 13);
            this.label_Classification.TabIndex = 24;
            this.label_Classification.Text = "Classification";
            // 
            // label_Rotation
            // 
            this.label_Rotation.AutoSize = true;
            this.label_Rotation.Location = new System.Drawing.Point(9, 202);
            this.label_Rotation.Name = "label_Rotation";
            this.label_Rotation.Size = new System.Drawing.Size(71, 13);
            this.label_Rotation.TabIndex = 23;
            this.label_Rotation.Text = "Yaw Rotation";
            // 
            // label_Position
            // 
            this.label_Position.AutoSize = true;
            this.label_Position.Location = new System.Drawing.Point(7, 222);
            this.label_Position.Name = "label_Position";
            this.label_Position.Size = new System.Drawing.Size(44, 13);
            this.label_Position.TabIndex = 22;
            this.label_Position.Text = "Position";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.SaveButton.Location = new System.Drawing.Point(213, 34);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(97, 33);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save Changes";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label_Scene
            // 
            this.label_Scene.AutoSize = true;
            this.label_Scene.Location = new System.Drawing.Point(9, 17);
            this.label_Scene.Name = "label_Scene";
            this.label_Scene.Size = new System.Drawing.Size(38, 13);
            this.label_Scene.TabIndex = 20;
            this.label_Scene.Text = "Scene";
            // 
            // nodeProp_ZoneInput
            // 
            this.nodeProp_ZoneInput.Location = new System.Drawing.Point(9, 72);
            this.nodeProp_ZoneInput.Name = "nodeProp_ZoneInput";
            this.nodeProp_ZoneInput.Size = new System.Drawing.Size(184, 20);
            this.nodeProp_ZoneInput.TabIndex = 19;
            // 
            // nodeProp_SceneInput
            // 
            this.nodeProp_SceneInput.Location = new System.Drawing.Point(9, 33);
            this.nodeProp_SceneInput.Name = "nodeProp_SceneInput";
            this.nodeProp_SceneInput.Size = new System.Drawing.Size(184, 20);
            this.nodeProp_SceneInput.TabIndex = 8;
            // 
            // label_Number
            // 
            this.label_Number.AutoSize = true;
            this.label_Number.Location = new System.Drawing.Point(9, 95);
            this.label_Number.Name = "label_Number";
            this.label_Number.Size = new System.Drawing.Size(44, 13);
            this.label_Number.TabIndex = 18;
            this.label_Number.Text = "Number";
            // 
            // label_Zone
            // 
            this.label_Zone.AutoSize = true;
            this.label_Zone.Location = new System.Drawing.Point(9, 56);
            this.label_Zone.Name = "label_Zone";
            this.label_Zone.Size = new System.Drawing.Size(32, 13);
            this.label_Zone.TabIndex = 9;
            this.label_Zone.Text = "Zone";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(6, 654);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 325);
            this.panel2.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 325);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(680, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Associated Images";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(654, 654);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 325);
            this.panel3.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 325);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(29, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Separate Images";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(683, 46);
            this.listBox2.Margin = new System.Windows.Forms.Padding(0);
            this.listBox2.MinimumSize = new System.Drawing.Size(100, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(288, 264);
            this.listBox2.TabIndex = 25;
            // 
            // frontImage
            // 
            this.frontImage.AllowDrop = true;
            this.frontImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.frontImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.frontImage.Location = new System.Drawing.Point(331, 331);
            this.frontImage.Name = "frontImage";
            this.frontImage.Size = new System.Drawing.Size(320, 320);
            this.frontImage.TabIndex = 31;
            this.frontImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picBox_DragDrop);
            this.frontImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picBox_DragEnter);
            this.frontImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            // 
            // topImage
            // 
            this.topImage.AllowDrop = true;
            this.topImage.BackgroundImage = global::MYSTERAssetExplorer.Properties.Resources.picture_icon_large;
            this.topImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topImage.Location = new System.Drawing.Point(331, 11);
            this.topImage.Name = "topImage";
            this.topImage.Size = new System.Drawing.Size(320, 320);
            this.topImage.TabIndex = 30;
            this.topImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.picBox_DragDrop);
            this.topImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.picBox_DragEnter);
            this.topImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Controls.Add(this.splitContainer1);
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1549, 803);
            this.MainPanel.TabIndex = 18;
            // 
            // nodeViewerMenuStrip
            // 
            this.nodeViewerMenuStrip.BackColor = System.Drawing.Color.Gray;
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
            this.loadRegistry.Size = new System.Drawing.Size(78, 22);
            this.loadRegistry.Text = "Load Registry";
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
            this.saveRegistry.Size = new System.Drawing.Size(76, 22);
            this.saveRegistry.Text = "Save Registry";
            this.saveRegistry.Click += new System.EventHandler(this.saveRegistry_Click);
            // 
            // NodeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1549, 827);
            this.Controls.Add(this.nodeViewerMenuStrip);
            this.Controls.Add(this.MainPanel);
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
            this.contextMenuNodeExplorer.ResumeLayout(false);
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
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.nodeViewerMenuStrip.ResumeLayout(false);
            this.nodeViewerMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView nodeExplorer;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox NodePropertiesGroup;
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label_Rotation;
        private System.Windows.Forms.Label label_Position;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_Classification;
        private System.Windows.Forms.RadioButton mapTypeDepth;
        private System.Windows.Forms.RadioButton mapTypeColor;
        private System.Windows.Forms.Label label_DepthRange;
        private System.Windows.Forms.ContextMenuStrip contextMenuNodeExplorer;
        private System.Windows.Forms.ToolStripMenuItem extractNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractAllChildNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nodeProp_NumberInput;
        private System.Windows.Forms.Panel topImage;
        private System.Windows.Forms.Panel frontImage;
        private System.Windows.Forms.Panel backImage;
        private System.Windows.Forms.Panel bottomImage;
        private System.Windows.Forms.Panel leftImage;
        private System.Windows.Forms.Panel rightImage;
    }
}