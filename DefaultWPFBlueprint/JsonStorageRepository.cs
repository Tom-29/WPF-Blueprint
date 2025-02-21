using System.IO;
using System.Text.Json;
using DefaultWPFBlueprint.Models;

namespace DefaultWPFBlueprint;

public static class JsonStorageRepository
{
    private const string FilePath = "data.json";

    public static async Task<JsonDataTemplate> LoadItemsAsync()
    {
        if (File.Exists(FilePath))
        {
            await using var stream = File.OpenRead(FilePath);
            return await JsonSerializer.DeserializeAsync<JsonDataTemplate>(stream) ?? new JsonDataTemplate();
        }

        return new JsonDataTemplate();
    }

    public static async Task SaveItemsAsync(JsonDataTemplate data)
    {
        await using var stream = File.Create(FilePath);
        await JsonSerializer.SerializeAsync(stream, data, new JsonSerializerOptions { WriteIndented = true });
    }

    public static JsonDataTemplate LoadItems()
    {
        if (File.Exists(FilePath))
        {
            using var stream = File.OpenRead(FilePath);
            return JsonSerializer.Deserialize<JsonDataTemplate>(stream) ?? new JsonDataTemplate();
        }

        return new JsonDataTemplate()
        {
            Items = [new Item()
            {
                Name = "test",
                Price = 2.45,
                Quantity = 1
            }]
        };
    }

    public static void SaveItems(JsonDataTemplate data)
    {
        using var stream = File.Create(FilePath);
        JsonSerializer.Serialize(stream, data, new JsonSerializerOptions { WriteIndented = true });
    }
}