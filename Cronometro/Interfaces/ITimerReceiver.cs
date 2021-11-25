using System;

namespace Cronometro.Interfaces
{
    public interface ITimerReceiver : IDisposable
    {
        event Action RemainingSecondsChanged;
        void StartCrono();
        void PauseCrono();
        void ResetCrono();
        void Salir();
        TimeSpan GetTimeElapsed();
    }
}
