using ERAssetExtractor.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERAssetExtractor.App
{
    public class UIContext : IUIContext
    {
        public Action<Color, string> WriteToConsole { get; set; }
        public Action<List<string>> ListFiles { get; set; }
        public Action<TreeNode[]> PopulateNodes { get; set; }
    }
}
