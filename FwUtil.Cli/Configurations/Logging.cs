using Serilog;

namespace FwUtil.Cli.Configurations;

public static class Logging
{
    public static void Configure()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
    }
}