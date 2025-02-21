using System.Windows;
using System.Windows.Threading;

namespace DefaultWPFBlueprint;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
    }

    private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(
            "An unexpected error occurred: " + e.Exception.Message,
            "Error",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
        e.Handled = true;
    }
}