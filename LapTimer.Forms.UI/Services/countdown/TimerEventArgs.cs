using System;

namespace LapTimer.Forms.UI.Services
{
    public class TimerEventArgs : EventArgs
    {
        public TimeSpan TimeRemaining { get; set; }
    }
}