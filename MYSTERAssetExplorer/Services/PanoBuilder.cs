using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer
{
    public class PanoBuilder
    {
        public void BuildPanorama(string outputDirectory, string name, CubeMapImageSet imageSet)
        {
            var image = StichCubeMap(imageSet);
            var finalSavePath = Path.Combine(outputDirectory, name + ".jpg");

            image.Save(finalSavePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private Bitmap StichCubeMap(CubeMapImageSet imageSet)
        {
            // grab the image size from first image loaded into the image set
            var first = Utils.LoadBitmapToMemory(imageSet.Back.File);
            var size = first.Size;
            if (size.Height != size.Width)
                throw new Exception("Images must have an aspect ratio of 1:1 to build a panorama");

            // this is the order the pano's are built in left to right
            List<Bitmap> images = new List<Bitmap>();
            images.Add(Utils.LoadBitmapToMemory(imageSet.Left.File));
            images.Add(Utils.LoadBitmapToMemory(imageSet.Front.File));
            images.Add(Utils.LoadBitmapToMemory(imageSet.Right.File));
            images.Add(Utils.LoadBitmapToMemory(imageSet.Back.File));

            // need to flip the bottom/top images so pano is in correct format
            Bitmap bottom = Utils.LoadBitmapToMemory(imageSet.Bottom.File);
            bottom.RotateFlip(RotateFlipType.Rotate90FlipNone);
            images.Add(bottom);
            Bitmap top = Utils.LoadBitmapToMemory(imageSet.Top.File);
            top.RotateFlip(RotateFlipType.Rotate270FlipNone);
            images.Add(top);

            return MergeImages(images);
        }

        private Bitmap MergeImages(IEnumerable<Bitmap> images)
        {
            var enumerable = images as IList<Bitmap> ?? images.ToList();

            var width = 0;
            var height = 0;

            foreach (var image in enumerable)
            {
                width += image.Width;
                height = image.Height > height
                    ? image.Height
                    : height;
            }

            var newBitmap = new Bitmap(width, height);
            var originalImage = images.FirstOrDefault();
            newBitmap.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);
            using (var g = Graphics.FromImage(newBitmap))
            {
                var localWidth = 0;
                foreach (var image in enumerable)
                {
                    g.DrawImage(image, localWidth, 0);
                    localWidth += image.Width;
                }
            }
            return newBitmap;
        }
    }
}
