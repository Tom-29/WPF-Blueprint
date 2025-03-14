using System.Windows;
using System.Windows.Controls;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.Services;
using DefaultWPFBlueprint.Views.Windows;

namespace DefaultWPFBlueprint.Views.UserHandle;

public partial class Login : UserControl
{
    private readonly LoginWindow _parent;

    public Login(LoginWindow parent)
    {
        InitializeComponent();
        _parent = parent;
    }

    private void LoginUser(object sender, RoutedEventArgs e)
    {
        string username = TxtUsername.Text;
        string password = TxtPassword.Password;

        User? user = AuthService.AuthenticateUser(username, password);
        if (user != null)
        {
            App.LoggedInUser = user;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            _parent.Close();
        }
        else
        {
            MessageBox.Show("Falsche Anmeldedaten.");
        }
    }

    private void OpenRegister(object sender, RoutedEventArgs e)
    {
        _parent.ShowRegister();
    }
}