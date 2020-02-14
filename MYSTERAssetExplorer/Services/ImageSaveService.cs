using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public static class ImageSaveService
    {
        public static void Save(string fileSavePath, Bitmap image)
        {
            long quality = 100;
            using (EncoderParameters encoderParameters = new EncoderParameters(1))
            using (EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality))
            {
                ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Png.Guid);
                encoderParameters.Param[0] = encoderParameter;

                fileSavePath.Replace(".jpg", ".png");
                image.Save(fileSavePath, codecInfo, encoderParameters);
            }
        }
    }
}
