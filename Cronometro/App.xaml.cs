using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Cronometro.Interfaces;
using Cronometro.Invoker;
using Cronometro.Receiver;
using Cronometro.Core;
using Cronometro.Core.Commands;
using Cronometro.ViewModels;

namespace Cronometro
{
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddScoped<IActionInvoker, ActionInvoker>();
                    services.AddScoped<ITimerReceiver, TimerReceiver>();
                    services.AddScoped<IGenericCommand, StartCommand>();
                    services.AddScoped<IGenericCommand, ResetCommand>();
                    services.AddScoped<IGenericCommand, PauseCommand>();
                    services.AddScoped<IGenericCommand, SalirCommand>();
                    services.AddScoped<ICronometroViewModel, CronometroViewModel>();

                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<ICronometroViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
