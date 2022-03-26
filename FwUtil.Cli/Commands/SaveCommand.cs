using FwUtil.Cli.Helpers;
using FwUtil.Cli.Models;
using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Commands;

public class SaveCommand : ICommand
{
    private readonly FirewallCliService _firewallCliService;
    private readonly ILogger<App> _logger;
    private readonly SaveOptions _options;

    public SaveCommand(ILogger<App> logger, SaveOptions options, FirewallCliService firewallCliService)
    {
        _options = options;
        _firewallCliService = firewallCliService;
        _logger = logger;
    }

    public void Handle()
    {
        WriteJson();
    }

    private void WriteJson()
    {
        var jsonModel = new JsonModel
        {
            Name = "Test Dump",
            Date = DateTime.Now,
            Rules = _firewallCliService.Rules().Take(125).ToList()
        };

        try
        {
            JsonHelper.ToFile(jsonModel, "rules.json");
            _logger.LogInformation("Firewall state written to file with {Rules} rules", jsonModel.Rules.Count);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unable to write firewall state to file");
        }
    }
}

public static class SaveServiceCollection
{
    public static int RegisterSaveCommand(this IServiceCollection serviceCollection, SaveOptions options)
    {
        serviceCollection.AddSingleton(options);
        serviceCollection.AddSingleton<ICommand, SaveCommand>();

        return 0;
    }   
}