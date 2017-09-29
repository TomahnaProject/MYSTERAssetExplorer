using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.Services
{
    public interface IUIContext
    {
        Action<Color, string> WriteToConsole { get; set; }
        Action<List<IVirtualFile>> ListFiles { get; set; }
        Action<TreeNode[]> PopulateNodes { get; set; }
        Action<List<IVirtualFolder>> PopulateFolders { get; set; }
    }
}
