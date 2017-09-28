using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYSTERAssetExplorer.Core
{
    [Serializable]
    public class CubeMapImageSet
    {
        [Serializable]
        public class CubeFace
        {
            [XmlAttribute]
            public string File { get; set; }
        }

        public CubeFace Back { get; set; }
        public CubeFace Bottom { get; set; }
        public CubeFace Front { get; set; }
        public CubeFace Left { get; set; }
        public CubeFace Right { get; set; }
        public CubeFace Top { get; set; }

        public CubeMapImageSet()
        {
            Back = new CubeFace();
            Bottom = new CubeFace();
            Front = new CubeFace();
            Left = new CubeFace();
            Right = new CubeFace();
            Top = new CubeFace();
        }

        public static string[] GetAsFileList(CubeMapImageSet imageSet)
        {
            // alphabetical order (which is the order of the images that come out of dragon unpacker's hyper-ripper)
            string[] array = new string[6];
            array[0] = imageSet.Back.File;
            array[1] = imageSet.Bottom.File;
            array[2] = imageSet.Front.File;
            array[3] = imageSet.Left.File;
            array[4] = imageSet.Right.File;
            array[5] = imageSet.Top.File;
            return array;
        }
    }
}
