using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERAssetExtractor.Core
{
    public enum MediaType
    {
        CubeMapFace,
        Sprite,
        Sequence,
    }

    public enum CubeSide
    {
        Back,
        Bottom,
        Left,
        Right,
        Top
    }

    public interface IMedia
    {
        MediaType Type { get; }
    }

    public class CubeMapFace : IMedia
    {
        public MediaType Type { get { return MediaType.CubeMapFace; } }
        public CubeSide Side { get; set; }
        public string FileName { get; set; }
    }

    public class Sprite : IMedia
    {
        public MediaType Type { get { return MediaType.Sprite; } }
        public string FileName { get; set; }
    }

    public class Sequence : IMedia
    {
        public MediaType Type { get { return MediaType.Sequence; } }
        string FileName { get; set; }
        // preferrably video broken into frames
        //List<string> FileNames { get; set; }
    }
}
