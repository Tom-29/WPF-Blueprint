using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.Persistence;
using DefaultWPFBlueprint.Services;
using DefaultWPFBlueprint.Views;

namespace DefaultWPFBlueprint.ViewModels;

public sealed partial class StorageViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Item> _items;
    
    [ObservableProperty] private Item? _selectedItem;

    [ObservableProperty] private double _totalWorth;
    
    [ObservableProperty] private double _totalCount;

    public StorageViewModel()
    {
        using AppDbContext db = new AppDbContext();
        Items = new ObservableCollection<Item>(db.Items.ToList());
        Items.CollectionChanged += OnItemsCollectionChanged;

        UpdatePriceAndCount();

        foreach (Item item in Items)
        {
            item.PropertyChanged += OnItemPropertyChanged;
        }
    }

    private void UpdatePriceAndCount()
    {
        double totalWorth = 0;
        long totalCount = 0;

        foreach (Item item in Items)
        {
            totalWorth += item.Price * item.Quantity;
            totalCount += item.Quantity;
        }

        TotalWorth = totalWorth;
        TotalCount = totalCount;
    }

    [RelayCommand]
    private void DeleteItem()
    {
        if (SelectedItem != null)
        {
            MessageBoxResult result = MessageBox.Show("Möchten Sie dieses Item wirklich löschen?", "Löschen bestätigen", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using AppDbContext db = new();
                db.Items.Remove(SelectedItem);
                db.SaveChanges();

                Items.Remove(SelectedItem);
            }
        }
    }
    
    [RelayCommand]
    private void OpenEditForm()
    {
        if (SelectedItem != null)
        {
            NavigationService.NavigateTo<CreateAndEdit>(new ItemFormViewModel(SelectedItem, () => NavigationService.NavigateTo<Overview>()));
        }
    }

    private void OnItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Item newItem in e.NewItems)
            {
                newItem.PropertyChanged += OnItemPropertyChanged;
            }
        }

        if (e.OldItems != null)
        {
            foreach (Item oldItem in e.OldItems)
            {
                oldItem.PropertyChanged -= OnItemPropertyChanged;
            }
        }

        UpdatePriceAndCount();
    }

    private void OnItemPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(Item.Price) or nameof(Item.Quantity))
        {
            UpdatePriceAndCount();
        }
    }
}