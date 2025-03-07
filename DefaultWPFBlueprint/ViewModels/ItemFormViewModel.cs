using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DefaultWPFBlueprint.Models;
using DefaultWPFBlueprint.Persistence;

namespace DefaultWPFBlueprint.ViewModels;

public partial class ItemFormViewModel : ObservableObject
{
    [ObservableProperty] private Item _item;
    private readonly Action _onClose;

    public ItemFormViewModel(Item? item, Action onClose)
    {
        Item = item ?? new Item();
        _onClose = onClose;
    }

    [RelayCommand]
    private void Save()
    {
        using var db = new AppDbContext();

        if (Item.Id == 0)
        {
            db.Items.Add(Item);
        }
        else
        {
            db.Items.Update(Item);
        }

        db.SaveChanges();
        _onClose.Invoke();
    }

    [RelayCommand]
    private void Cancel()
    {
        _onClose.Invoke();
    }
}