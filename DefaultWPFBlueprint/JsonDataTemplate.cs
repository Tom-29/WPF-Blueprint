using System.Collections.ObjectModel;
using DefaultWPFBlueprint.Models;

namespace DefaultWPFBlueprint;

public class JsonDataTemplate
{
    public Collection<Item> Items { get; set; } = new();
}