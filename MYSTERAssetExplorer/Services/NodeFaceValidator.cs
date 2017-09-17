using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public static class NodeFaceValidator
    {
        //TODO should be parametized
        public const int NODE_FACE_SIZE = 640;

        public static bool IsNodeImage(string path, int faceSize)
        {
            //Open file in read only mode
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //Get a binary reader for the file stream
            using (BinaryReader reader = new BinaryReader(stream))
            {
                //copy the content of the file into a memory stream
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                //make a new Bitmap object the owner of the MemoryStream
                var bitmap = new Bitmap(memoryStream);
                var size = bitmap.Size;

                if (size.Height == NODE_FACE_SIZE && size.Width == NODE_FACE_SIZE)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
