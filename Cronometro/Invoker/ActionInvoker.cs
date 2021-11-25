using Cronometro.Core;
using Cronometro.Interfaces;

namespace Cronometro.Invoker
{
    public class ActionInvoker : IActionInvoker
    {
        private readonly IGenericCommand _command;
        public ActionInvoker(IGenericCommand command)
        {
            _command = command;
        }
        
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
