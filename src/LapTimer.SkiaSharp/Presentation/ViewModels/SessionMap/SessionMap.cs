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
        public Position BottomLeft { get; }

        public MapSpan Region { get; }

        public List<SessionDisplayablePoint> SessionPoints { get; }

        public Position TopRight { get; }

        public int TotalDurationInSeconds { get; }

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
            Position topRight,
            int totalDurationInSeconds)
        {
            SessionPoints = sessionPoints;
            BottomLeft = bottomLeft;
            TopRight = topRight;
            Region = GeoCalculation.BoundsToMapSpan(bottomLeft, topRight);
            TotalDurationInSeconds = totalDurationInSeconds;
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
                new Position(topLatitude, rightLongitude),
                previousPoint != null ? (int)previousPoint.Time.TotalSeconds : 0);
        }

        /// <summary>
        /// Adds the specified session displayable point.
        /// </summary>
        /// <param name="sessionDisplayablePoint">The session displayable point.</param>
        public new void Add(ActivityPoint point)
        {
            SessionDisplayablePoint previousPoint = SessionPoints.Last();
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

            SessionPoints.Add(sessionDisplayablePoint);
        }

        public new void Add(Position position)
        {
            SessionDisplayablePoint sessionDisplayablePoint;

            //double? speed = point.Speed;
            //if (speed == null
            //    && previousPoint != null
            //    && previousPoint.HasPosition
            //    && previousPoint.Distance.HasValue
            //    && point.Position != LatLong.Empty
            //    && point.DistanceInMeters > 0
            //    && elapsedTime.TotalSeconds > 0)
            //{
            //    double kilometersTraveled =
            //        GeoCalculation.HaversineDistance(previousPoint.Position, position.ToLatLong());
            //    double hoursElapsed = (elapsedTime - previousPoint.Time).TotalHours;
            //    speed = kilometersTraveled / hoursElapsed;
            //}

            sessionDisplayablePoint = new SessionDisplayablePoint(
                   TimeSpan.FromMilliseconds(1),
                    0,
                    0,
                    0,
                    position.ToLatLong());

            SessionPoints.Add(sessionDisplayablePoint);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="sessionDisplayablePoints">The session displayable points.</param>
        public new void AddRange(List<ActivityPoint> points,
            Func<ISessionDisplayablePoint, Color?> colorBaseValueSelector)
        {
            //SessionDisplayablePoint previousPoint = SessionPoints.Last();
            //DateTime startTime = point.TimeStamp;
            //SessionDisplayablePoint sessionDisplayablePoint;
            //TimeSpan elapsedTime = point.TimeStamp - startTime;

            //double? speed = point.Speed;
            //if (speed == null
            //    && previousPoint != null
            //    && previousPoint.HasPosition
            //    && previousPoint.Distance.HasValue
            //    && point.Position != LatLong.Empty
            //    && point.DistanceInMeters > 0
            //    && elapsedTime.TotalSeconds > 0)
            //{
            //    double kilometersTraveled =
            //        GeoCalculation.HaversineDistance(previousPoint.Position, point.Position);
            //    double hoursElapsed = (elapsedTime - previousPoint.Time).TotalHours;
            //    speed = kilometersTraveled / hoursElapsed;
            //}

            //sessionDisplayablePoint = new SessionDisplayablePoint(
            //        elapsedTime,
            //        point.DistanceInMeters,
            //        point.AltitudeInMeters,
            //        speed,
            //        point.Position);

            //Color mapPointColor =
            //    colorBaseValueSelector(sessionDisplayablePoint) ?? previousPoint?.MapPointColor ?? Color.Gray;

            //sessionDisplayablePoint.SetPointColor(mapPointColor);
            //previousPoint = sessionDisplayablePoint;

            //SessionPoints.Add(sessionDisplayablePoint);
        }
    }
}