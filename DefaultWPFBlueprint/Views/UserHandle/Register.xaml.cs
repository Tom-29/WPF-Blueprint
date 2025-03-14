using System.Windows;
using System.Windows.Controls;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.Services;
using DefaultWPFBlueprint.Views.Windows;

namespace DefaultWPFBlueprint.Views.UserHandle;

public partial class Register : UserControl
{
    private readonly LoginWindow _parent;

    public Register(LoginWindow parent)
    {
        InitializeComponent();
        _parent = parent;
    }

    private void RegisterUser(object sender, RoutedEventArgs e)
    {
        string username = TxtUsername.Text;
        string password = TxtPassword.Password;

        User? user = AuthService.RegisterUser(username, password, out var errorMessage);

        if (user == null)
        {
            MessageBox.Show(errorMessage);
            return;
        }

        App.LoggedInUser = user;
        MessageBox.Show("Registrierung erfolgreich.");

        MainWindow mainWindow = new();
        mainWindow.Show();
        _parent.Close();
    }

    private void OpenLogin(object sender, RoutedEventArgs e)
    {
        _parent.ShowLogin();
    }
}