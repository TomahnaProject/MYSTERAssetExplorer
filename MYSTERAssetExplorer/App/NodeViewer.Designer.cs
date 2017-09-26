﻿namespace MYSTERAssetExplorer.App
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nodeExplorer = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NodePropertiesGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nodeProp_ZoneInput = new System.Windows.Forms.TextBox();
            this.nodeNumber = new System.Windows.Forms.NumericUpDown();
            this.nodeProp_SceneInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.topBox = new System.Windows.Forms.PictureBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.leftBox = new System.Windows.Forms.PictureBox();
            this.frontBox = new System.Windows.Forms.PictureBox();
            this.rightBox = new System.Windows.Forms.PictureBox();
            this.backBox = new System.Windows.Forms.PictureBox();
            this.bottomBox = new System.Windows.Forms.PictureBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.loadRegistry = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveRegistry = new System.Windows.Forms.ToolStripLabel();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.NodePropertiesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBox)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.topBox);
            this.splitContainer1.Panel2.Controls.Add(this.listBox2);
            this.splitContainer1.Panel2.Controls.Add(this.leftBox);
            this.splitContainer1.Panel2.Controls.Add(this.frontBox);
            this.splitContainer1.Panel2.Controls.Add(this.rightBox);
            this.splitContainer1.Panel2.Controls.Add(this.backBox);
            this.splitContainer1.Panel2.Controls.Add(this.bottomBox);
            this.splitContainer1.Size = new System.Drawing.Size(1549, 803);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 18;
            // 
            // nodeExplorer
            // 
            this.nodeExplorer.AllowDrop = true;
            this.nodeExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nodeExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeExplorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.nodeExplorer.Location = new System.Drawing.Point(0, 0);
            this.nodeExplorer.Margin = new System.Windows.Forms.Padding(0);
            this.nodeExplorer.MinimumSize = new System.Drawing.Size(100, 215);
            this.nodeExplorer.Name = "nodeExplorer";
            this.nodeExplorer.Size = new System.Drawing.Size(253, 803);
            this.nodeExplorer.TabIndex = 23;
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
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 325);
            this.panel1.TabIndex = 18;
            // 
            // NodePropertiesGroup
            // 
            this.NodePropertiesGroup.Controls.Add(this.SaveButton);
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
            this.NodePropertiesGroup.Size = new System.Drawing.Size(325, 325);
            this.NodePropertiesGroup.TabIndex = 24;
            this.NodePropertiesGroup.TabStop = false;
            this.NodePropertiesGroup.Text = "Node Properties";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Scene";
            // 
            // nodeProp_ZoneInput
            // 
            this.nodeProp_ZoneInput.Location = new System.Drawing.Point(9, 78);
            this.nodeProp_ZoneInput.Name = "nodeProp_ZoneInput";
            this.nodeProp_ZoneInput.Size = new System.Drawing.Size(184, 20);
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
            this.nodeNumber.Size = new System.Drawing.Size(184, 20);
            this.nodeNumber.TabIndex = 17;
            // 
            // nodeProp_SceneInput
            // 
            this.nodeProp_SceneInput.Location = new System.Drawing.Point(9, 34);
            this.nodeProp_SceneInput.Name = "nodeProp_SceneInput";
            this.nodeProp_SceneInput.Size = new System.Drawing.Size(184, 20);
            this.nodeProp_SceneInput.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zone";
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
            // topBox
            // 
            this.topBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.topBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topBox.Location = new System.Drawing.Point(331, 11);
            this.topBox.Margin = new System.Windows.Forms.Padding(0);
            this.topBox.Name = "topBox";
            this.topBox.Size = new System.Drawing.Size(320, 320);
            this.topBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.topBox.TabIndex = 16;
            this.topBox.TabStop = false;
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
            // leftBox
            // 
            this.leftBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.leftBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftBox.Location = new System.Drawing.Point(11, 331);
            this.leftBox.Margin = new System.Windows.Forms.Padding(0);
            this.leftBox.Name = "leftBox";
            this.leftBox.Size = new System.Drawing.Size(320, 320);
            this.leftBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftBox.TabIndex = 12;
            this.leftBox.TabStop = false;
            // 
            // frontBox
            // 
            this.frontBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.frontBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frontBox.Location = new System.Drawing.Point(331, 331);
            this.frontBox.Margin = new System.Windows.Forms.Padding(0);
            this.frontBox.Name = "frontBox";
            this.frontBox.Size = new System.Drawing.Size(320, 320);
            this.frontBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.frontBox.TabIndex = 11;
            this.frontBox.TabStop = false;
            // 
            // rightBox
            // 
            this.rightBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightBox.Location = new System.Drawing.Point(651, 331);
            this.rightBox.Margin = new System.Windows.Forms.Padding(0);
            this.rightBox.Name = "rightBox";
            this.rightBox.Size = new System.Drawing.Size(320, 320);
            this.rightBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightBox.TabIndex = 14;
            this.rightBox.TabStop = false;
            // 
            // backBox
            // 
            this.backBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.backBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backBox.Location = new System.Drawing.Point(971, 331);
            this.backBox.Margin = new System.Windows.Forms.Padding(0);
            this.backBox.Name = "backBox";
            this.backBox.Size = new System.Drawing.Size(320, 320);
            this.backBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backBox.TabIndex = 15;
            this.backBox.TabStop = false;
            // 
            // bottomBox
            // 
            this.bottomBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.bottomBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottomBox.Location = new System.Drawing.Point(331, 651);
            this.bottomBox.Margin = new System.Windows.Forms.Padding(0);
            this.bottomBox.Name = "bottomBox";
            this.bottomBox.Size = new System.Drawing.Size(320, 320);
            this.bottomBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bottomBox.TabIndex = 13;
            this.bottomBox.TabStop = false;
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Gray;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadRegistry,
            this.toolStripSeparator1,
            this.saveRegistry});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1549, 25);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // loadRegistry
            // 
            this.loadRegistry.Name = "loadRegistry";
            this.loadRegistry.Size = new System.Drawing.Size(78, 22);
            this.loadRegistry.Text = "Load Registry";
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
            // 
            // NodeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1549, 827);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MainPanel);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "NodeViewer";
            this.Text = "Node Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NodeViewer_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.NodePropertiesGroup.ResumeLayout(false);
            this.NodePropertiesGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBox)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox topBox;
        private System.Windows.Forms.PictureBox backBox;
        private System.Windows.Forms.PictureBox rightBox;
        private System.Windows.Forms.PictureBox bottomBox;
        private System.Windows.Forms.PictureBox leftBox;
        private System.Windows.Forms.PictureBox frontBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView nodeExplorer;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox NodePropertiesGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nodeProp_ZoneInput;
        private System.Windows.Forms.NumericUpDown nodeNumber;
        private System.Windows.Forms.TextBox nodeProp_SceneInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel loadRegistry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel saveRegistry;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button SaveButton;
    }
}