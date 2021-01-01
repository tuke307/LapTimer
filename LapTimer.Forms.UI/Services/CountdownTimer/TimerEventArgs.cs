using System;
using System.Collections.Generic;
using System.Text;

namespace LapTimer.Forms.UI.Services
{
    public class TimerEventArgs : EventArgs
    {
        public TimeSpan TimeRemaining { get; set; }
    }
}