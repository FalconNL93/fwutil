using FwUtil.Cli.Helpers;
using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Commands;

public class LoadCommand : ICommand
{
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<App> _logger;
    private readonly LoadOptions _options;

    public LoadCommand(ILogger<App> logger, LoadOptions options, FirewallCliService firewallCliService)
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
            var jsonModel = JsonHelper.FromFile("rules.json");
            var rules = jsonModel.Rules.ToList();

            _logger.LogInformation("Firewall state fetched from file with {Rules} rules", rules.Count);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unable to read firewall state from file");
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