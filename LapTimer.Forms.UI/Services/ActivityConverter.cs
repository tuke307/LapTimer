using Data.Models;
using SkiaSharpnado.Maps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LapTimer.Forms.UI.Services
{
    public static class ActivityConverter
    {
        public static ActivityHeader ToActivityHeader(this RideModel ride)
        {
            var lap = ride.Laps[0];

            var firstPoint = lap.Trackpoints[0];

            return new ActivityHeader(
                ride.Name,
                lap.Trackpoints.Last().CreatedDate.Value,
                TimeSpan.FromSeconds(lap.TotalTimeSeconds),
                (int)lap.DistanceMeters,
                lap.MaximumSpeed);
        }

        //public static List<ActivityPoint> ToActivityPoints(this Activity activity)
        //{
        //    var result = new List<ActivityPoint>();
        //    var track = activity.Lap[0].Track;
        //    foreach (var point in track)
        //    {
        //        double? speed = null;
        //        var tpx = point.Extensions.Any.FirstOrDefault();
        //        bool hasSpeed = tpx != null && tpx.InnerXml.Contains("Speed");
        //        if (hasSpeed)
        //        {
        //            speed = double.Parse(tpx.InnerText, System.Globalization.CultureInfo.InvariantCulture) * 3.6;
        //        }

        // result.Add( new ActivityPoint( point.Time, point.HeartRateBpm?.Value,
        // point.Position == null ? LatLong.Empty : new
        // LatLong(point.Position.LatitudeDegrees, point.Position.LongitudeDegrees),
        // (int)point.DistanceMeters, (int)point.AltitudeMeters, speed)); }

        //    return result;
        //}
    }
}