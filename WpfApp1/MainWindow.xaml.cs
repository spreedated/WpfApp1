using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace TransparentClockApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer? timer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeClock();
            SetAlwaysOnTop();
        }

        private void InitializeClock()
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            clockLabelLayer1.Content = currentTime.ToString("HH:mm:ss");
            clockLabelLayer2.Content = currentTime.ToString("HH:mm:ss");
        }

        private void SetAlwaysOnTop()
        {
            Topmost = true;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
