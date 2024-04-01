using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace WpfApp1.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private readonly System.Timers.Timer timer;

        [ObservableProperty]
        private Window? instance;

        [ObservableProperty]
        private string currentTime = DateTime.Now.ToString("HH:mm:ss");

        #region Constructor
        public MainWindowViewModel()
        {
            this.timer = new()
            {
                Interval = 500
            };
            this.timer.Elapsed += (o, s) => this.CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            this.timer.Start();
        }
        #endregion

        [RelayCommand]
        private void MinimizeWindow()
        {
            if (this.Instance != null)
            {
                this.Instance.WindowState = WindowState.Minimized;
            }
        }

        [RelayCommand]
        private void CloseWindow()
        {
            this.Instance?.Close();
        }
    }
}
