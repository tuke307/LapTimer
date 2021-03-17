using System;

using Xamarin.Forms;

namespace LapTimer.SkiaSharp.Helpers
{
    public struct EffortSpan
    {
        public Color Color { get; }

        public string Label { get; }

        public double Threshold { get; }

        public EffortSpan(double threshold, Color color, string label)
        {
            if (threshold < 0 || threshold > 1)
            {
                throw new ArgumentException("threshold >= 0 && threshold <= 1", nameof(threshold));
            }

            Threshold = threshold;
            Color = color;
            Label = label;
        }
    }
}