using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MYSTERAssetExplorer.Utils
{
    public static class Extensions
    {
        public static UInt32 ReadUInt32LE(this FileStream fileStream, uint index)
        {
            if (index + sizeof(UInt32) > fileStream.Length)
                throw new ArgumentOutOfRangeException();
            var buffer = new byte[sizeof(UInt32)];
            fileStream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt32(buffer, 0);
        }

        public static UInt16 ReadUInt16LE(this FileStream fileStream, uint index)
        {
            if (index + sizeof(UInt16) > fileStream.Length)
                throw new ArgumentOutOfRangeException();
            var buffer = new byte[sizeof(UInt16)];
            fileStream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt16(buffer, 0);
        }

        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            box.SelectionStart = box.Text.Length;
            box.ScrollToCaret();
        }


        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
    }
}

