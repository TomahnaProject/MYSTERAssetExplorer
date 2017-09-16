using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.FileName = "";
                var filePath = openFileDialog.FileName;
                App.OpenFile(filePath);
            }
        }
    }
}
