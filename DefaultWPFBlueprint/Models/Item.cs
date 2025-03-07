using CommunityToolkit.Mvvm.ComponentModel;

namespace DefaultWPFBlueprint.Models;

public sealed partial class Item : ObservableObject
{
    [ObservableProperty] private long _id;

    [ObservableProperty] private string _name;

    [ObservableProperty] private double _price;

    [ObservableProperty] private long _quantity;
}