using Cronometro.Interfaces;

namespace Cronometro.Core.Commands
{
    public class StartCommand : IGenericCommand
    {
        private readonly ITimerReceiver _timerReceiver;

        public StartCommand(ITimerReceiver timerReceiver)
        {
            _timerReceiver = timerReceiver;
        }

        public void Execute()
        {
            _timerReceiver.StartCrono();
        }
    }
}
