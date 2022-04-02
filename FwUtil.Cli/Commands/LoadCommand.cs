using FwUtil.Cli.Extensions;
using FwUtil.Cli.Helpers;
using FwUtil.Cli.Models;
using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using FwUtil.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Commands;

public class LoadCommand : ICommand
{
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<LoadCommand> _logger;
    private readonly LoadOptions _options;
    private FirewallModel _firewallModel = new();
    private List<FirewallRule> _firewallRules = null;

    public LoadCommand(ILogger<LoadCommand> logger, LoadOptions options, FirewallCliService firewallCliService)
    {
        _options = options;
        _firewallCliService = firewallCliService;
        _logger = logger;
    }

    public void Handle()
    {
        ReadJson();
    }

    private void ReadJson()
    {
        try
        {
            _firewallModel = FirewallHelper.FromFile(_options.File);
            _firewallRules = _firewallModel.Rules.Where(x => x.Protocol == FirewallRule.Protocols.Tcp).ToList();

            _logger.LogInformation("Firewall state read from {File} with {Rules} rules", _options.File,
                _firewallModel.Rules.Count);
            
            _logger.LogFirewallRulesCount(_firewallRules);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unable to read firewall state from {File}: {Error}", _options.File, e.Message);
        }
    }
}

public static class LoadServiceCollection
{
    public static int RegisterLoadCommand(this IServiceCollection serviceCollection, LoadOptions options)
    {
        serviceCollection.AddSingleton(options);
        serviceCollection.AddSingleton<ICommand, LoadCommand>();

        return 0;
    }
}