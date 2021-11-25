using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using Cronometro.Interfaces;

namespace Cronometro.Receiver
{
    public class TimerReceiver : ITimerReceiver
    {
        private readonly DispatcherTimer _dispatcherTimer;
        private readonly Stopwatch _stopwatch;

        public event Action RemainingSecondsChanged;
        public TimerReceiver()
        {
            _dispatcherTimer = new DispatcherTimer();
            _stopwatch = new Stopwatch();

            DefineEventAndInterval();
        }

        public void StartCrono()
        {
            _stopwatch.Start();
            _dispatcherTimer.Start();

            OnRemainingSecondsChanged();
        }
        public void PauseCrono()
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
                OnRemainingSecondsChanged();
            }
        }
        public void ResetCrono()
        {
            _stopwatch.Reset();
            OnRemainingSecondsChanged();
        }
        public void Salir()
        {
            Application.Current.Shutdown();
        }
        public TimeSpan GetTimeElapsed()
        {
            return _stopwatch.Elapsed;
        }
        public void Dispose()
        {
            _dispatcherTimer.Tick -= new EventHandler(dt_Tick);
        }

        private void DefineEventAndInterval()
        {
            _dispatcherTimer.Tick += new EventHandler(dt_Tick);
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
        }
        private void dt_Tick(object sender, EventArgs e)
        {
            if (_stopwatch.IsRunning)
            {
                OnRemainingSecondsChanged();
            }
        }
        private void OnRemainingSecondsChanged()
        {
            RemainingSecondsChanged?.Invoke();
        }        
    }
}
