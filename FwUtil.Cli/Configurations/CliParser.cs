using CommandLine;
using FwUtil.Cli.Options;
using FwUtil.Cli.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FwUtil.Cli.Configurations;

public static class CliParser
{
    private static readonly Parser Configuration =
        new(parser =>
        {
            parser.CaseSensitive = false;
            parser.HelpWriter = TextWriter.Null;
            parser.IgnoreUnknownArguments = false;
        });

    public static void ConfigureVerb(this IServiceCollection serviceCollection)
    {
        var args = Environment.GetCommandLineArgs().Skip(1);
        try
        {
            Parser.Default.ParseArguments<RuleOptions, GlobalOptions>(args)
                .MapResult(
                    (GlobalOptions options) => serviceCollection.RegisterGlobal(options),
                    errs => 1);
        }
        catch (Exception e)
        {
            throw new Exception("Unable to parse command line.", e);
        }
    }

    private static int RegisterGlobal(this IServiceCollection serviceCollection, GlobalOptions options)
    {
        serviceCollection.AddSingleton(options);
        serviceCollection.AddSingleton<ICommandService, GlobalService>();

        return 0;
    }
}