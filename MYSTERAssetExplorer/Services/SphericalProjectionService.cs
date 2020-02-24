using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.Services
{
    public class SphericalProjectionService
    {
        public Bitmap ConstructProjection(CubemapImages images)
        {
            return ConvertToEquirectangular(images);
        }

        //https://stackoverflow.com/questions/34250742/converting-a-cubemap-into-equirectangular-panorama
        //https://github.com/adamb70/Python-Spherical-Projection/blob/master/cube2equi.py
        //https://stackoverflow.com/questions/11504584/cubic-to-equirectangular-projection-algorithm
        private Bitmap ConvertToEquirectangular(CubemapImages cubeMap)
        {
            CubemapHelper.FillAnyNullWithBlanks(cubeMap);
            CubemapHelper.UpsizeAnyPartials(cubeMap);

            DirectBitmap[] faces = ResizeAndConverCubeToDirectBitmap(cubeMap);

            int cubeFaceWidth = faces[0].Width;
            int cubeFaceHeight = cubeFaceWidth;

            // this block is to calculate a size that has a comparable pixel density to that of the combined input images
            int factor = 256;
            int nearestMultiple = 0;
            {
                int cubePixelCount = cubeFaceHeight * cubeFaceWidth;
                int totalCubePixelCount = cubePixelCount * 6;

                int sizeToGetComparablePixelDensity = (int)Math.Sqrt(totalCubePixelCount / 2);
                nearestMultiple =
                        (int)Math.Round(
                             (sizeToGetComparablePixelDensity / (double)factor),
                             MidpointRounding.AwayFromZero
                         ) * factor;
            }
            int outputHeight = nearestMultiple + factor; // round it up
            int outputWidth = outputHeight * 2;

            // make the projection a multiple of the width of the combined images
            int scale_factor = 4;
            int projectionWidth = (cubeFaceWidth * 4)* scale_factor;
            int projectionHeight = projectionWidth / 2;

            DirectBitmap equiTexture = new DirectBitmap(projectionWidth, projectionHeight);

            //Normalised UV texture coordinates, from 0 to 1, starting at lower left corner
            double u_coordinate;
            double v_coordinate;
            //Polar coordinates
            double latitude;
            double longitude;
            //Unit vector
            double x, y, z;
            double xAxis, yAxis, zAxis;
            double largestComponent;
            double[] vector = new double[3];

            Color color;
            Point pixelCoord;

            double normX;
            double normY;

            //int modulousFactorX = outputWidth / 16;
            //int modulousFactorY = outputHeight / 8;
            //bool horizontalMarker = false;
            //bool verticalMarker = false;

            for (int heightIndex = 0; heightIndex < equiTexture.Height; heightIndex++)
            {
                //verticalMarker = heightIndex % modulousFactorX == 0;

                v_coordinate = 1 - ((double)heightIndex / equiTexture.Height);
                latitude = v_coordinate * Math.PI;

                for (int widthIndex = 0; widthIndex < equiTexture.Width; widthIndex++)
                {
                    //horizontalMarker = widthIndex % modulousFactorY == 0;

                    u_coordinate = ((double)widthIndex / equiTexture.Width);
                    longitude = u_coordinate * 2 * Math.PI;

                    //assuming Y+ is up, X+ is right, Z+ is front

                    //Calculate unit vector
                    x = Math.Sin(longitude) * Math.Sin(latitude) * -1;
                    y = Math.Cos(latitude);
                    z = Math.Cos(longitude) * Math.Sin(latitude) * -1;

                    vector[0] = Math.Abs(x);
                    vector[1] = Math.Abs(y);
                    vector[2] = Math.Abs(z);
                    largestComponent = vector.Max();
                    // PROBLEM : there are cases where the vertical boundary between cube faces
                    // results in both the x and z components to be equivalent
                    // so both axis return a 1, which 

                    //Vector Parallel to the unit vector that lies on one of the cube faces
                    xAxis = x / largestComponent;
                    yAxis = y / largestComponent;
                    zAxis = z / largestComponent;

                    //bool debug = true;
                    //if (debug && verticalMarker && horizontalMarker)
                    //{
                    //    MessageBox.Show(
                    //        "h:" + heightIndex + " w:" + widthIndex +
                    //        "\r\nlat:" + latitude + " long:" + longitude +
                    //        "\r\nx:" + x + " y:" + y + " z:" + z
                    //        );
                    //    color = Color.Purple;
                    //}

                    if (xAxis == 1)
                    {
                        //Right
                        normX = (((zAxis + 1f) / 2f) - 1f);
                        normY = (((yAxis + 1f) / 2f));
                        pixelCoord = GetPixelCoordinates(normX, normY, faces[4].Width, faces[4].Height);
                        color = faces[4].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (xAxis == -1)
                    {
                        //Left
                        normX = ((zAxis + 1) / 2);
                        normY = ((yAxis + 1) / 2);
                        pixelCoord = GetPixelCoordinates(normX, normY, faces[3].Width, faces[3].Height);
                        color = faces[3].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (yAxis == -1)
                    {
                        //Up
                        normX = ((xAxis + 1f) / 2f);
                        normY = ((zAxis + 1f) / 2f);
                        pixelCoord = GetPixelCoordinates(normX, normY, faces[5].Width, faces[5].Height);
                        color = faces[5].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (yAxis == 1)
                    {
                        //Down
                        normX = ((xAxis + 1f) / 2f);
                        normY = (((zAxis + 1f) / 2f) - 1f);
                        pixelCoord = GetPixelCoordinates(normX, normY, faces[1].Width, faces[1].Height);
                        color = faces[1].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (zAxis == 1)
                    {
                        //Front
                        normX = ((xAxis + 1f) / 2f);
                        normY = ((yAxis + 1f) / 2f);
                        pixelCoord = GetPixelCoordinates(normX, normY, faces[2].Width, faces[2].Height);
                        color = faces[2].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (zAxis == -1)
                    {
                        //Back
                        normX = (((xAxis + 1f) / 2f) - 1f);
                        normY = ((yAxis + 1f) / 2f);
                        pixelCoord = GetPixelCoordinates(normX, normY, faces[0].Width, faces[0].Height);
                        color = faces[0].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else
                    {
                        throw new Exception("Unknown face, something went wrong");
                    }

                    equiTexture.SetPixel(widthIndex, heightIndex, color);
                }
            }
            var downscaled  = ResizeImage(equiTexture.Bitmap, equiTexture.Width / scale_factor, equiTexture.Height / scale_factor);
            return downscaled;
        }

        Point coordinate = new Point();
        private Point GetPixelCoordinates(double normX, double normY, int cubeFaceWidth, int cubeFaceHeight)
        {
            coordinate.X = (int)(normX * cubeFaceWidth);
            coordinate.Y = (int)(normY * cubeFaceHeight);
            coordinate.X = Math.Abs(coordinate.X);
            coordinate.Y = Math.Abs(coordinate.Y);
            coordinate.X = coordinate.X < cubeFaceWidth ? coordinate.X : cubeFaceWidth - 1;
            coordinate.Y = coordinate.Y < cubeFaceHeight ? coordinate.Y : cubeFaceHeight - 1;
            return coordinate;
        }

        private DirectBitmap[] ResizeAndConverCubeToDirectBitmap(CubemapImages images)
        {
            Bitmap[] processedFaces = new Bitmap[6];
            bool resize = false;
            if (resize)
            {
                processedFaces[0] = ResizeImage(images.Back, images.Back.Width * 2, images.Back.Height * 2);
                processedFaces[1] = ResizeImage(images.Bottom, images.Bottom.Width * 2, images.Bottom.Height * 2);
                processedFaces[2] = ResizeImage(images.Front, images.Front.Width * 2, images.Front.Height * 2);
                processedFaces[3] = ResizeImage(images.Left, images.Left.Width * 2, images.Left.Height * 2);
                processedFaces[4] = ResizeImage(images.Right, images.Right.Width * 2, images.Right.Height * 2);
                processedFaces[5] = ResizeImage(images.Top, images.Top.Width * 2, images.Top.Height * 2);
            }
            else
            {
                processedFaces[0] = images.Back;
                processedFaces[1] = images.Bottom;
                processedFaces[2] = images.Front;
                processedFaces[3] = images.Left;
                processedFaces[4] = images.Right;
                processedFaces[5] = images.Top;
            }
            DirectBitmap[] faces = new DirectBitmap[6];
            faces[0] = CopyImageToDirectBitmap(processedFaces[0]);
            faces[1] = CopyImageToDirectBitmap(processedFaces[1]);
            faces[2] = CopyImageToDirectBitmap(processedFaces[2]);
            faces[3] = CopyImageToDirectBitmap(processedFaces[3]);
            faces[4] = CopyImageToDirectBitmap(processedFaces[4]);
            faces[5] = CopyImageToDirectBitmap(processedFaces[5]);
            return faces;
        }
        private DirectBitmap CopyImageToDirectBitmap(Bitmap image)
        {
            DirectBitmap result = new DirectBitmap(image.Width, image.Height);
            for (int row = 0; row < image.Height; row++)
            {
                for (int col = 0; col < image.Width; col++)
                {
                    result.SetPixel(col, row, image.GetPixel(col, row));
                }
            }
            return result;
        }

        //http://www.nathanaeljones.com/blog/2009/20-image-resizing-pitfalls
        //https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }

    // using this for performance, since normal bitmap get/set pixel made it painfully slow
    //https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
