using FwUtil.Core.Models;

namespace FwUtil.Cli.Helpers;

public static class ConsoleOutput
{
    public static string RuleOutput(FirewallRule rule)
    {
        return $"{rule.Enabled,-10} - {rule.DisplayName,-20}";
    }
}