using FwUtil.Core.Models;
using FwUtil.Core.Services;

namespace FwUtil.Cli.Commands;

public class ShowRulesCommand : ICommand
{
    public void Execute(FirewallService firewallService)
    {
        Console.WriteLine(Heading());
        Console.WriteLine(Line());
        foreach (var rule in firewallService.Rules())
        {
            Console.WriteLine(RuleRow(rule));
        }
        Console.WriteLine(Line());
        Console.WriteLine(Heading());
    }

    private string RuleRow(FirewallRule rule)
    {
        return $"{rule.Enabled,-10} - {rule.DisplayName,-20}";
    }

    private string Heading()
    {
        return $"{"Enabled",-10}   {"Name",-10}";
    }
    
    private string Line()
    {
        return "==================================";
    }
}