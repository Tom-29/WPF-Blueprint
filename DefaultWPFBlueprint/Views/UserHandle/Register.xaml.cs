using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.Persistence;
using DefaultWPFBlueprint.Views.Windows;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DefaultWPFBlueprint.Views.UserHandle;

public partial class Register : UserControl
{
    private readonly LoginWindow _parent;

    public Register(LoginWindow parent)
    {
        InitializeComponent();
        _parent = parent;
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        string username = TxtUsername.Text;
        string password = TxtPassword.Password;

        using var db = new AppDbContext();
        if (db.Users.Any(u => u.Username == username))
        {
            MessageBox.Show("Benutzername existiert bereits.");
            return;
        }

        string hash = HashPassword(password);
        EntityEntry<User> user = db.Users.Add(new User { Username = username, PasswordHash = hash });
        db.SaveChanges();
        App.LoggedInUser = user.Entity;

        MessageBox.Show("Registrierung erfolgreich.");
        MainWindow mainWindow = new();
        mainWindow.Show();
        _parent.Close();
    }

    private void OpenLogin(object sender, RoutedEventArgs e)
    {
        _parent.ShowLogin();
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }
}