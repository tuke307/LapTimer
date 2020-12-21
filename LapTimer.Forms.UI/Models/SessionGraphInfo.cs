using SkiaSharpnado.Maps.Presentation.ViewModels.SessionMap;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LapTimer.Forms.UI.Models
{
    public class SessionGraphInfo
    {
        public ValueBounds Altitude { get; }

        public IReadOnlyList<ISessionDisplayablePoint> SessionPoints { get; }

        public ValueBounds Speed { get; }

        public int TotalDurationInSeconds { get; }

        public SessionGraphInfo(
            IReadOnlyList<ISessionDisplayablePoint> sessionPoints,
            ValueBounds speed,
            ValueBounds altitude,
            int totalDurationInSeconds)
        {
            SessionPoints = sessionPoints;
            Speed = speed;
            Altitude = altitude;
            TotalDurationInSeconds = totalDurationInSeconds;
        }

        public static SessionGraphInfo CreateSessionGraphInfo(IReadOnlyList<ISessionDisplayablePoint> points)
        {
            if (points == null || points.Count < 2)
            {
                throw new ArgumentException();
            }

            var heartRateBounds = new ValueBounds(points.Min(p => p.HeartRate ?? int.MaxValue), points.Max(p => p.HeartRate ?? 0));
            var speedBounds = new ValueBounds(points.Min(p => p.Speed ?? int.MaxValue), points.Max(p => p.Speed ?? 0));
            var altitudeBounds = new ValueBounds(points.Min(p => p.Altitude ?? int.MaxValue), points.Max(p => p.Altitude ?? 0));

            int totalDuration = (int)points.Last().Time.TotalSeconds;

            return new SessionGraphInfo(points, speedBounds, altitudeBounds, totalDuration);
        }
    }
}