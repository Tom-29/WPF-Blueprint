using CommunityToolkit.Mvvm.ComponentModel;

namespace DefaultWPFBlueprint.Models;

public sealed partial class Item : ObservableObject
{
    [ObservableProperty] private string name;

    [ObservableProperty] private double price;

    [ObservableProperty] private long quantity;
}