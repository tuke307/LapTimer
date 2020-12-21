using SkiaSharpnado.Maps.Domain;
using SkiaSharpnado.ViewModels;
using System;
using System.Collections.Generic;

namespace LapTimer.Forms.UI.Models
{
    public class ActivityHeaderModel
    {
        public List<IDispersionSpan> Dispersion { get; }

        public string DisplayableAverageSpeed { get; }

        public string DisplayableDistance { get; }

        public string DisplayableStartTime { get; }

        public string DisplayableTimeSpan { get; }

        public int DistanceInMeters { get; }

        public TimeSpan Duration { get; }

        public string Id => LastPointTime.ToString("yyyyMMdd_HHmm");

        public DateTime LastPointTime { get; }

        public double MaximumSpeed { get; }

        public string Name { get; }

        public ActivityHeaderModel(ActivityHeader header, List<IDispersionSpan> dispersion)
        {
            Name = header.Name;
            Dispersion = dispersion;
            LastPointTime = header.LastPointTime;
            Duration = header.Duration;
            DistanceInMeters = header.DistanceInMeters;
            MaximumSpeed = header.MaximumSpeed;

            DisplayableStartTime = LastPointTime.ToLocalTime().ToSmartShortDate();
            DisplayableDistance = (DistanceInMeters / 1000f).ToString("0.00");
            DisplayableTimeSpan = $"{Duration:h\\:mm}";
            DisplayableAverageSpeed = $"{((DistanceInMeters / 1000f) / Duration.TotalHours):0.0}";
        }
    }
}