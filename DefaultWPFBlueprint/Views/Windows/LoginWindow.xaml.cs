using System.Windows;
using DefaultWPFBlueprint.Views.UserHandle;

namespace DefaultWPFBlueprint.Views.Windows;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        ShowLogin();
    }

    public void ShowLogin()
    {
        MainContent.Content = new Login(this);
    }

    public void ShowRegister()
    {
        MainContent.Content = new Register(this);
    }
}