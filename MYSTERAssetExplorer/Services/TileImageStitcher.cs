using MYSTERAssetExplorer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public class TileImageStitcher
    {
        class Tile
        {
            public IVirtualFile TileFile { get; set; }
            public int PositionX { get; set; }
            public int PositionY { get; set; }
            public Bitmap Bmp { get; set; }
        }

        VirtualFileExtractionService Extractor;
        public TileImageStitcher(VirtualFileExtractionService extractor)
        {
            Extractor = extractor;
        }

        public byte[] GetAssembledTiledImage(VirtualFileTiledImage image)
        {
            List<Tile> tiles = GetTiles(image);
            byte[] imageData = ConstructTiledImage(tiles);
            return imageData;
        }

        private List<Tile> GetTiles(VirtualFileTiledImage image)
        {
            List<Tile> tiles = new List<Tile>();
            foreach (var tileFile in image.Tiles)
            {
                var tile = new Tile();
                tile.TileFile = tileFile;
                tile.PositionX = int.Parse(tileFile.Name[tileFile.Name.Length - 8].ToString());
                tile.PositionY = int.Parse(tileFile.Name[tileFile.Name.Length - 5].ToString());
                var imageData = Extractor.GetDataForVirtualFile(tileFile);

                using (var ms = new MemoryStream(imageData))
                {
                    tile.Bmp = new Bitmap(ms);
                }

                tiles.Add(tile);
            }
            return tiles;
        }

        private byte[] ConstructTiledImage(List<Tile> tiles)
        {
            int tileCountX = tiles.Max(x => x.PositionX);
            int tileCountY = tiles.Max(x => x.PositionY);
            int tileCount = Math.Max(tileCountX, tileCountY);

            int tileSizeInPixels = tiles.Max(x => x.Bmp.Width);

            var width = tileCount * tileSizeInPixels;
            var height = tileCount * tileSizeInPixels;
            var bitmap = new Bitmap(width, height);

            for (int i = 0; i < tileCount; i++)
            {
                for (int j = 0; j < tileCount; j++)
                {
                    Overlay(j, i, bitmap, tiles.FirstOrDefault(x=>(x.PositionX-1) == i && (x.PositionY-1) == j));
                }
            }

            byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Bmp);
                data = memoryStream.ToArray();
            }
            return data;
        }

        private void Overlay(int xIndex, int yIndex, Bitmap bitmap, Tile tile)
        {
            if (tile == null)
                return;

            var tileStartX = tile.Bmp.Width * xIndex;
            var tileStartY = tile.Bmp.Height * yIndex;
            var XOffset = (tile.Bmp.Width * xIndex);
            var YOffset = (tile.Bmp.Height * yIndex);

            for (int i = 0; i < tile.Bmp.Width; i++)
            {
                for (int j = 0; j < tile.Bmp.Height; j++)
                {
                    var color = tile.Bmp.GetPixel(i, j);
                    bitmap.SetPixel(XOffset + i, YOffset + j, color);
                }
            }
        }
    }
}
