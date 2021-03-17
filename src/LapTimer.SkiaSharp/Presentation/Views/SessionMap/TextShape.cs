using SkiaSharp;
using System;

namespace LapTimer.SkiaSharp.Presentation.Views.SessionMap
{
    public class TextShape : ASinglePointShape
    {
        private readonly string _textDistance;

        private double _opacity = 1;

        public TextShape(string textDistance, TimeSpan time)
        {
            _textDistance = textDistance;

            Time = time;
        }

        public override void Draw(SKCanvas canvas, SKPaint paint)
        {
            paint.Color = paint.Color.WithAlpha((byte)(_opacity * 255));
            canvas.DrawText(_textDistance, Point.X, Point.Y, paint);
        }

        public override void UpdateOpacity(double opacity)
        {
            _opacity = opacity;
        }

        public void UpdatePosition(SKPoint point)
        {
            Point = point;
        }

        protected override SKRect ComputeBoundBox()
        {
            throw new NotImplementedException();
        }
    }
}