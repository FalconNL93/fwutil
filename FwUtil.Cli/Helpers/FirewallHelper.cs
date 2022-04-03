using System.Text.Json;
using FwUtil.Cli.Models;

namespace FwUtil.Cli.Helpers;

public static class FirewallHelper
{
    public static FirewallModel FromFile(string file)
    {
        if (!File.Exists(file)) throw new Exception("Requested JSON file does not exist");

        return JsonSerializer.Deserialize<FirewallModel>(File.ReadAllText(file)) ?? new FirewallModel();
    }

    public static void ToFile(FirewallModel firewallModel, string file)
    {
        File.WriteAllText(file, JsonSerializer.Serialize(firewallModel));
    }
}