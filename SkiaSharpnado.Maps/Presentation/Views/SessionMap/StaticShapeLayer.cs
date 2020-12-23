using SkiaSharp;
using System;

namespace SkiaSharpnado.Maps.Presentation.Views.SessionMap
{
    public class StaticShapeLayer<TShape> : AShape
        where TShape : IShape
    {
        private int _currentIndex = 0;

        public bool HasShape => Layer[_currentIndex] != null;

        protected IShape[] Layer { get; }

        protected TimeSpan MaxTime { get; private set; }

        public StaticShapeLayer(int shapeCount)
        {
            Layer = new IShape[shapeCount];
        }

        public void Add(TShape shape)
        {
            Layer[_currentIndex] = shape;
        }

        public override void Draw(SKCanvas canvas, SKPaint paint)
        {
            for (int index = 0; index < Layer.Length; index++)
            {
                IShape shape = Layer[index];
                if (shape == null || shape.Time > MaxTime)
                {
                    return;
                }

                shape.Draw(canvas, paint);
            }
        }

        public TShape GetCurrentShape()
        {
            return (TShape)Layer[_currentIndex];
        }

        public void IncrementIndex()
        {
            _currentIndex++;
        }

        public void ResetIndex()
        {
            _currentIndex = 0;
        }

        public void UpdateMaxTime(TimeSpan time)
        {
            MaxTime = time;
        }

        public override void UpdateOpacity(double opacity) => throw new NotSupportedException();

        protected override SKRect ComputeBoundBox()
        {
            throw new NotImplementedException();
        }
    }
}