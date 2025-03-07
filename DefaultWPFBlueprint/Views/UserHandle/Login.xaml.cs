using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using DefaultWPFBlueprint.Persistence;
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

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        string username = TxtUsername.Text;
        string password = TxtPassword.Password;

        using var db = new AppDbContext();
        var user = db.Users.FirstOrDefault(u => u.Username == username);
        if (user != null && VerifyPassword(password, user.PasswordHash))
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

    private bool VerifyPassword(string password, string storedHash)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes) == storedHash;
    }
}