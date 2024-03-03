using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelSorter.MPFourDecoder.Extensions;

public static class Extensions
{
    public static void WriteU32(this byte[] array, int offset, uint data)
    {
        if(array.Length < offset+4) 
        {
            throw new ArgumentException("Data doesn't fit in input array with this offset!");
        }

        byte[] dataBytes = BitConverter.GetBytes(data);

        for (int i = 0; i < dataBytes.Length; i++)
        {
            array[offset + i] = dataBytes[i];
        }
    }
    public static void Write32(this byte[] array, int offset, int data)
    {
        if (array.Length < offset + 4)
        {
            throw new ArgumentException("Data doesn't fit in input array with this offset!");
        }

        byte[] dataBytes = BitConverter.GetBytes(data);

        for (int i = 0; i < dataBytes.Length; i++)
        {
            array[offset + i] = dataBytes[i];
        }
    }

    public static void WriteString(this byte[] array, int offset, string data, Encoding encoding)
    {
        if (array.Length < offset + encoding.GetByteCount(data))
        {
            throw new ArgumentException("Data doesn't fit in input array with this offset!");
        }

        byte[] dataBytes = encoding.GetBytes(data);

        for (int i = 0; i < dataBytes.Length; i++)
        {
            array[offset + i] = dataBytes[i];
        }
    }
}
