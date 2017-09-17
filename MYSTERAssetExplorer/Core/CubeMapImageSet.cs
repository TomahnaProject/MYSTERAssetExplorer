using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Core
{
    public class CubeMapImageSet
    {
        public string Back { get; set; }
        public string Bottom { get; set; }
        public string Front { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
        public string Top { get; set; }

        public static string[] GetAsFileList(CubeMapImageSet imageSet)
        {
            // alphabetical order (which is the order of the images that come out of dragon unpacker's hyper-ripper)
            string[] array = new string[6];
            array[0] = imageSet.Back;
            array[1] = imageSet.Bottom;
            array[2] = imageSet.Front;
            array[3] = imageSet.Left;
            array[4] = imageSet.Right;
            array[5] = imageSet.Top;
            return array;
        }

        public static CubeMapImageSet FillFromArray(string[] fileList)
        {
            if (fileList.Length < 1)
                throw new Exception("The file list must contain at least one image");

            var imageSet = new CubeMapImageSet();

            if(fileList.Length == 1)
            {
                imageSet.Back = fileList[0];
                imageSet.Bottom = fileList[0];
                imageSet.Front = fileList[0];
                imageSet.Left = fileList[0];
                imageSet.Right = fileList[0];
                imageSet.Top = fileList[0];
            }
            else if (fileList.Length == 2)
            {
                imageSet.Back = fileList[0];
                imageSet.Bottom = fileList[1];
                imageSet.Front = fileList[1];
                imageSet.Left = fileList[1];
                imageSet.Right = fileList[1];
                imageSet.Top = fileList[1];
            }
            else if (fileList.Length == 3)
            {
                imageSet.Back = fileList[0];
                imageSet.Bottom = fileList[1];
                imageSet.Front = fileList[2];
                imageSet.Left = fileList[2];
                imageSet.Right = fileList[2];
                imageSet.Top = fileList[2];
            }
            else if (fileList.Length == 4)
            {
                imageSet.Back = fileList[0];
                imageSet.Bottom = fileList[1];
                imageSet.Front = fileList[2];
                imageSet.Left = fileList[3];
                imageSet.Right = fileList[3];
                imageSet.Top = fileList[3];
            }
            else if (fileList.Length == 5)
            {
                imageSet.Back = fileList[0];
                imageSet.Bottom = fileList[1];
                imageSet.Front = fileList[2];
                imageSet.Left = fileList[3];
                imageSet.Right = fileList[4];
                imageSet.Top = fileList[4];
            }
            else if (fileList.Length > 5)
            {
                imageSet.Back = fileList[0];
                imageSet.Bottom = fileList[1];
                imageSet.Front = fileList[2];
                imageSet.Left = fileList[3];
                imageSet.Right = fileList[4];
                imageSet.Top = fileList[5];
            }
            return imageSet;
        }
    }
}
