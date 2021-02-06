using LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LapTimer.SkiaSharp.Models
{
    public class SessionGraph
    {
        public ValueBounds Altitude { get; }

        public List<SessionDisplayablePoint> SessionPoints { get; }

        public ValueBounds Speed { get; }

        public int TotalDurationInSeconds { get; }

        public SessionGraph(
            List<SessionDisplayablePoint> sessionPoints,
            ValueBounds speed,
            ValueBounds altitude,
            int totalDurationInSeconds)
        {
            SessionPoints = sessionPoints;
            Speed = speed;
            Altitude = altitude;
            TotalDurationInSeconds = totalDurationInSeconds;
        }

        public static SessionGraph CreateSessionGraphInfo(List<SessionDisplayablePoint> sessionPoints)
        {
            if (sessionPoints == null || sessionPoints.Count < 2)
            {
                throw new ArgumentException();
            }

            var speedBounds = new ValueBounds(sessionPoints.Min(p => p.Speed ?? int.MaxValue), sessionPoints.Max(p => p.Speed ?? 0));
            var altitudeBounds = new ValueBounds(sessionPoints.Min(p => p.Altitude ?? int.MaxValue), sessionPoints.Max(p => p.Altitude ?? 0));

            int totalDuration = (int)sessionPoints.Last().Time.TotalSeconds;

            return new SessionGraph(sessionPoints, speedBounds, altitudeBounds, totalDuration);
        }
    }
}