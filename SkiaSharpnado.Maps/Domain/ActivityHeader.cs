using System;

namespace SkiaSharpnado.Maps.Domain
{
    public class ActivityHeader
    {
        public int DistanceInMeters { get; }

        public TimeSpan Duration { get; }

        public bool HasSpeed { get; }

        public string Id => LastPointTime.ToString("yyyyMMdd_HHmm");

        public DateTime LastPointTime { get; }

        public double MaximumSpeed { get; }

        public string Name { get; }

        public ActivityHeader(
            string name,
            DateTime lastPointTime,
            TimeSpan duration,
            int distanceInMeters,
            double maximumSpeed,
            bool hasSpeed)
        {
            Name = name;
            LastPointTime = lastPointTime;
            Duration = duration;
            DistanceInMeters = distanceInMeters;
            MaximumSpeed = maximumSpeed; HasSpeed = hasSpeed;
        }
    }
}