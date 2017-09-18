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
            this.fileListing = new System.Windows.Forms.ListBox();
            this.splitContainerFooter = new System.Windows.Forms.SplitContainer();
            this.previewGroup = new System.Windows.Forms.GroupBox();
            this.extractGroup = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RemoveNode = new System.Windows.Forms.Button();
            this.AddNode = new System.Windows.Forms.Button();
            this.NodePropertiesGroup = new System.Windows.Forms.GroupBox();
            this.nodeNumber = new System.Windows.Forms.NumericUpDown();
            this.nodeProp_SceneInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeListing = new System.Windows.Forms.TreeView();
            this.button2 = new System.Windows.Forms.Button();
            this.nextSelectionButton = new System.Windows.Forms.Button();
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
            this.nodeProp_ZoneInput = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFooter)).BeginInit();
            this.splitContainerFooter.Panel1.SuspendLayout();
            this.splitContainerFooter.Panel2.SuspendLayout();
            this.splitContainerFooter.SuspendLayout();
            this.previewGroup.SuspendLayout();
            this.extractGroup.SuspendLayout();
            this.NodePropertiesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeNumber)).BeginInit();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFolderDialog
            // 
            this.openFolderDialog.FileName = "Select Folder";
            // 
            // fileListing
            // 
            this.fileListing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListing.BackColor = System.Drawing.Color.Black;
            this.fileListing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.fileListing.FormattingEnabled = true;
            this.fileListing.Location = new System.Drawing.Point(-1, 15);
            this.fileListing.Margin = new System.Windows.Forms.Padding(0);
            this.fileListing.MinimumSize = new System.Drawing.Size(100, 4);
            this.fileListing.Name = "fileListing";
            this.fileListing.ScrollAlwaysVisible = true;
            this.fileListing.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.fileListing.Size = new System.Drawing.Size(191, 615);
            this.fileListing.TabIndex = 6;
            this.fileListing.SelectedIndexChanged += new System.EventHandler(this.fileListing_SelectedIndexChanged);
            // 
            // splitContainerFooter
            // 
            this.splitContainerFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerFooter.Location = new System.Drawing.Point(0, 25);
            this.splitContainerFooter.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerFooter.Name = "splitContainerFooter";
            this.splitContainerFooter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFooter.Panel1
            // 
            this.splitContainerFooter.Panel1.Controls.Add(this.nextSelectionButton);
            this.splitContainerFooter.Panel1.Controls.Add(this.button2);
            this.splitContainerFooter.Panel1.Controls.Add(this.previewGroup);
            this.splitContainerFooter.Panel1.Controls.Add(this.extractGroup);
            this.splitContainerFooter.Panel1.Controls.Add(this.RemoveNode);
            this.splitContainerFooter.Panel1.Controls.Add(this.AddNode);
            this.splitContainerFooter.Panel1.Controls.Add(this.NodePropertiesGroup);
            this.splitContainerFooter.Panel1.Controls.Add(this.nodeListing);
            this.splitContainerFooter.Panel1.Controls.Add(this.fileListing);
            // 
            // splitContainerFooter.Panel2
            // 
            this.splitContainerFooter.Panel2.Controls.Add(this.logOutput);
            this.splitContainerFooter.Size = new System.Drawing.Size(1004, 690);
            this.splitContainerFooter.SplitterDistance = 640;
            this.splitContainerFooter.TabIndex = 7;
            // 
            // previewGroup
            // 
            this.previewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewGroup.Controls.Add(this.pictureBox1);
            this.previewGroup.Location = new System.Drawing.Point(658, 15);
            this.previewGroup.MinimumSize = new System.Drawing.Size(333, 350);
            this.previewGroup.Name = "previewGroup";
            this.previewGroup.Size = new System.Drawing.Size(333, 350);
            this.previewGroup.TabIndex = 28;
            this.previewGroup.TabStop = false;
            this.previewGroup.Text = "Asset Preview";
            // 
            // extractGroup
            // 
            this.extractGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.extractGroup.Controls.Add(this.label5);
            this.extractGroup.Controls.Add(this.button3);
            this.extractGroup.Controls.Add(this.checkBox1);
            this.extractGroup.Controls.Add(this.button1);
            this.extractGroup.Location = new System.Drawing.Point(658, 371);
            this.extractGroup.Name = "extractGroup";
            this.extractGroup.Size = new System.Drawing.Size(333, 249);
            this.extractGroup.TabIndex = 27;
            this.extractGroup.TabStop = false;
            this.extractGroup.Text = "Extract Assets";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 22);
            this.button1.TabIndex = 10;
            this.button1.Text = "Extract This Node";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RemoveNode
            // 
            this.RemoveNode.Location = new System.Drawing.Point(281, 601);
            this.RemoveNode.Name = "RemoveNode";
            this.RemoveNode.Size = new System.Drawing.Size(91, 23);
            this.RemoveNode.TabIndex = 25;
            this.RemoveNode.Text = "Remove";
            this.RemoveNode.UseVisualStyleBackColor = true;
            // 
            // AddNode
            // 
            this.AddNode.Location = new System.Drawing.Point(193, 601);
            this.AddNode.Name = "AddNode";
            this.AddNode.Size = new System.Drawing.Size(82, 23);
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
            this.NodePropertiesGroup.Location = new System.Drawing.Point(394, 15);
            this.NodePropertiesGroup.Name = "NodePropertiesGroup";
            this.NodePropertiesGroup.Size = new System.Drawing.Size(240, 609);
            this.NodePropertiesGroup.TabIndex = 23;
            this.NodePropertiesGroup.TabStop = false;
            this.NodePropertiesGroup.Text = "Node Properties";
            // 
            // nodeNumber
            // 
            this.nodeNumber.Location = new System.Drawing.Point(9, 110);
            this.nodeNumber.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nodeNumber.Name = "nodeNumber";
            this.nodeNumber.Size = new System.Drawing.Size(184, 20);
            this.nodeNumber.TabIndex = 17;
            this.nodeNumber.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // nodeProp_SceneInput
            // 
            this.nodeProp_SceneInput.Location = new System.Drawing.Point(9, 32);
            this.nodeProp_SceneInput.Name = "nodeProp_SceneInput";
            this.nodeProp_SceneInput.Size = new System.Drawing.Size(184, 20);
            this.nodeProp_SceneInput.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zone";
            // 
            // nodeListing
            // 
            this.nodeListing.AllowDrop = true;
            this.nodeListing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodeListing.BackColor = System.Drawing.Color.Black;
            this.nodeListing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.nodeListing.Location = new System.Drawing.Point(190, 34);
            this.nodeListing.Margin = new System.Windows.Forms.Padding(0);
            this.nodeListing.MinimumSize = new System.Drawing.Size(100, 4);
            this.nodeListing.Name = "nodeListing";
            this.nodeListing.Size = new System.Drawing.Size(191, 564);
            this.nodeListing.TabIndex = 22;
            this.nodeListing.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.nodeListing_ItemDrag);
            this.nodeListing.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nodeListing_AfterSelect);
            this.nodeListing.DragDrop += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragDrop);
            this.nodeListing.DragEnter += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragEnter);
            this.nodeListing.DragOver += new System.Windows.Forms.DragEventHandler(this.nodeListing_DragOver);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(190, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 20);
            this.button2.TabIndex = 19;
            this.button2.Text = "Previous";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nextSelectionButton
            // 
            this.nextSelectionButton.Location = new System.Drawing.Point(281, 11);
            this.nextSelectionButton.Name = "nextSelectionButton";
            this.nextSelectionButton.Size = new System.Drawing.Size(100, 20);
            this.nextSelectionButton.TabIndex = 7;
            this.nextSelectionButton.Text = "Next";
            this.nextSelectionButton.UseVisualStyleBackColor = true;
            this.nextSelectionButton.Click += new System.EventHandler(this.nextSelectionButton_Click);
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
            this.logOutput.Size = new System.Drawing.Size(1002, 44);
            this.logOutput.TabIndex = 2;
            this.logOutput.Text = "";
            // 
            // MenuStrip
            // 
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
            // nodeProp_ZoneInput
            // 
            this.nodeProp_ZoneInput.Location = new System.Drawing.Point(9, 72);
            this.nodeProp_ZoneInput.Name = "nodeProp_ZoneInput";
            this.nodeProp_ZoneInput.Size = new System.Drawing.Size(184, 20);
            this.nodeProp_ZoneInput.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 253);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 17);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "Extract Cube Faces Separately";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(32, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 22);
            this.button3.TabIndex = 28;
            this.button3.Text = "Extract All Nodes";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Scene";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 146);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.MinimumSize = new System.Drawing.Size(100, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(231, 95);
            this.listBox1.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cube Files";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(7, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 320);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "OutputFolder";
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.BackColor = System.Drawing.Color.Black;
            this.listBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(3, 381);
            this.listBox2.Margin = new System.Windows.Forms.Padding(0);
            this.listBox2.MinimumSize = new System.Drawing.Size(100, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(231, 212);
            this.listBox2.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Other Images";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "DepthMap Cube Files";
            // 
            // listBox3
            // 
            this.listBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox3.BackColor = System.Drawing.Color.Black;
            this.listBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(3, 264);
            this.listBox3.Margin = new System.Windows.Forms.Padding(0);
            this.listBox3.MinimumSize = new System.Drawing.Size(100, 4);
            this.listBox3.Name = "listBox3";
            this.listBox3.ScrollAlwaysVisible = true;
            this.listBox3.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox3.Size = new System.Drawing.Size(231, 95);
            this.listBox3.TabIndex = 27;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1004, 715);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.splitContainerFooter);
            this.Name = "MainForm";
            this.Text = "MYSTER (Exile / Revelation) Asset Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainerFooter.Panel1.ResumeLayout(false);
            this.splitContainerFooter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFooter)).EndInit();
            this.splitContainerFooter.ResumeLayout(false);
            this.previewGroup.ResumeLayout(false);
            this.extractGroup.ResumeLayout(false);
            this.extractGroup.PerformLayout();
            this.NodePropertiesGroup.ResumeLayout(false);
            this.NodePropertiesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeNumber)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFolderDialog;
        private System.Windows.Forms.ListBox fileListing;
        private System.Windows.Forms.SplitContainer splitContainerFooter;
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
    }
}

