using System;
using System.Collections.Generic;
using System.Text;

namespace LapTimer.Forms.UI.Models
{
    public struct ValueBounds
    {
        public double Max { get; }

        public double Min { get; }

        public ValueBounds(double min, double max)
        {
            Min = min;
            Max = max;
        }
    }
}