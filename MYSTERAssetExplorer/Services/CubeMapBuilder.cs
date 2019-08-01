using MYSTERAssetExplorer.App;
using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static MYSTERAssetExplorer.Core.CubeMapImageSet;

namespace MYSTERAssetExplorer
{
    public class CubemapImages
    {
        public Bitmap Back;
        public Bitmap Bottom;
        public Bitmap Front;
        public Bitmap Left;
        public Bitmap Right;
        public Bitmap Top;
    }

    public class CubeMapBuilder
    {
        public Bitmap ConstructCubemap(CubemapImages images)
        {
            return StichCubeMap(images);
        }

        private Bitmap GetOneValidImage(CubemapImages images)
        {
            if (images.Back != null)
                return images.Back;
            else if (images.Bottom != null)
                return images.Bottom;
            else if (images.Front != null)
                return images.Front;
            else if (images.Left != null)
                return images.Left;
            else if (images.Right != null)
                return images.Right;
            else if (images.Top != null)
                return images.Top;
            return null;
        }

        private Bitmap StichCubeMap(CubemapImages images)
        {
            // grab the image size from first image found in the image set
            var first = GetOneValidImage(images);
            var size = first.Size;
            if (size.Height != size.Width)
                throw new Exception("Images must have an aspect ratio of 1:1 to build a cubemap");

            // this is the order the cubemaps's are built in left to right
            List<Bitmap> imagesList = new List<Bitmap>();
            imagesList.Add(CheckNull(images.Left, size.Height));
            imagesList.Add(CheckNull(images.Front, size.Height));
            imagesList.Add(CheckNull(images.Right, size.Height));
            imagesList.Add(CheckNull(images.Back, size.Height));

            // need to flip the bottom/top images so cubemap is in correct format
            Bitmap bottom = CheckNull(images.Bottom, size.Height);
            bottom.RotateFlip(RotateFlipType.Rotate90FlipNone);
            imagesList.Add(bottom);
            Bitmap top = CheckNull(images.Top, size.Height);
            top.RotateFlip(RotateFlipType.Rotate270FlipNone);
            imagesList.Add(top);

            return MergeImages(imagesList);
        }

        private Bitmap CheckNull(Bitmap image, int size)
        {
            if (image != null)
                return image;
            else
            {
                return new Bitmap(size, size);
            }
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
