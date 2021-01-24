using System;

namespace LapTimer.Core.Services
{
    public interface ICountdownService
    {
        event EventHandler Aborted;

        event EventHandler Completed;

        event EventHandler<TimerEventArgs> Ticked;

        void Extend(TimeSpan ExtendTime);

        void Start(TimeSpan CountdownTime);

        void Start(TimeSpan CountdownTime, TimeSpan RefreshIntervall);

        void Stop();
    }
}