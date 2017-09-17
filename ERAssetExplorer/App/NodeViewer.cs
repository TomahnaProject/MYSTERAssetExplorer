using ERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERAssetExplorer.App
{
    public partial class NodeViewer : Form
    {
        Action LoadNode;
        public NodeViewer(Action loadNode)
        {
            InitializeComponent();
            LoadNode = loadNode;
        }

        private void NodeViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }

        public void SetNode(CubeMapImageSet imageSet)
        {            
            if (!Utils.CheckAllFilesExist(CubeMapImageSet.GetAsFileList(imageSet)))
                return;

            backBox.Image = Utils.LoadBitmapToMemory(imageSet.Back);
            bottomBox.Image = Utils.LoadBitmapToMemory(imageSet.Bottom);
            frontBox.Image = Utils.LoadBitmapToMemory(imageSet.Front);
            leftBox.Image = Utils.LoadBitmapToMemory(imageSet.Left);
            rightBox.Image = Utils.LoadBitmapToMemory( imageSet.Right);
            topBox.Image = Utils.LoadBitmapToMemory(imageSet.Top);
        }

        public void ActivateLoadNode()
        {
            LoadNode();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadNode();
        }
    }
}
