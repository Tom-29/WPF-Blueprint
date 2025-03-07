using System.Collections.ObjectModel;
using DefaultWPFBlueprint.Models;

namespace DefaultWPFBlueprint.Persistence;

public class JsonDataTemplate
{
    public Collection<Item> Items { get; set; } = new();
}