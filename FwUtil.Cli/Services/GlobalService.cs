using FwUtil.Cli.Options;
using Microsoft.Extensions.Logging;

namespace FwUtil.Cli.Services;

public class GlobalService : ICommandService
{
    private readonly GlobalOptions _options;
    private readonly ILogger<App> _logger;

    public GlobalService(ILogger<App> logger, GlobalOptions globalOptions)
    {
        _options = globalOptions;
        _logger = logger;
    }

    public void Handle()
    {
    }
}