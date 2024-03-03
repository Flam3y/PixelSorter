using PixelSorter.MPFourDecoder;
using PixelSorter.MPFourDecoder.Boxes;
using System.Text;

namespace PixelSorter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("Input/input.mp4"))
            {
                Console.WriteLine("Input file doesnt exist, create a file \"Input/input.mp4\"");
                Environment.Exit(-1);
            }

            byte[] videoBytes = File.ReadAllBytes("Input/input.mp4");

            int offset = 0;

            List<Box> boxes = new List<Box>();

            while (offset < videoBytes.Length)
            {
                

                int boxSize = (int)BitConverter.ToUInt32(videoBytes[offset..(offset+4)].Reverse().ToArray());
                offset += 4;

                string boxType = Encoding.ASCII.GetString(videoBytes[offset..(offset + 4)]);
                offset += 4;

                switch (boxType)
                {
                    case "ftyp":
                        {
                            boxes.Add(new FileTypeBox(boxSize, videoBytes[offset..(offset+boxSize)]));
                            
                            offset += boxSize;
                            break;
                        }
                    case "mvhd":
                        {
                            byte[] data = videoBytes[offset..(offset + boxSize)];
                            Console.WriteLine(data[0]);
                            break;
                        }
                    default:
                        {
                            offset += boxSize;
                            break;
                        }
                }
            }
        }
    }
}
