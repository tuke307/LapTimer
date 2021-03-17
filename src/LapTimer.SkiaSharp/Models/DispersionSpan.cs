using Xamarin.Forms;

namespace LapTimer.SkiaSharp.ViewModels
{
    public interface IDispersionSpan
    {
        Color Color { get; }

        double Value { get; }

        void IncrementValue(double value);
    }

    public struct DispersionSpan : IDispersionSpan
    {
        public Color Color { get; }

        public double Value { get; private set; }

        public DispersionSpan(Color color, double value)
        {
            Color = color;
            Value = value;
        }

        public void IncrementValue(double value)
        {
            Value += value;
        }
    }
}