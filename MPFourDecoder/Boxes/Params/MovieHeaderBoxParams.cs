using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelSorter.MPFourDecoder.Boxes
{
    public class MovieHeaderBoxParams
    {

        public byte Version { get; init; }

        public byte[]? Flags { get; init; } = [0, 0, 0];

        public ulong? CreateDate { get; init; }
        public ulong? ModifiedDated { get; init; }

        public uint? TimeScale { get; init; } = 600;
        public ulong Duration { get; init; }

        public float? PlaybackSpeed { get; init; } = 1.0f;
        public float? PlaybackVolume { get; init; } = 1.0f;

        public short[]? Reserved { get; init; } = [0, 0, 0, 0, 0];

        public float? WindowWidthScale { get; init; } = 1.0f;
        public float? WindowWidthRotate { get; init; } = 0.0f;
        public float? WindowWidthAngle { get; init; } = 0.0f;

        public float? WindowHeightRotate { get; init; } = 0.0f;
        public float? WindowHeightScale { get; init; } = 1.0f;
        public float? WindowHeightAngle { get; init; } = 0.0f;

        public float? WindowX { get; init; } = 0.0f;
        public float? WindowY { get; init; } = 0.0f;
        public float? WindowW { get; init; } = 1.0f;


        //I DONT KNOW WHAT DA FAK IS THIS
        //CONTACT ME THROUG ISSUE IF YOU KNOW <3
        public byte[]? PreviewStartTime { get; init; } = [0, 0, 0, 0, 0, 0, 0, 0];
        public byte[]? StillPoster { get; init; } = [0, 0, 0, 0];
        public byte[]? SelectionTime { get; init; } = [0, 0, 0, 0, 0, 0, 0, 0];
        public byte[]? CurrentTime { get; init; } = [0, 0, 0, 0];

        public int? NextTrackId { get; init; } = 2;
    }
}
