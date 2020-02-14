using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public Bitmap ConvertToEquirectangular(CubemapImages cubeMap)
        {
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
            int outputWidth = outputHeight * 2;            

            Bitmap equiTexture = new Bitmap(outputWidth, outputHeight);

            //Normalised UV texture coordinates, from 0 to 1, starting at lower left corner
            double u_coordinate;
            double v_coordinate;
            //Polar coordinates
            double latitude;
            double longitude;
            //Unit vector
            double x, y, z;
            double xAbsolute, yAbsolute, zAbsolute;
            double largestAbsolute;
            double[] vector = new double[3];

            Color color;
            int xPixel;
            int yPixel;

            for (int heightIndex = 0; heightIndex < equiTexture.Height; heightIndex++)
            {
                v_coordinate = (heightIndex / equiTexture.Height);
                latitude = v_coordinate * Math.PI;

                

                for (int widthIndex = 0; widthIndex < equiTexture.Width; widthIndex++)
                {
                    u_coordinate = (widthIndex / equiTexture.Width);
                    longitude = u_coordinate * 2 * Math.PI;

                    //assuming Y+ is front, X+ is right, Z+ is up

                    //Calculate unit vector
                    x = Math.Cos(latitude) * Math.Cos(longitude);
                    y = Math.Cos(latitude) * Math.Sin(longitude);
                    z = Math.Sin(latitude);

                    vector[0] = Math.Abs(x);
                    vector[1] = Math.Abs(y);
                    vector[2] = Math.Abs(z);
                    largestAbsolute = vector.Max();

                    //Vector Parallel to the unit vector that lies on one of the cube faces
                    xAbsolute = x / largestAbsolute;
                    yAbsolute = y / largestAbsolute;
                    zAbsolute = z / largestAbsolute;

                    if (xAbsolute == 1)
                    {
                        //Right
                        xPixel = (int)((((zAbsolute + 1f) / 2f) - 1f) * cubeFaceWidth);
                        yPixel = (int)((((yAbsolute + 1f) / 2f)) * cubeFaceHeight);
                        xPixel = Math.Abs(xPixel);
                        yPixel = Math.Abs(yPixel);
                        color = cubeMap.Right.GetPixel(xPixel, yPixel);
                    }
                    else if (xAbsolute == -1)
                    {
                        //Left
                        xPixel = (int)((((zAbsolute + 1f) / 2f)) * cubeFaceWidth);
                        yPixel = (int)((((yAbsolute + 1f) / 2f)) * cubeFaceHeight);
                        xPixel = Math.Abs(xPixel);
                        yPixel = Math.Abs(yPixel);
                        color = cubeMap.Left.GetPixel(xPixel, yPixel);
                    }
                    else if (yAbsolute == 1)
                    {
                        //Up
                        xPixel = (int)((((xAbsolute + 1f) / 2f)) * cubeFaceWidth);
                        yPixel = (int)((((zAbsolute + 1f) / 2f) - 1f) * cubeFaceHeight);
                        xPixel = Math.Abs(xPixel);
                        yPixel = Math.Abs(yPixel);
                        color = cubeMap.Top.GetPixel(xPixel, yPixel);
                    }
                    else if (yAbsolute == -1)
                    {
                        //Down
                        xPixel = (int)((((xAbsolute + 1f) / 2f)) * cubeFaceWidth);
                        yPixel = (int)((((zAbsolute + 1f) / 2f)) * cubeFaceHeight);
                        xPixel = Math.Abs(xPixel);
                        yPixel = Math.Abs(yPixel);
                        color = cubeMap.Bottom.GetPixel(xPixel, yPixel);
                    }
                    else if (zAbsolute == 1)
                    {
                        //Front
                        xPixel = (int)((((xAbsolute + 1f) / 2f)) * cubeFaceWidth);
                        yPixel = (int)((((yAbsolute + 1f) / 2f)) * cubeFaceHeight);
                        xPixel = Math.Abs(xPixel);
                        yPixel = Math.Abs(yPixel);
                        color = cubeMap.Front.GetPixel(xPixel, yPixel);
                    }
                    else if (zAbsolute == -1)
                    {
                        //Back
                        xPixel = (int)((((xAbsolute + 1f) / 2f) - 1f) * cubeFaceWidth);
                        yPixel = (int)((((yAbsolute + 1f) / 2f)) * cubeFaceHeight);
                        xPixel = Math.Abs(xPixel);
                        yPixel = Math.Abs(yPixel);
                        color = cubeMap.Back.GetPixel(xPixel, yPixel);
                    }
                    else
                    {
                        throw new Exception("Unknown face, something went wrong");
                    }

                    equiTexture.SetPixel(widthIndex, heightIndex, color);
                }
            }
            return equiTexture;
        }

        private void SphericalCoordinates()
        {

        }
    }
}
