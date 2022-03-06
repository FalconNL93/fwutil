using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace FwUtil.Cli;

public static class Program
{
    public static void Main(string[] args)
    {
        App? app = null;
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        try
        {
            app = serviceProvider.GetService<App>();
        }
        catch (Exception e)
        {
            Console.WriteLine("Unable to start FWUtil due to an error:\n{0}", e.Message);
            Environment.Exit(1);
        }

        if (app == null) throw new Exception("Could not resolve app");

        app.Run(args);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        ConfigureLogging();
        services.AddLogging(builder => { builder.AddSerilog(dispose: true); });


        services.AddSingleton<FirewallCliService>();
        services.AddTransient<App>();
    }

    private static void ConfigureLogging()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
    }
}