using System;

namespace LapTimer.Forms.UI.Services
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