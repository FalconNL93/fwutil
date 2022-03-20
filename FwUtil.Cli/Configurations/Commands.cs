using CommandLine;
using FwUtil.Cli.Commands;
using FwUtil.Cli.Options;
using Microsoft.Extensions.DependencyInjection;

namespace FwUtil.Cli.Configurations;

public static class Commands
{
    private static readonly Parser Configuration =
        new(parser =>
        {
            parser.CaseSensitive = false;
            parser.HelpWriter = TextWriter.Null;
            parser.IgnoreUnknownArguments = false;
        });

    public static void ConfigureCommands(this IServiceCollection serviceCollection)
    {
        var args = Environment.GetCommandLineArgs().Skip(1);
        try
        {
            Configuration.ParseArguments<RuleOptions, StateOptions>(args)
                .MapResult(
                    (StateOptions options) => serviceCollection.RegisterStateCommand(options),
                    (RuleOptions options) => serviceCollection.RegisterRuleCommand(options),
                    _ => 1);
        }
        catch (Exception e)
        {
            throw new Exception("Unable to parse command line.", e);
        }
    }

    private static int RegisterStateCommand(this IServiceCollection serviceCollection, StateOptions options)
    {
        serviceCollection.AddSingleton(options);
        serviceCollection.AddSingleton<ICommand, StateCommand>();

        return 0;
    }

    private static int RegisterRuleCommand(this IServiceCollection serviceCollection, RuleOptions options)
    {
        serviceCollection.AddSingleton(options);
        serviceCollection.AddSingleton<ICommand, RuleCommand>();

        return 0;
    }
}