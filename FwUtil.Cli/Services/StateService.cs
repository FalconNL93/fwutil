﻿using FwUtil.Cli.Options;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Services;

public class StateService : ICommandService
{
    private readonly StateOptions _options;
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<App> _logger;

    public StateService(ILogger<App> logger, StateOptions stateOptions, FirewallCliService firewallCliService)
    {
        _options = stateOptions;
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