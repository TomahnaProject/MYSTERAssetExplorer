using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYSTERAssetExplorer.Services
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
