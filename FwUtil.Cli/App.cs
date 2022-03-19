using FwUtil.Cli.Services;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli;

public class App
{
    private readonly ICommandService _commandService;
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<App> _logger;

    public App(FirewallCliService firewallCliService,
        ILogger<App> logger,
        ICommandService commandService)
    {
        _firewallCliService = firewallCliService;
        _logger = logger;
        _commandService = commandService;
    }

    public void Run()
    {
        _logger.LogInformation("Firewall CLI Utility initialized");
        _commandService.Handle();
    }
}