using System;

namespace LapTimer.Core.Services
{
    public class TimerEventArgs : EventArgs
    {
        public TimeSpan TimeRemaining { get; set; }
    }
}