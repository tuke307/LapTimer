using SkiaSharp;
using System;

namespace LapTimer.SkiaSharp.Presentation.Views.SessionMap
{
    public abstract class AShape : IShape
    {
        private SKRect _boundingBox = SKRect.Empty;

        public SKRect BoundingBox => _boundingBox == SKRect.Empty ? _boundingBox = ComputeBoundBox() : _boundingBox;

        public TimeSpan Time { get; protected set; }

        public abstract void Draw(SKCanvas canvas, SKPaint paint);

        public abstract void UpdateOpacity(double opacity);

        protected abstract SKRect ComputeBoundBox();
    }
}