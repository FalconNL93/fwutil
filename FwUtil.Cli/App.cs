using FwUtil.Cli.Classes;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli;

public class App
{
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<App> _logger;

    public App(FirewallCliService firewallCliService, ILogger<App> logger)
    {
        _firewallCliService = firewallCliService;
        _logger = logger;
    }

    public void Run(string[] args)
    {
        _logger.LogInformation("Firewall CLI Utility initialized");
        _firewallCliService.AddRule(TestRuleOne.Rule);
    }
}