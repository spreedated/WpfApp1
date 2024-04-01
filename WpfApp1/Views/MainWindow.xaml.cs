using System.Windows;
using System.Windows.Input;
using WpfApp1.Logic;
using WpfApp1.ViewModels;

namespace TransparentClockApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly System.Timers.Timer? uiUpdateTimer;

        #region Constructor
        public MainWindow()
        {
            this.InitializeComponent();
            ((MainWindowViewModel)this.DataContext).Instance = this;

            this.uiUpdateTimer = new()
            {
                Interval = 50
            };
            this.uiUpdateTimer.Elapsed += (o, s) => HelperFunctions.ForceUiUpdate(this.Dispatcher);
            this.uiUpdateTimer.Start();
        }
        #endregion

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                base.DragMove();
            }
        }
    }
}
