using FwUtil.Cli.Classes;
using FwUtil.Cli.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FwUtil.Cli.Configurations;

public static class CommandConfiguration
{
    public static void ConfigureCommands(this IServiceCollection services)
    {
        services.AddSingleton<CliCommandService>();
    }
}