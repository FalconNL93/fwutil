using System.Text.Json;
using FwUtil.Cli.Models;

namespace FwUtil.Cli.Helpers;

public static class JsonHelper
{
    public static JsonModel FromFile(string file)
    {
        if (!File.Exists(file)) throw new Exception("Requested JSON file does not exist");

        return JsonSerializer.Deserialize<JsonModel>(File.ReadAllText(file)) ?? new JsonModel();
    }

    public static void ToFile(JsonModel jsonModel, string file)
    {
        File.WriteAllText(file, JsonSerializer.Serialize(jsonModel));
    }
}