using System.Windows;
using System.Windows.Controls;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.ViewModels;

namespace DefaultWPFBlueprint.Views;

public partial class Main : UserControl
{
    private readonly StorageViewModel _storageViewModel;

    public Main()
    {
        InitializeComponent();
        _storageViewModel = new StorageViewModel();
        DataContext = _storageViewModel;
    }
    
    private void AddEntity(object sender, RoutedEventArgs e)
    {
        _storageViewModel.Items.Add(new Item(){Name = "Item 1", Quantity = 3, Price = 3});
    }
}