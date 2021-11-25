using System;

namespace Cronometro.Interfaces
{
    public interface ICronometroViewModel : IDisposable
    {
        void StartButton(object obj);
        void PauseButton(object obj);
        void ResetButton(object obj);
        void SalirButton(object obj);
    }
}
