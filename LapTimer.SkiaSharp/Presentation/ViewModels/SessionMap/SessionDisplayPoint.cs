using LapTimer.SkiaSharp.Helpers;
using System;
using Xamarin.Forms;

namespace LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap
{
    public interface ISessionDisplayablePoint
    {
        int? Altitude { get; }

        int? Distance { get; }

        bool HasMarker { get; }

        string Label { get; }

        Color MapPointColor { get; }

        LatLong Position { get; }

        double? Speed { get; }

        TimeSpan Time { get; }
    }

    public class SessionDisplayablePoint : ISessionDisplayablePoint
    {
        public int? Altitude { get; }

        public int? Distance { get; }

        public bool HasMarker { get; }

        public bool HasPosition => Position != LatLong.Empty;

        public string Label { get; }

        public Color MapPointColor { get; private set; }

        public LatLong Position { get; }

        public double? Speed { get; }

        public TimeSpan Time { get; }

        public SessionDisplayablePoint(
            TimeSpan timeSpan,
            int? distance,
            int? altitude,
            double? speed,
            LatLong position,
            bool hasMarker = false,
            string label = null)
        {
            Time = timeSpan;

            Altitude = altitude;
            Speed = speed;
            Position = position;
            Distance = distance;

            MapPointColor = Color.Default;
            HasMarker = hasMarker;
            Label = label;
        }

        public void SetPointColor(Color color)
        {
            MapPointColor = color;
        }
    }
}