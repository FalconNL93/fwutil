using FwUtil.Cli.Classes;
using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli;

public class App
{
    private readonly CliCommandService _cliCommandService;
    private readonly FirewallOptions _cliOptions;
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<App> _logger;

    public App(FirewallCliService firewallCliService,
        ILogger<App> logger,
        FirewallOptions cliOptions,
        CliCommandService cliCommandService)
    {
        _firewallCliService = firewallCliService;
        _logger = logger;
        _cliOptions = cliOptions;
        _cliCommandService = cliCommandService;
    }

    public void Run()
    {
        _logger.LogInformation("Firewall CLI Utility initialized");
        ProcessCliParameters();
    }

    private void ProcessCliParameters()
    {
        if (_cliOptions.ShowHelp)
        {
            _cliCommandService.HelpCommand.Execute();
        } else if (_cliOptions.ShowRules)
        {
            _cliCommandService.ShowRules.Execute(_firewallCliService);
        }
    }
}