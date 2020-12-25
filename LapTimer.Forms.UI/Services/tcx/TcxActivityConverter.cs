using SkiaSharpnado.Maps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using TcxTools;

namespace LapTimer.Forms.UI.Services
{
    /// <summary>
    /// TcxActivityConverter.
    /// </summary>
    public static class TcxActivityConverter
    {
        public static ActivityHeader ToActivityHeader(this Activity activity)
        {
            var lap = activity.Lap[0];

            var firstPoint = lap.Track[0];
            var tpx = firstPoint.Extensions.Any.FirstOrDefault();
            bool hasSpeed = tpx != null && tpx.InnerXml.Contains("Speed");

            return new ActivityHeader(
                activity.Notes,
                lap.Track.Last().Time,
                TimeSpan.FromSeconds(lap.TotalTimeSeconds),
                (int)lap.DistanceMeters,
                lap.MaximumSpeed,
                hasSpeed);
        }

        public static List<ActivityPoint> ToActivityPoints(this Activity activity)
        {
            var result = new List<ActivityPoint>();
            var track = activity.Lap[0].Track;
            foreach (var point in track)
            {
                double? speed = null;
                var tpx = point.Extensions.Any.FirstOrDefault();
                bool hasSpeed = tpx != null && tpx.InnerXml.Contains("Speed");
                if (hasSpeed)
                {
                    speed = double.Parse(tpx.InnerText, System.Globalization.CultureInfo.InvariantCulture) * 3.6;
                }

                result.Add(
                    new ActivityPoint(
                        point.Time,
                        point.Position == null
                            ? LatLong.Empty
                            : new LatLong(point.Position.LatitudeDegrees, point.Position.LongitudeDegrees),
                        (int)point.DistanceMeters,
                        (int)point.AltitudeMeters,
                        speed));
            }

            return result;
        }
    }
}