using FwUtil.Core.Exceptions;
using FwUtil.Core.Models;
using FwUtil.Core.Services;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Classes;

public class FirewallCliService : FirewallService
{
    private readonly ILogger<App> _logger;

    public FirewallCliService(ILogger<App> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public new void AddRule(FirewallRule rule)
    {
        try
        {
            base.AddRule(rule);
        }
        catch (FirewallRuleAlreadyExists)
        {
            _logger.LogError("This firewall rule already exists");
        }
    }

    public new void RemoveRule(FirewallRule rule)
    {
        try
        {
            base.RemoveRule(rule);
        }
        catch (FirewallRuleAlreadyExists)
        {
            _logger.LogError("This firewall rule does not exists");
        }
    }
}