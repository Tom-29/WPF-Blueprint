using System.Windows;
using DefaultWPFBlueprint.Services;
using DefaultWPFBlueprint.ViewModels;

namespace DefaultWPFBlueprint.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        UserLabel.Content = App.LoggedInUser?.Username;
        NavigationService.Navigate = (type, parameter) =>
        {
            if (parameter == null)
            {
                MainContent.Content = Activator.CreateInstance(type);
            }
            else
            {
                MainContent.Content = Activator.CreateInstance(type, parameter);
            }
        };
        NavigationService.NavigateTo<Overview>();
    }

    private void NavigateToMainPage(object sender, RoutedEventArgs e)
    {
        NavigationService.NavigateTo<Overview>();
    }

    private void NavigateToProductPage(object sender, RoutedEventArgs e)
    {
        NavigationService.NavigateTo<CreateAndEdit>(new ItemFormViewModel(null, () => NavigationService.NavigateTo<Overview>()));
    }
}