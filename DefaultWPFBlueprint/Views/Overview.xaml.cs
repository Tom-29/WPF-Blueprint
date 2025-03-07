using System.Windows;
using System.Windows.Controls;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.Services;
using DefaultWPFBlueprint.ViewModels;

namespace DefaultWPFBlueprint.Views;

public partial class Overview : UserControl
{
    private readonly StorageViewModel _storageViewModel;

    public Overview()
    {
        InitializeComponent();
        _storageViewModel = new StorageViewModel();
        DataContext = _storageViewModel;
    }
}