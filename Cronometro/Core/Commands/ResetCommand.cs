using Cronometro.Interfaces;

namespace Cronometro.Core.Commands
{
    public class ResetCommand : IGenericCommand
    {
        private readonly ITimerReceiver _timerReceiver;

        public ResetCommand(ITimerReceiver timerReceiver)
        {
            _timerReceiver = timerReceiver;
        }

        public void Execute()
        {
            _timerReceiver.ResetCrono();
        }
    }
}
