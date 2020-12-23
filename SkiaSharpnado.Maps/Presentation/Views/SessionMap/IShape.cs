using SkiaSharp;
using System;

namespace SkiaSharpnado.Maps.Presentation.Views.SessionMap
{
    public interface IShape
    {
        SKRect BoundingBox { get; }

        TimeSpan Time { get; }

        void Draw(SKCanvas canvas, SKPaint paint);

        void UpdateOpacity(double opacity);
    }
}