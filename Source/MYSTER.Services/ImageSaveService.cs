using MYSTER.Services.Utils;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace MYSTER.Services
{
    public static class ImageSaveService
    {
        public static void Save(string fileSavePath, Bitmap image)
        {
            if (image == null)
                return;
            long quality = 100;
            using (EncoderParameters encoderParameters = new EncoderParameters(1))
            using (EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality))
            {
                ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Png.Guid);
                if (fileSavePath.Contains(".jpg"))
                {
                    codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                }
                encoderParameters.Param[0] = encoderParameter;
                image.Save(fileSavePath, codecInfo, encoderParameters);
            }
        }

        public static readonly byte[] JPG_HEADER = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 };
        public static readonly byte[] PNG_HEADER = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
        public static readonly byte[] BMP_HEADER = new byte[] { 0x42, 0x4D, 0x36, 0x00 };

        public static void Save(string fileSavePath, byte[] imageData)
        {

            var existingExtension = Path.GetExtension(fileSavePath);
            string actualExtension = ".jpg";
            byte[] header = imageData.Take(4).ToArray();
            if (EqualsPatternAtPosition(header, JPG_HEADER, 0))
            {
                actualExtension = ".jpg";
            }
            else if (EqualsPatternAtPosition(header, PNG_HEADER, 0))
            {
                actualExtension = ".png";
            }
            else if (EqualsPatternAtPosition(header, BMP_HEADER, 0))
            {
                actualExtension = ".bmp";
                // dont save as bmp, save as png
                var image = BitmapUtils.LoadBitmapFromMemory(imageData);
                Save(fileSavePath.Replace(".jpg", ".png"), image);
                return;
            }
            fileSavePath = fileSavePath.Replace(existingExtension, actualExtension);

            File.WriteAllBytes(fileSavePath, imageData);
        }

        private static bool EqualsPatternAtPosition(byte[] source, byte[] pattern, int position)
        {
            for (int i = 0; i < pattern.Length; ++i)
                if (position + i >= source.Length || source[position + i] != pattern[i])
                    return false;
            return true;
        }
    }
}
