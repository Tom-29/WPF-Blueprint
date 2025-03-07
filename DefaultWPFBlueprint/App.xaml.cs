using System.Windows;
using System.Windows.Threading;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.Persistence;

namespace DefaultWPFBlueprint;

public partial class App : Application
{
    public static User? LoggedInUser { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        using AppDbContext db = new();
        db.Database.EnsureCreated();
        Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
    }

    private static void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(
            "An unexpected error occurred: " + e.Exception.Message,
            "Error",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
        e.Handled = true;
    }
}