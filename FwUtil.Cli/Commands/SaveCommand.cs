using FwUtil.Cli.Extensions;
using FwUtil.Cli.Helpers;
using FwUtil.Cli.Models;
using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Commands;

public class SaveCommand : ICommand
{
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<SaveCommand> _logger;
    private readonly SaveOptions _options;

    public SaveCommand(ILogger<SaveCommand> logger, SaveOptions options, FirewallCliService firewallCliService)
    {
        _options = options;
        _firewallCliService = firewallCliService;
        _logger = logger;
    }

    public void Handle()
    {
        Save();
    }

    private void Save()
    {
        var firewallModel = new FirewallModel
        {
            Name = _options.Name,
            Date = DateTime.Now,
            Rules = _firewallCliService.Rules()
        };

        try
        {
            FirewallHelper.ToFile(firewallModel, _options.File);

            _logger.LogInformation("Firewall state written to {File} with {Rules} rules", _options.File,
                firewallModel.Rules.Count);

            _logger.LogFirewallRulesCount(firewallModel.Rules);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unable to write firewall state to {File}: {Error}", _options.File, e.Message);
        }
    }
}