using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DllThings;

internal static class StreamExtensions
{
    public unsafe static void Write<T>(this Stream stream, T value) where T : unmanaged
    {
        // TODO: manage endianness

        // convert value to a span of bytes
        byte* ptr = (byte*)&value;
        var span = new ReadOnlySpan<byte>(ptr, sizeof(T));

        stream.Write(span);
    }

    public unsafe static void Write(this Stream stream, string value)
    {
        Span<byte> bytes = stackalloc byte[value.Length + 1];

        // null-terminate
        bytes[value.Length] = 0;

        Encoding.UTF8.GetBytes(value, bytes);
        stream.Write(bytes);
    }

    public unsafe static void Write(this Stream stream, string value, int length)
    {
        Span<byte> bytes = stackalloc byte[length];
        Encoding.UTF8.GetBytes(value, bytes);
        stream.Write(bytes);
    }

    public static void Pad(this Stream stream, int length)
    {
        for (int i = 0; i < length; i++)
        {
            stream.WriteByte(0x00);
        }
    }

    public static void PadTo(this Stream stream, int position)
    {
        stream.Pad(position - (int)stream.Position);
    }

    public static void AlignTo(this Stream stream, int alignment)
    {
        stream.PadTo(NextFactor((int)stream.Position, alignment));
    }

    private static int NextFactor(int value, int factor)
    {
        if (value % factor == 0)
            return value;

        return value + (factor - value % factor);
    }
}