using System;
using System.Xml.Serialization;

namespace MYSTER.Core
{
    [Serializable]
    public class CubeMapFace
    {
        [XmlAttribute]
        public string File { get; set; }
    }

    [Serializable]
    public class CubeMapImageSet
    {
        public CubeMapFace Back { get; set; }
        public CubeMapFace Bottom { get; set; }
        public CubeMapFace Front { get; set; }
        public CubeMapFace Left { get; set; }
        public CubeMapFace Right { get; set; }
        public CubeMapFace Top { get; set; }

        public CubeMapImageSet()
        {
            Back = new CubeMapFace();
            Bottom = new CubeMapFace();
            Front = new CubeMapFace();
            Left = new CubeMapFace();
            Right = new CubeMapFace();
            Top = new CubeMapFace();
        }

        public static string[] GetAsFileList(CubeMapImageSet imageSet)
        {
            // alphabetical order (which comes from the sequential order of the files ripped from the m3a files)
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
