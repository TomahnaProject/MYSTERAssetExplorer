using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace MYSTER.Services.Utils
{
    public class BitmapUtils
    {
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

        public static Bitmap LoadBitmapFromMemory(byte[] imageData)
        {
            if (imageData == null || imageData.Length < 1)
                return null;

            // originally wrapped this in a using block, but is apparently unnecessary
            //https://stackoverflow.com/questions/336387/image-save-throws-a-gdi-exception-because-the-memory-stream-is-closed
            var ms = new MemoryStream(imageData);
            return new Bitmap(ms);
        }
    }
}
