using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Commands;

public class StateCommand : ICommand
{
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<StateCommand> _logger;
    private readonly StateOptions _options;

    public StateCommand(ILogger<StateCommand> logger, StateOptions options, FirewallCliService firewallCliService)
    {
        _options = options;
        _firewallCliService = firewallCliService;
        _logger = logger;
    }

    public void Handle()
    {
        if (_options.Enable)
        {
            EnableFirewall();
        }
        else if (_options.Disable)
        {
            DisableFirewall();
        }
    }

    private void DisableFirewall()
    {
        try
        {
            _firewallCliService.DisableFirewall();
            _logger.LogInformation("Firewall has been {State}", "disabled");
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Error {State} firewall", "disabling");
            throw;
        }
    }

    private void EnableFirewall()
    {
        try
        {
            _firewallCliService.EnableFirewall();
            _logger.LogInformation("Firewall has been {State}", "enabled");
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Error {State} firewall", "enabling");
            throw;
        }
    }
}