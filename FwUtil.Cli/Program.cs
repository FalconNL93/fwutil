using FwUtil.Cli.Configurations;
using FwUtil.Cli.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace FwUtil.Cli;

public static class Program
{
    public static void Main()
    {
        App? app = null;
        var services = new ServiceCollection();
        ConfigureServices(services);

        try
        {
            var serviceProvider = services.BuildServiceProvider();
            app = serviceProvider.GetService<App>();
        }
        catch (Exception e)
        {
            Console.WriteLine("FWUtil could not be loaded:\n{0}", e.Message);
            Environment.Exit(1);
        }

        if (app == null) throw new Exception("Could not resolve app");

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        Logging.Configure();
        services.AddLogging(builder =>
        {
            builder.AddSerilog(dispose: true);
        });

        try
        {
            services.ConfigureCommands();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        services.AddSingleton<FirewallCliService>();
        services.AddTransient<App>();
    }
}