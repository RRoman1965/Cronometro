using Cronometro.Interfaces;

namespace Cronometro.Core.Commands
{
    public class SalirCommand : IGenericCommand
    {
        private readonly ITimerReceiver _timerReceiver;

        public SalirCommand(ITimerReceiver timerReceiver)
        {
            _timerReceiver = timerReceiver;
        }

        public void Execute()
        {
            _timerReceiver.Salir();
        }
    }
}
