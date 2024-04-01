using System.Windows.Threading;

namespace WpfApp1.Logic
{
    internal static class HelperFunctions
    {
        public static void ForceUiUpdate(Dispatcher dispatcher)
        {
            DispatcherFrame frame = new();
            dispatcher.BeginInvoke(DispatcherPriority.Render, new DispatcherOperationCallback(delegate
            {
                frame.Continue = false;
                return null;
            }), null);

            dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }
    }
}
