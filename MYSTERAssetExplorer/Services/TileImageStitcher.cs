using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public class TileImageStitcher
    {
        VirtualFileExtractionService Extractor;
        public TileImageStitcher(VirtualFileExtractionService extractor)
        {
            Extractor = extractor;
        }

        public byte[] StitchTiledImage(VirtualFileTiledImage image)
        {
            var first = image.Tiles.FirstOrDefault();
            return Extractor.GetImageDataFromVirtualFile(first);
        }

        //private string[][] PopulateTileNames(string name)
        //{
        //    string[][] tileFileNames = new string[6][];
        //    for (int i = 0; i < 6; i++)
        //    {
        //        tileFileNames[i] = new string[6];
        //        for (int j = 0; j < 6; j++)
        //        {
        //            tileFileNames[i][j] = name + "_0" + (i + 1) + "_0" + (j + 1) + ".jpg";
        //        }
        //    }
        //    return tileFileNames;
        //}

        //private Bitmap StichTiles(string[][] tileFileNames)
        //{
        //    var bitmap = new Bitmap(768, 768);
        //    for (int i = 0; i < 6; i++)
        //    {
        //        for (int j = 0; j < 6; j++)
        //        {
        //            Overlay(j, i, bitmap, tileFileNames[i][j]);
        //        }
        //    }
        //    return bitmap;
        //}

        //private void Overlay(int xIndex, int yIndex, Bitmap bitmap, string fileName)
        //{
        //    var tileFilePath = Path.Combine(Directory, fileName);
        //    if (!File.Exists(tileFilePath) || !fileName.Contains(".jpg"))
        //        return;

        //    Bitmap imageTile = new Bitmap(tileFilePath);

        //    var tileStartX = imageTile.Width * xIndex;
        //    var tileStartY = imageTile.Height * yIndex;
        //    var XOffset = (imageTile.Width * xIndex);
        //    var YOffset = (imageTile.Height * yIndex);

        //    for (int i = 0; i < imageTile.Width; i++)
        //    {
        //        for (int j = 0; j < imageTile.Height; j++)
        //        {
        //            var color = imageTile.GetPixel(i, j);
        //            bitmap.SetPixel(XOffset + i, YOffset + j, color);
        //        }
        //    }
        //}
    }
}
