using ArchiveSystem.VirtualFileSystem;
using M4ArchiveLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace MYSTER.Services
{
    public class TileImageStitcher
    {
        class Tile
        {
            public IVirtualFileEntry TileFile { get; set; }
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
                tile.PositionX = int.Parse(tileFile.FileName[tileFile.FileName.Length - 8].ToString());
                tile.PositionY = int.Parse(tileFile.FileName[tileFile.FileName.Length - 5].ToString());
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

            int horizontalCount = 0;
            int verticalCount = 0;
            for (verticalCount = 0; verticalCount < tileCount; verticalCount++)
            {
                for (horizontalCount = 0; horizontalCount < tileCount; horizontalCount++)
                {
                    Overlay(horizontalCount, verticalCount,
                        bitmap, tiles.FirstOrDefault(x =>
                        (x.PositionX - 1) == verticalCount &&
                        (x.PositionY - 1) == horizontalCount));
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

        private Point Coordinate = new Point();
        private void Overlay(int xIndex, int yIndex, Bitmap bitmap, Tile tile)
        {
            if (tile == null)
                return;

            Coordinate.X = tile.Bmp.Width * xIndex;
            Coordinate.Y = tile.Bmp.Height * yIndex;

            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(tile.Bmp, Coordinate.X, Coordinate.Y, tile.Bmp.Width, tile.Bmp.Height);
        }
    }
}
