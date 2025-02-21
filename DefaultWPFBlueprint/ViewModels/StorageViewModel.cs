using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Mvvm.ComponentModel;
using DefaultWPFBlueprint.Models;

namespace DefaultWPFBlueprint.ViewModels;

public sealed partial class StorageViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Item> _items;

    [ObservableProperty] private double _totalWorth;
    
    [ObservableProperty] private double _totalCount;

    public StorageViewModel()
    {
        Items = new ObservableCollection<Item>(JsonStorageRepository.LoadItems().Items);
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

    private void UpdateFile()
    {
        JsonDataTemplate template = JsonStorageRepository.LoadItems();
        template.Items = Items;
        JsonStorageRepository.SaveItems(template);
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
        UpdateFile();
    }

    private void OnItemPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(Item.Price) or nameof(Item.Quantity))
        {
            UpdatePriceAndCount();
        }
        
        UpdateFile();
    }
}