using LapTimer.SkiaSharp.Helpers;
using System;
using Xamarin.Forms;

namespace LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap
{
    public class SessionDisplayablePoint : ISessionDisplayablePoint
    {
        public int? Altitude { get; }

        public int? Distance { get; }

        public bool HasMarker { get; }

        public bool HasPosition => Position != LatLong.Empty;

        public Color MapPointColor { get; private set; }

        public LatLong Position { get; }

        public double? Speed { get; }

        public TimeSpan Time { get; }

        public SessionDisplayablePoint(
            TimeSpan timeSpan,
            int? distance,
            int? altitude,
            double? speed,
            LatLong position)
        {
            Time = timeSpan;
            Altitude = altitude;
            Speed = speed;
            Position = position;
            Distance = distance;

            MapPointColor = Color.Default;
        }

        public void SetPointColor(Color color)
        {
            MapPointColor = color;
        }
    }
}