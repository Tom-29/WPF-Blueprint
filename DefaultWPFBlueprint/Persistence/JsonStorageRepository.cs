using System.IO;
using System.Text.Json;

namespace DefaultWPFBlueprint.Persistence;

public static class JsonStorageRepository
{
    private const string FilePath = "data.json";

    public static async Task<JsonDataTemplate> LoadItemsAsync()
    {
        if (File.Exists(FilePath))
        {
            await using FileStream stream = File.OpenRead(FilePath);
            return await JsonSerializer.DeserializeAsync<JsonDataTemplate>(stream) ?? new JsonDataTemplate();
        }

        return new JsonDataTemplate();
    }

    public static async Task SaveItemsAsync(JsonDataTemplate data)
    {
        await using FileStream stream = File.Create(FilePath);
        await JsonSerializer.SerializeAsync(stream, data, new JsonSerializerOptions { WriteIndented = true });
    }

    public static JsonDataTemplate LoadItems()
    {
        if (File.Exists(FilePath))
        {
            using FileStream stream = File.OpenRead(FilePath);
            return JsonSerializer.Deserialize<JsonDataTemplate>(stream) ?? new JsonDataTemplate();
        }

        return new JsonDataTemplate();
    }

    public static void SaveItems(JsonDataTemplate data)
    {
        using FileStream stream = File.Create(FilePath);
        JsonSerializer.Serialize(stream, data, new JsonSerializerOptions { WriteIndented = true });
    }
}