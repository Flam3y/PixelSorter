using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelSorter.MPFourDecoder.Boxes
{
    public class MovieHeaderBox : Box
    {
        public override int Size { get; init; }
        public override string Type { get; init; } = "mvhd";

        public byte Version { get; init; }

        public byte[] Flags { get; init; }

        public ulong CreateDate { get; init; }
        public ulong ModifiedDated { get; init; }

        public uint TimeScale { get; init; }
        public ulong Duration { get; init; }

        public float PlaybackSpeed { get; init; }
        public float PlaybackVolume { get; init; }

        public short[] Reserved { get; init; }

        public float WindowWidthScale { get; init; }
        public float WindowWidthRotate { get; init; }
        public float WindowWidthAngle { get; init; }

        public float WindowHeightRotate { get; init; }
        public float WindowHeightScale { get; init; }
        public float WindowHeightAngle { get; init; }

        public float WindowX { get; init; }
        public float WindowY { get; init; }
        public float WindowW { get; init; }


        //I DONT KNOW WHAT DA FAK IS THIS
        //CONTACT ME THROUG ISSUE IF YOU KNOW <3
        public byte[] PreviewStartTime { get; init; }
        public byte[] StillPoster { get; init; }
        public byte[] SelectionTime { get; init; }
        public byte[] CurrentTime { get; init; }

        public int NextTrackId { get; init; }

        public MovieHeaderBox(MovieHeaderBoxParams @params)
        {
            Version = @params.Version;
            Flags = @params.Flags ?? [0, 0, 0];
            CreateDate = @params.CreateDate ?? (ulong)(new DateTime(1904, 0, 0) - DateTime.UtcNow).TotalSeconds;
            ModifiedDated = @params.ModifiedDated ?? CreateDate;
            TimeScale = @params.TimeScale ?? 600;
            Duration = @params.Duration;
            PlaybackSpeed = @params.PlaybackSpeed ?? 1.0f;
            PlaybackVolume = @params.PlaybackVolume ?? 1.0f;
            Reserved = @params.Reserved ?? [0, 0, 0, 0, 0];
            WindowWidthScale = @params.WindowWidthScale ?? 1.0f;
            WindowWidthRotate = @params.WindowWidthRotate ?? 0.0f;
            WindowWidthAngle = @params.WindowWidthAngle ?? 0.0f;
            WindowHeightRotate = @params.WindowWidthRotate ?? 0.0f;
            WindowHeightScale = @params.WindowWidthScale ?? 1.0f;
            WindowHeightAngle = @params.WindowWidthAngle ?? 0.0f;
            WindowX = @params.WindowX ?? 0.0f;
            WindowY = @params.WindowY ?? 0.0f;
            WindowW = @params.WindowW ?? 1.0f;
            PreviewStartTime = @params.PreviewStartTime ?? [0, 0, 0, 0, 0, 0, 0, 0];
            StillPoster = @params.StillPoster ?? [0, 0, 0, 0];
            SelectionTime = @params.SelectionTime ?? [0, 0, 0, 0, 0, 0, 0, 0];
            CurrentTime = @params.CurrentTime ?? [0, 0, 0, 0];
            NextTrackId = @params.NextTrackId ?? 2;

            Size = 4 + 4 + 1 + 3 + (4 + 4 * Version) + (4 + 4 * Version) + 4 + (4 + 4 * Version) + 4 + 2 + 10 + 4 + 4 + 4 + 4 + 4 + 4 + 4 + 4 + 4 + 8 + 4 + 8 + 4 + 4;
        }

        public MovieHeaderBox(int size, byte[] boxData)
        {
            int offset = 0;

            Version = boxData[offset];
            offset += 1;

            Flags = boxData[offset..(offset+3)];
            offset += 3;

            if (Version == 0)
            {
                CreateDate = BitConverter.ToUInt32(boxData[offset..(offset + 4)]);
                offset += 4;

                ModifiedDated = BitConverter.ToUInt32(boxData[offset..(offset + 4)]);
                offset += 4;
            }
            else if(Version == 1)
            {
                CreateDate = BitConverter.ToUInt64(boxData[offset..(offset + 8)]);
                offset += 8;

                ModifiedDated = BitConverter.ToUInt64(boxData[offset..(offset + 8)]);
                offset += 8;
            }

            TimeScale = BitConverter.ToUInt32(boxData[offset..(offset + 4)]);
            offset += 4;

            if (Version == 0)
            {
                Duration = BitConverter.ToUInt32(boxData[offset..(offset + 4)]);
                offset += 4;
            }
            else if (Version == 1)
            {
                Duration = BitConverter.ToUInt64(boxData[offset..(offset + 8)]);
                offset += 8;
            }

            PlaybackSpeed = BitConverter.ToSingle(boxData[offset..(offset + 4)]);
            offset += 4;
            PlaybackVolume = BitConverter.ToSingle(boxData[offset..(offset + 2)]);
            offset += 2;

            for(int i = 0; i < 5;)
            {
                Reserved![i] = BitConverter.ToInt16(boxData[offset..(offset + 2)]);
                offset += 2;
                i++;
            }

            Size = size;
        }

        public override byte[] Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
