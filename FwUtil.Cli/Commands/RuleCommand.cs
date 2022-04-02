using FwUtil.Cli.Helpers;
using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using FwUtil.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Commands;

public class RuleCommand : ICommand
{
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<RuleCommand> _logger;
    private readonly RuleOptions _options;

    public RuleCommand(ILogger<RuleCommand> logger, RuleOptions options, FirewallCliService firewallCliService)
    {
        _options = options;
        _firewallCliService = firewallCliService;
        _logger = logger;
    }

    public void Handle()
    {
        if (_options.ShowAll)
            HandleShowAll();
        else if (_options.Action != null) HandleAction();
    }

    private void HandleShowAll()
    {
        foreach (var rule in _firewallCliService.Rules()) Console.WriteLine(ConsoleOutput.RuleOutput(rule));
    }

    private void HandleAction()
    {
        var actionParam = _options.Action switch
        {
            "allow" => FirewallRule.Actions.Allow,
            "block" => FirewallRule.Actions.Block,
            _ => FirewallRule.Actions.Allow
        };

        var directionParam = _options.Direction switch
        {
            "in" => FirewallRule.Directions.Inbound,
            "inbound" => FirewallRule.Directions.Inbound,
            "out" => FirewallRule.Directions.Outbound,
            "outbound" => FirewallRule.Directions.Outbound,
            _ => FirewallRule.Directions.Inbound
        };

        var protocolParam = _options.Protocol switch
        {
            "tcp" => FirewallRule.Protocols.Tcp,
            "udp" => FirewallRule.Protocols.Udp,
            "any" => FirewallRule.Protocols.Any,
            _ => FirewallRule.Protocols.Any
        };


        _firewallCliService.AddRule(new FirewallRule
        {
            Enabled = false,
            Action = actionParam,
            Direction = directionParam,
            Protocol = protocolParam,
            InterfaceType = FirewallRule.InterfaceTypes.Public
        });
    }

    private string RuleRow(FirewallRule rule)
    {
        return $"{rule.Enabled,-10} - {rule.DisplayName,-20}";
    }
}

public static class RuleServiceCollection
{
    public static int RegisterRuleCommand(this IServiceCollection serviceCollection, RuleOptions options)
    {
        serviceCollection.AddSingleton(options);
        serviceCollection.AddSingleton<ICommand, RuleCommand>();

        return 0;
    }   
}