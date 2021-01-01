using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LapTimer.Forms.UI.Services
{
    public class CountdownTimer : ICountdownTimer
    {
        #region Private Variable

        private EventHandler _AbortedEvent;
        private EventHandler _CompletedEvent;
        private TimeSpan _Interval;
        private bool _Stopped = false;
        private EventHandler<TimerEventArgs> _TickedEvent;
        private TimeSpan _TimeRemaining;

        #endregion

        #region Ctor

        public CountdownTimer()
        {
        }

        #endregion

        #region ICountdownTimer

        event EventHandler ICountdownTimer.Aborted
        {
            add { _AbortedEvent += value; }
            remove { _AbortedEvent -= value; }
        }

        event EventHandler ICountdownTimer.Completed
        {
            add { _CompletedEvent += value; }
            remove { _CompletedEvent -= value; }
        }

        event EventHandler<TimerEventArgs> ICountdownTimer.Ticked
        {
            add { _TickedEvent += value; }
            remove { _TickedEvent -= value; }
        }

        public void Extend(TimeSpan ExtendTime)
        {
            _TimeRemaining = _TimeRemaining.Add(ExtendTime);
        }

        public void Start(TimeSpan CountdownTime, TimeSpan RefreshIntervall)
        {
            _TimeRemaining = CountdownTime;
            _Interval = RefreshIntervall;

            Start();
        }

        public void Start(TimeSpan CountdownTime)
        {
            _TimeRemaining = CountdownTime;
            _Stopped = false;

            Start();
        }

        public void Stop()
        {
            _Stopped = true;
        }

        private void Start()
        {
            _Stopped = false;

            Device.StartTimer(_Interval, () =>
            {
                if (this._Stopped)
                {
                    _AbortedEvent?.Invoke(this, EventArgs.Empty);
                    return false;
                }

                _TimeRemaining -= _Interval;
                _TickedEvent?.Invoke(this, new TimerEventArgs { TimeRemaining = _TimeRemaining });

                _Stopped = _TimeRemaining.Duration() == TimeSpan.Zero;

                if (_Stopped)
                    _CompletedEvent?.Invoke(this, EventArgs.Empty);

                return !_Stopped;
            });
        }

        #endregion
    }
}