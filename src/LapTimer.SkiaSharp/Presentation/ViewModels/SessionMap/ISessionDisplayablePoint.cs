using LapTimer.SkiaSharp.Helpers;
using System;
using Xamarin.Forms;

namespace LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap
{
    public interface ISessionDisplayablePoint
    {
        int? Altitude { get; }

        int? Distance { get; }

        Color MapPointColor { get; }

        LatLong Position { get; }

        double? Speed { get; }

        TimeSpan Time { get; }
    }
}