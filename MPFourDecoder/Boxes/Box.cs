using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelSorter.MPFourDecoder.Boxes
{
    public abstract class Box
    {
        public abstract int Size { get; init; }
        public abstract string Type { get; init; }

        public abstract byte[] Serialize();
    }
}
