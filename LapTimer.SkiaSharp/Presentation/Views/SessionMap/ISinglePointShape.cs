using SkiaSharp;

namespace LapTimer.SkiaSharp.Presentation.Views.SessionMap
{
    public interface ISinglePointShape : IShape
    {
        SKPoint Point { get; }
    }
}