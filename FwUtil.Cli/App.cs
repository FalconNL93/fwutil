using FwUtil.Cli.Commands;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli;

public class App
{
    private readonly ICommand _command;
    private readonly ILogger<App> _logger;

    public App(ILogger<App> logger, ICommand command)
    {
        _logger = logger;
        _command = command;
    }

    public void Run()
    {
        _logger.LogInformation("Firewall CLI Utility initialized");
        _command.Handle();
    }
}