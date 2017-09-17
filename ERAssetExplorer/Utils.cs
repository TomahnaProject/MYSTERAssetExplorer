using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERAssetExplorer
{
    public static class Utils
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

        public static Bitmap LoadBitmapToMemory(string path)
        {
            //Open file in read only mode
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //Get a binary reader for the file stream
            using (BinaryReader reader = new BinaryReader(stream))
            {
                //copy the content of the file into a memory stream
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                //make a new Bitmap object the owner of the MemoryStream
                return new Bitmap(memoryStream);
            }
        }
    }
}
