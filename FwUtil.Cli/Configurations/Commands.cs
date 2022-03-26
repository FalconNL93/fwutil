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
            Configuration.ParseArguments<RuleOptions, StateOptions, LoadOptions, SaveOptions>(args)
                .MapResult(
                    (StateOptions options) => serviceCollection.RegisterStateCommand(options),
                    (RuleOptions options) => serviceCollection.RegisterRuleCommand(options),
                    (LoadOptions options) => serviceCollection.RegisterLoadCommand(options),
                    (SaveOptions options) => serviceCollection.RegisterSaveCommand(options),
                    _ =>
                    {
                        foreach (var error in _) Console.WriteLine(error);

                        return 0;
                    });
        }
        catch (Exception e)
        {
            throw new Exception("Unable to parse command line.", e);
        }
    }
}