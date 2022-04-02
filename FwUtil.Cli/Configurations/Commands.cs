using CommandLine;
using FwUtil.Cli.Commands;
using FwUtil.Cli.Extensions;
using FwUtil.Cli.Helpers;
using FwUtil.Cli.Options;
using Microsoft.Extensions.DependencyInjection;

namespace FwUtil.Cli.Configurations;

public static class Commands
{
    private static readonly Parser CliConfiguration =
        new(parser =>
        {
            parser.CaseSensitive = false;
            parser.HelpWriter = TextWriter.Null;
            parser.IgnoreUnknownArguments = false;
            parser.EnableDashDash = true;
            parser.AutoHelp = false;
            parser.AutoVersion = false;
        });

    public static void ConfigureCommands(this IServiceCollection serviceCollection)
    {
        var args = Environment.GetCommandLineArgs().Skip(1);
        try
        {
            var loadCli =
                CliConfiguration.ParseArguments<LoadOptions, RuleOptions, SaveOptions, StateOptions, int>(args);
            loadCli.MapResult(
                (LoadOptions options) => serviceCollection.RegisterCommand<LoadOptions, LoadCommand>(options),
                (RuleOptions options) => serviceCollection.RegisterCommand<RuleOptions, RuleCommand>(options),
                (SaveOptions options) => serviceCollection.RegisterCommand<SaveOptions, SaveCommand>(options),
                (StateOptions options) => serviceCollection.RegisterCommand<StateOptions, StateCommand>(options),
                CliParserHelper.HandleCliErrors);
        }
        catch (Exception e)
        {
            throw new Exception("Unable to parse command line.", e);
        }
    }
}