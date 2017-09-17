using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERAssetExtractor.Services
{
    public interface IUIContext
    {
        Action<Color, string> WriteToConsole { get; set; }
        Action<List<string>> ListFiles { get; set; }
        Action<TreeNode[]> PopulateNodes { get; set; }
    }
}
