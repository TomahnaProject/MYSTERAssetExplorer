using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MYSTER.Services
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
    public static class CubemapHelper
    {
        public static void FillAnyNullWithBlanks(CubemapImages cubemap)
        {
            Bitmap empty = new Bitmap(768,768); // HACK
            Graphics g = Graphics.FromImage(empty);
            g.Clear(Color.Black);
            if (cubemap.Back == null)
                cubemap.Back = empty;
            if (cubemap.Bottom == null)
                cubemap.Bottom = empty;
            if (cubemap.Front == null)
                cubemap.Front = empty;
            if (cubemap.Left == null)
                cubemap.Left = empty;
            if (cubemap.Right == null)
                cubemap.Right = empty;
            if (cubemap.Top == null)
                cubemap.Top = empty;
        }

        public static void UpsizeAnyPartials(CubemapImages cubemap)
        {
            if (CheckPartial(cubemap.Back))
                cubemap.Back = Upsize(cubemap.Back);
            if (CheckPartial(cubemap.Bottom))
                cubemap.Bottom = Upsize(cubemap.Bottom);
            if (CheckPartial(cubemap.Front))
                cubemap.Front = Upsize(cubemap.Front);
            if (CheckPartial(cubemap.Left))
                cubemap.Left = Upsize(cubemap.Left);
            if (CheckPartial(cubemap.Right))
                cubemap.Right = Upsize(cubemap.Right);
            if (CheckPartial(cubemap.Top))
                cubemap.Top = Upsize(cubemap.Top);
        }

        private static Bitmap Upsize(Bitmap image)
        {

            int cubeSize = 640;
            if (image.Width == 768 || image.Height == 768)
                cubeSize = 768;
            if (image.Width * 2 == 768 || image.Height * 2 == 768)
                cubeSize = 768;

            Bitmap upsized = new Bitmap(cubeSize, cubeSize);
            Graphics g = Graphics.FromImage(upsized);
            g.Clear(Color.Black);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            return upsized;
        }

        private static bool CheckPartial(Bitmap image)
        {
            if (image.Width == (768 / 2) || image.Width == (640 / 2))
                return true;
            if (image.Height == (768 / 2) || image.Height == (640 / 2))
                return true;
            return false;
        }
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

            if(first == null)
                return null;

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
                var horizontalOffset = 0;
                foreach (var image in enumerable)
                {
                    // Super important to specify the width and height
                    // otherwise DrawImage will randomly scale some cubefaces
                    // apparently some kind of DPI thing
                    // https://stackoverflow.com/questions/41188689/drawimage-scales-original-image
                    g.DrawImage(image, horizontalOffset, 0, image.Width, image.Height);
                    horizontalOffset += image.Width;
                }
            }
            return newBitmap;
        }
    }
}
