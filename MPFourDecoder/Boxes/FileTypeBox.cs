using PixelSorter.MPFourDecoder.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelSorter.MPFourDecoder.Boxes
{
    public class FileTypeBox : Box
    {
        public override int Size { get; init; }
        public override string Type { get; init; } = "ftyp";

        public string MajorBrand { get; init; }
        public uint MinorVersion { get; init; }

        public string[] CompatibleBrands { get; init; }

        public FileTypeBox(int size, byte[] boxData)
        {
            List<string> compatibleBrands = new();

            MajorBrand = Encoding.UTF8.GetString(boxData[..4]);
            MinorVersion = BitConverter.ToUInt32(boxData[4..8]);

            for (int i = 8; i <= size - 4;)
            {
                compatibleBrands.Add(Encoding.UTF8.GetString(boxData[i..(i + 4)]));
                i += 4;
            }

            Size = size;
            CompatibleBrands = compatibleBrands.ToArray();
        }

        public FileTypeBox(string majorBrand, uint minorVersion, string[] compatibleBrands)
        {
            MajorBrand = majorBrand;
            MinorVersion = minorVersion;
            CompatibleBrands = compatibleBrands;
            Size = 4 + 4 + 4 + 4 + 4 * compatibleBrands.Length;
        }

        public override byte[] Serialize()
        {
            byte[] data = new byte[Size + 8];

            data.Write32(0, Size);
            data.WriteString(4, Type, Encoding.UTF8);

            data.WriteString(8, MajorBrand, Encoding.UTF8);
            data.WriteU32(12, MinorVersion);

            int offset = 16;

            foreach (string brand in CompatibleBrands)
            {
                data.WriteString(offset, brand, Encoding.UTF8);
                offset += 4;
            }

            return data;
        }
    }
}
