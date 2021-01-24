using LapTimer.SkiaSharp.Helpers;
using System;

namespace LapTimer.SkiaSharp.Models
{
    public class ActivityPoint
    {
        public int AltitudeInMeters { get; }

        public int DistanceInMeters { get; }

        public LatLong Position { get; }

        public double? Speed { get; }

        public DateTime TimeStamp { get; }

        public ActivityPoint(DateTime timeStamp, LatLong position, int distanceInMeters, int altitudeInMeters, double? speed = null)
        {
            TimeStamp = timeStamp;
            Position = position;
            DistanceInMeters = distanceInMeters;
            AltitudeInMeters = altitudeInMeters;
            Speed = speed;
        }
    }
}