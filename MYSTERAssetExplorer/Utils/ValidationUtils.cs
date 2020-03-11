using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.Utils
{
    public static class ValidationUtils
    {
        public static bool FileIsImage(string path)
        {
            var extension = Path.GetExtension(path);
            if (extension == ".jpeg" || extension == ".jpg")
                return true;
            return false;
        }

        public static bool CheckAllFilesExist(string[] files)
        {
            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    MessageBox.Show(file + " does not exist!");
                    return false;
                }
            }
            return true;
        }
    }
}
