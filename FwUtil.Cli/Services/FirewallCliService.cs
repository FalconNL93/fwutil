using FwUtil.Core.Exceptions;
using FwUtil.Core.Models;
using FwUtil.Core.Services;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Services;

public class FirewallCliService : FirewallService
{
    private readonly ILogger<FirewallCliService> _logger;

    public FirewallCliService(ILogger<FirewallCliService> logger)
    {
        _logger = logger;
    }

    public new bool AddRule(FirewallRule rule)
    {
        try
        {
            _logger.LogInformation("Rule created: [{Direction}] {DisplayName} - {Protocol} {Ports}",
                rule.Direction, rule.DisplayName, rule.Protocol, rule.LocalPorts);

            base.AddRule(rule);
            return true;
        }
        catch (FirewallRuleAlreadyExists)
        {
            _logger.LogError("Firewall rule {DisplayName} already exists", rule.DisplayName);
            return false;
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

    public bool DisableService()
    {
        try
        {
            return DisableFirewall();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Err");
        }

        return false;
    }

    public new bool EnableFirewall()
    {
        try
        {
            return base.EnableFirewall();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Err");
        }

        return false;
    }
}