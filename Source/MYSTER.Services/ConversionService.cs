﻿using System.Linq;

namespace MYSTER.Services
{
    public static class ConversionService
    {
        // just strips off the start of the file to get the actual JFIF data
        public static byte[] ConvertFromZapToJpg(byte[] data)
        {
            var ZapFileRealStartIndex = 32;
            var truncatedFile = data.Skip(ZapFileRealStartIndex).ToArray();
            return truncatedFile;
        }
    }
}
