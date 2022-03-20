using Serilog;
using Serilog.Events;

namespace FwUtil.Cli.Configurations;

public static class Logging
{
    public static void Configure()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File($"{typeof(Program).Assembly.GetName().Name}.log", LogEventLevel.Fatal)
            .WriteTo.Console()
            .CreateLogger();
    }
}