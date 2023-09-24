using System;
using System.IO;

namespace MYSTER.Core.Utils
{
    public static class StreamExtensions
    {
        public static UInt32 ReadUInt32LE(this Stream stream, uint index)
        {
            if (index + sizeof(UInt32) > stream.Length)
                throw new ArgumentOutOfRangeException();
            var buffer = new byte[sizeof(UInt32)];
            stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt32(buffer, 0);
        }

        public static UInt16 ReadUInt16LE(this Stream stream, uint index)
        {
            if (index + sizeof(UInt16) > stream.Length)
                throw new ArgumentOutOfRangeException();
            var buffer = new byte[sizeof(UInt16)];
            stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt16(buffer, 0);
        }
    }
}

