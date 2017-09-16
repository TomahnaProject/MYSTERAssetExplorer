using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExileAndRevelationAssetExtractor.App
{
    public partial class MainForm : Form
    {
        private ExileAndRevelationAssetExtractorApp App;

        public MainForm()
        {
            InitializeComponent();
            App = new ExileAndRevelationAssetExtractorApp();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "M3 M4 Data Files(*.m3a;*.m4b)|*.m3a;*.m4b|All files (*.*)|*.*";
            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                App.OpenFile(filePath);
            }
        }

        private void ExtractFilesButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "Extract Files Here";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var folderPath = Path.GetDirectoryName(saveFileDialog.FileName); ;
                App.ExtractFiles(folderPath);
            }
        }
    }
}
