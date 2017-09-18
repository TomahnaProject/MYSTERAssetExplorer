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
            this.topBox = new System.Windows.Forms.PictureBox();
            this.backBox = new System.Windows.Forms.PictureBox();
            this.rightBox = new System.Windows.Forms.PictureBox();
            this.bottomBox = new System.Windows.Forms.PictureBox();
            this.leftBox = new System.Windows.Forms.PictureBox();
            this.frontBox = new System.Windows.Forms.PictureBox();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.topBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontBox)).BeginInit();
            this.SuspendLayout();
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
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(51, 42);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 17;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // NodeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1325, 909);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.topBox);
            this.Controls.Add(this.backBox);
            this.Controls.Add(this.rightBox);
            this.Controls.Add(this.bottomBox);
            this.Controls.Add(this.leftBox);
            this.Controls.Add(this.frontBox);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "NodeViewer";
            this.Text = "Node Previewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NodeViewer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.topBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox topBox;
        private System.Windows.Forms.PictureBox backBox;
        private System.Windows.Forms.PictureBox rightBox;
        private System.Windows.Forms.PictureBox bottomBox;
        private System.Windows.Forms.PictureBox leftBox;
        private System.Windows.Forms.PictureBox frontBox;
        private System.Windows.Forms.Button loadButton;
    }
}