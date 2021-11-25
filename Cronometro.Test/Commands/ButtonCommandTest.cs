using Cronometro.Interfaces;
using Cronometro.ViewModels;
using Moq;
using Xunit;

namespace WpfAncert.Tests.Commands
{
    public class ButtonCommandTest
    {
        [Fact]
        public void ShouldExecuteStartButton()
        {
            //arrange
            Mock<ITimerReceiver> _mockTimerReceiver = new Mock<ITimerReceiver>();
            Mock<ICronometroViewModel> MockViewModel = new Mock<ICronometroViewModel>();
            CronometroViewModel ViewModel = new CronometroViewModel(_mockTimerReceiver.Object);
            //act
            ViewModel.StartButton(null);
            //assert
            _mockTimerReceiver.Verify(c => c.StartCrono());
        }
        [Fact]
        public void ShouldExecutePauseButton()
        {
            //arrange
            Mock<ITimerReceiver> _mockTimerReceiver = new Mock<ITimerReceiver>();
            Mock<ICronometroViewModel> MockViewModel = new Mock<ICronometroViewModel>();
            CronometroViewModel ViewModel = new CronometroViewModel(_mockTimerReceiver.Object);
            //act
            ViewModel.PauseButton(null);
            //assert
            _mockTimerReceiver.Verify(c => c.PauseCrono());
        }
        [Fact]
        public void ShouldExecuteResetButton()
        {
            //arrange
            Mock<ITimerReceiver> _mockTimerReceiver = new Mock<ITimerReceiver>();
            Mock<ICronometroViewModel> MockViewModel = new Mock<ICronometroViewModel>();
            CronometroViewModel ViewModel = new CronometroViewModel(_mockTimerReceiver.Object);
            //act
            ViewModel.ResetButton(null);
            //assert
            _mockTimerReceiver.Verify(c => c.ResetCrono());
        }
        [Fact]
        public void ShouldExecuteSalirButton()
        {
            //arrange
            Mock<ITimerReceiver> _mockTimerReceiver = new Mock<ITimerReceiver>();
            Mock<ICronometroViewModel> MockViewModel = new Mock<ICronometroViewModel>();
            CronometroViewModel ViewModel = new CronometroViewModel(_mockTimerReceiver.Object);
            //act
            ViewModel.SalirButton(null);
            //assert
            _mockTimerReceiver.Verify(c => c.Salir());
        }
    }
}
