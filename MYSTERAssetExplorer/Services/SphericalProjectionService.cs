using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.Services
{
    public class SphericalProjectionService
    {
        private double yAxis;

        public Bitmap ConstructProjection(CubemapImages images)
        {
            return ConvertToEquirectangular(images);
        }

        //https://stackoverflow.com/questions/34250742/converting-a-cubemap-into-equirectangular-panorama
        //https://github.com/adamb70/Python-Spherical-Projection/blob/master/cube2equi.py
        //https://stackoverflow.com/questions/11504584/cubic-to-equirectangular-projection-algorithm
        public Bitmap ConvertToEquirectangular(CubemapImages cubeMap)
        {
            DirectBitmap[] faces = ConverCubeToDirectBitmap(cubeMap);

            int cubeFaceWidth = cubeMap.Bottom.Width;
            int cubeFaceHeight = cubeFaceWidth;

            int cubePixelCount = cubeFaceHeight * cubeFaceWidth;
            int totalCubePixelCount = cubePixelCount * 6;

            int sizeToGetComparablePixelDensity = (int) Math.Sqrt(totalCubePixelCount / 2);
            int factor = 256;
            int nearestMultiple =
                    (int)Math.Round(
                         (sizeToGetComparablePixelDensity / (double)factor),
                         MidpointRounding.AwayFromZero
                     ) * factor;

            int outputHeight = nearestMultiple + factor; // round it up
            outputHeight = 3200;  // double the size of output image
            int outputWidth = outputHeight * 2;            

            DirectBitmap equiTexture = new DirectBitmap(outputWidth, outputHeight);

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
                        pixelCoord = GetPixelCoordinates(normX, normY, cubeFaceWidth, cubeFaceHeight);
                        color = faces[4].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (xAxis == -1)
                    {
                        //Left
                        normX = ((zAxis + 1) / 2);
                        normY = ((yAxis + 1) / 2);
                        pixelCoord = GetPixelCoordinates(normX, normY, cubeFaceWidth, cubeFaceHeight);
                        color = faces[3].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (yAxis == -1)
                    {
                        //Up
                        normX = ((xAxis + 1f) / 2f);
                        normY = ((zAxis + 1f) / 2f);
                        pixelCoord = GetPixelCoordinates(normX, normY, cubeFaceWidth, cubeFaceHeight);
                        color = faces[5].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (yAxis == 1)
                    {
                        //Down
                        normX = ((xAxis + 1f) / 2f);
                        normY = (((zAxis + 1f) / 2f) - 1f);
                        pixelCoord = GetPixelCoordinates(normX, normY, cubeFaceWidth, cubeFaceHeight);
                        color = faces[1].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (zAxis == 1)
                    {
                        //Front
                        normX = ((xAxis + 1f) / 2f);
                        normY = ((yAxis + 1f) / 2f);
                        pixelCoord = GetPixelCoordinates(normX, normY, cubeFaceWidth, cubeFaceHeight);
                        color = faces[2].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else if (zAxis == -1)
                    {
                        //Back
                        normX = (((xAxis + 1f) / 2f) - 1f);
                        normY = ((yAxis + 1f) / 2f);
                        pixelCoord = GetPixelCoordinates(normX, normY, cubeFaceWidth, cubeFaceHeight);
                        color = faces[0].GetPixel(pixelCoord.X, pixelCoord.Y);
                    }
                    else
                    {
                        throw new Exception("Unknown face, something went wrong");
                    }

                    equiTexture.SetPixel(widthIndex, heightIndex, color);
                }
            }
            return equiTexture.Bitmap;
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

        private DirectBitmap[] ConverCubeToDirectBitmap(CubemapImages images)
        {
            DirectBitmap[] faces = new DirectBitmap[6];
            faces[0] = CopyImageToDirectBitmap(images.Back);
            faces[1] = CopyImageToDirectBitmap(images.Bottom);
            faces[2] = CopyImageToDirectBitmap(images.Front);
            faces[3] = CopyImageToDirectBitmap(images.Left);
            faces[4] = CopyImageToDirectBitmap(images.Right);
            faces[5] = CopyImageToDirectBitmap(images.Top);
            return faces;
        }
        private DirectBitmap CopyImageToDirectBitmap(Bitmap image)
        {
            DirectBitmap result = new DirectBitmap(image.Width, image.Height);
            for(int row = 0; row < image.Height; row++)
            {
                for(int col = 0; col < image.Width; col++)
                {
                    result.SetPixel(col, row, image.GetPixel(col, row));
                }
            }
            return result;
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
