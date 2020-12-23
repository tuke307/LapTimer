using System;

namespace SkiaSharpnado.Maps.Domain
{
    public class ActivityPoint
    {
        public int AltitudeInMeters { get; }

        public int DistanceInMeters { get; }

        public int? HeartRate { get; }

        public LatLong Position { get; }

        public double? Speed { get; }

        public DateTime TimeStamp { get; }

        public ActivityPoint(DateTime timeStamp, int? heartRate, LatLong position, int distanceInMeters, int altitudeInMeters, double? speed = null)
        {
            TimeStamp = timeStamp;
            HeartRate = heartRate;
            Position = position;
            DistanceInMeters = distanceInMeters;
            AltitudeInMeters = altitudeInMeters;
            Speed = speed;
        }
    }
}