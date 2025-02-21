using System.Windows;

namespace DefaultWPFBlueprint.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainContent.Content = new Main();
    }

    private void NavigateToMainPage(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new Main();
    }

    private void NavigateToProductPage(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new Create();
    }
}