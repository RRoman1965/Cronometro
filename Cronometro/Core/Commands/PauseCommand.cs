using Cronometro.Interfaces;

namespace Cronometro.Core.Commands
{
    public class PauseCommand : IGenericCommand
    {
        private readonly ITimerReceiver _timerReceiver;

        public PauseCommand(ITimerReceiver timerReceiver)
        {
            _timerReceiver = timerReceiver;
        }

        public void Execute()
        {
            _timerReceiver.PauseCrono();
        }
    }
}
