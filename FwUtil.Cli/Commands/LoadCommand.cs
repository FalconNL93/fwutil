using FwUtil.Cli.Helpers;
using FwUtil.Cli.Models;
using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using FwUtil.Core.Models;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Commands;

public class LoadCommand : ICommand
{
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<LoadCommand> _logger;
    private readonly LoadOptions _options;
    private FirewallModel _firewallModel = new();
    private List<FirewallRule> _firewallRules = new();

    public LoadCommand(ILogger<LoadCommand> logger, LoadOptions options, FirewallCliService firewallCliService)
    {
        _options = options;
        _firewallCliService = firewallCliService;
        _logger = logger;
    }

    public void Handle()
    {
        Load();

        if (_options.Apply)
        {
            _firewallRules.ForEach(rule =>
            {
                var addRuleResult = _firewallCliService.AddRule(rule);

                if (!addRuleResult)
                {
                    return;
                }

                _logger.LogInformation("Rule created: [{Direction}] {DisplayName} - {Protocol} {Ports}",
                    rule.Direction, rule.DisplayName, rule.Protocol, rule.LocalPorts);
            });
        }
    }

    private void Load()
    {
        try
        {
            _firewallModel = FirewallHelper.FromFile(_options.File);
            _firewallRules = _firewallModel.Rules.ToList();

            _logger.LogInformation("Firewall state read from {File} with {Rules} rules", _options.File,
                _firewallModel.Rules.Count);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unable to read firewall state from {File}: {Error}", _options.File, e.Message);
        }
    }
}