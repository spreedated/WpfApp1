using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace TransparentClockApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer? timer;
        private bool isDragging = false;
        private Point lastMousePosition;

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
                isDragging = true;
                lastMousePosition = e.GetPosition(this);
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePosition = e.GetPosition(this);
                double deltaX = currentMousePosition.X - lastMousePosition.X;
                double deltaY = currentMousePosition.Y - lastMousePosition.Y;
                Left = Left + deltaX;
                Top = Top + deltaY;
                lastMousePosition = currentMousePosition;
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = false;
            }
        }

        private void DragButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = true;
                lastMousePosition = e.GetPosition(this);
            }
        }

        private void DragButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentMousePosition = e.GetPosition(this);
                double deltaX = currentMousePosition.X - lastMousePosition.X;
                double deltaY = currentMousePosition.Y - lastMousePosition.Y;
                Left = Left + deltaX;
                Top = Top + deltaY;
                lastMousePosition = currentMousePosition;
            }
        }

        private void DragButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = false;
            }
        }
    }
}
