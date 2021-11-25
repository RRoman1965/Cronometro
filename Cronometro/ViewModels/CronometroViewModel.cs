using System;
using System.Windows.Input;
using Cronometro.Core;
using Cronometro.Core.Commands;
using Cronometro.Interfaces;
using Cronometro.Invoker;
using Cronometro.Models;

namespace Cronometro.ViewModels
{
    public class CronometroViewModel : ViewModelBase, ICronometroViewModel
    {
        public Crono Cronometro { get; private set; } = new Crono();
        public ICommand StartButtonCommand { get; private set; }
        public ICommand ResetButtonCommand { get; private set; }
        public ICommand PauseButtonCommand { get; private set; }
        public ICommand SalirButtonCommand { get; private set; }

        private readonly ITimerReceiver _timerReceiver;        
        private ActionInvoker _invoker;
        
        public CronometroViewModel(ITimerReceiver timerReceiver)
        {
            _timerReceiver = timerReceiver;
            _timerReceiver.RemainingSecondsChanged += TimerReceiver_RemainingSecondsChanged;

            DefineButtons();
            TimerReceiver_RemainingSecondsChanged();
        }
        public virtual void StartButton(object obj)
        {
            IGenericCommand command = new StartCommand(_timerReceiver);
            _invoker = new ActionInvoker(command);
            _invoker.ExecuteCommand();
        }
        public void PauseButton(object obj)
        {
            IGenericCommand command = new PauseCommand(_timerReceiver);
            _invoker = new ActionInvoker(command);
            _invoker.ExecuteCommand();
        }
        public void ResetButton(object obj)
        {
            IGenericCommand command = new ResetCommand(_timerReceiver);
            _invoker = new ActionInvoker(command);
            _invoker.ExecuteCommand();
        }
        public void SalirButton(object obj)
        {
            IGenericCommand command = new SalirCommand(_timerReceiver);
            _invoker = new ActionInvoker(command);
            _invoker.ExecuteCommand();
        }
        private void DefineButtons()
        {
            StartButtonCommand = new RelayCommand(StartButton);
            ResetButtonCommand = new RelayCommand(ResetButton);
            PauseButtonCommand = new RelayCommand(PauseButton);
            SalirButtonCommand = new RelayCommand(SalirButton);
        }

        private void TimerReceiver_RemainingSecondsChanged()
        {
            TimeSpan ts = _timerReceiver.GetTimeElapsed();
            Cronometro.Tiempo = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}:{ts.Milliseconds / 10:00}";
            RaisePropertyChanged("Cronometro");
        }
        public void Dispose()
        {
            _timerReceiver.RemainingSecondsChanged -= TimerReceiver_RemainingSecondsChanged;
        }
    }
}
