using LapTimer.SkiaSharp.Helpers;
using LapTimer.SkiaSharp.Models;
using LapTimer.SkiaSharp.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap
{
    public class SessionMap : SessionList<SessionDisplayablePoint>
    {
        public Position BottomLeft { get; private set; }

        public MapSpan Region { get; private set; }

        public List<SessionDisplayablePoint> SessionPoints { get; }

        public Position TopRight { get; private set; }

        public int TotalDurationInSeconds
        {
            get
            {
                if (SessionPoints.Count > 0)
                {
                    var lastPoint = SessionPoints.Last();

                    if (lastPoint.Time != null)
                    {
                        return (int)lastPoint.Time.TotalSeconds;
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionMap" /> class.
        /// </summary>
        public SessionMap()
        {
            SessionPoints = new List<SessionDisplayablePoint>();

            double topLatitude = LatLong.Min.Latitude;
            double bottomLatitude = LatLong.Max.Latitude;
            double leftLongitude = LatLong.Max.Longitude;
            double rightLongitude = LatLong.Min.Longitude;

            BottomLeft = new Position(bottomLatitude, leftLongitude);
            TopRight = new Position(topLatitude, rightLongitude);

            Region = GeoCalculation.BoundsToMapSpan(BottomLeft, TopRight);
        }

        /// <summary>
        /// Creation with SessionDisplayablePoints.
        /// </summary>
        /// <param name="sessionPoints">The session points.</param>
        /// <param name="bottomLeft">The bottom left.</param>
        /// <param name="topRight">The top right.</param>
        /// <param name="totalDurationInSeconds">The total duration in seconds.</param>
        public SessionMap(
            List<SessionDisplayablePoint> sessionPoints,
            Position bottomLeft,
            Position topRight)
        {
            SessionPoints = sessionPoints;
            BottomLeft = bottomLeft;
            TopRight = topRight;
            Region = GeoCalculation.BoundsToMapSpan(bottomLeft, topRight);
        }

        /// <summary>
        /// Creation with ActivityPoints.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <param name="colorBaseValueSelector">The color base value selector.</param>
        /// <returns></returns>
        public static SessionMap Create(
            List<ActivityPoint> points,
            Func<ISessionDisplayablePoint, Color?> colorBaseValueSelector)
        {
            if (points == null)
            {
                Debug.WriteLine("SessionMap points is null");
                //throw new ArgumentException();
                return null;
            }

            // mindestens zwei punkte für Geschwindigkeitsberechnung
            if (points.Count < 2)
            {
                Debug.WriteLine("SessionMap points not greater than 2");
                //throw new ArgumentException();
                return null;
            }

            var sessionPoints = new SessionDisplayablePoint[points.Count];

            double topLatitude = LatLong.Min.Latitude;
            double bottomLatitude = LatLong.Max.Latitude;
            double leftLongitude = LatLong.Max.Longitude;
            double rightLongitude = LatLong.Min.Longitude;

            SessionDisplayablePoint previousPoint = null;
            DateTime startTime = points[0].TimeStamp;
            for (int index = 0; index < points.Count; index++)
            {
                ActivityPoint point = points[index];

                if (point.Position != LatLong.Empty)
                {
                    topLatitude = Math.Max(point.Position.Latitude, topLatitude);
                    bottomLatitude = Math.Min(point.Position.Latitude, bottomLatitude);
                    leftLongitude = Math.Min(point.Position.Longitude, leftLongitude);
                    rightLongitude = Math.Max(point.Position.Longitude, rightLongitude);
                }

                TimeSpan elapsedTime = point.TimeStamp - startTime;

                double? speed = point.Speed;
                if (speed == null
                    && previousPoint != null
                    && previousPoint.HasPosition
                    && previousPoint.Distance.HasValue
                    && point.Position != LatLong.Empty
                    && point.DistanceInMeters > 0
                    && elapsedTime.TotalSeconds > 0)
                {
                    double kilometersTraveled =
                        GeoCalculation.HaversineDistance(previousPoint.Position, point.Position);
                    double hoursElapsed = (elapsedTime - previousPoint.Time).TotalHours;
                    speed = kilometersTraveled / hoursElapsed;
                }

                var currentPoint = sessionPoints[index] = new SessionDisplayablePoint(
                    elapsedTime,
                    point.DistanceInMeters,
                    point.AltitudeInMeters,
                    speed,
                    point.Position);

                Color mapPointColor =
                    colorBaseValueSelector(currentPoint) ?? previousPoint?.MapPointColor ?? Color.Gray;

                currentPoint.SetPointColor(mapPointColor);
                previousPoint = currentPoint;
            }

            return new SessionMap(
                sessionPoints.ToList(),
                new Position(bottomLatitude, leftLongitude),
                new Position(topLatitude, rightLongitude));
        }

        /// <summary>
        /// Adds the specified session displayable point.
        /// </summary>
        /// <param name="sessionDisplayablePoint">The session displayable point.</param>
        public void Add(ActivityPoint point)
        {
            SessionDisplayablePoint previousPoint =
                SessionPoints.Count > 0
                ? SessionPoints.Last()
                : null;
            DateTime startTime = point.TimeStamp;
            SessionDisplayablePoint sessionDisplayablePoint;
            TimeSpan elapsedTime = point.TimeStamp - startTime;

            double? speed = point.Speed;
            if (speed == null
                && previousPoint != null
                && previousPoint.HasPosition
                && previousPoint.Distance.HasValue
                && point.Position != LatLong.Empty
                && point.DistanceInMeters > 0
                && elapsedTime.TotalSeconds > 0)
            {
                double kilometersTraveled =
                    GeoCalculation.HaversineDistance(previousPoint.Position, point.Position);
                double hoursElapsed = (elapsedTime - previousPoint.Time).TotalHours;
                speed = kilometersTraveled / hoursElapsed;
            }

            sessionDisplayablePoint = new SessionDisplayablePoint(
                    elapsedTime,
                    point.DistanceInMeters,
                    point.AltitudeInMeters,
                    speed,
                    point.Position);

            if (GeoCalculation.IsPointNewLeftBottom(BottomLeft, sessionDisplayablePoint.Position.ToPosition()) ||
                GeoCalculation.IsPointNewTopRight(TopRight, sessionDisplayablePoint.Position.ToPosition()))
            {
                BottomLeft = sessionDisplayablePoint.Position.ToPosition();
                TopRight = sessionDisplayablePoint.Position.ToPosition();
                Region = GeoCalculation.BoundsToMapSpan(BottomLeft, TopRight);
            }

            SessionPoints.Add(sessionDisplayablePoint);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="sessionDisplayablePoints">The session displayable points.</param>
        public void AddRange(List<ActivityPoint> points)
        {
            if (points == null)
            {
                Debug.WriteLine("SessionMap points is null");
                //throw new ArgumentException();
                return;
            }

            foreach (var point in points)
            {
                Add(point);
            }
        }
    }
}