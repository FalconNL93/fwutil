using CommandLine;
using FwUtil.Cli.Commands;
using FwUtil.Cli.Extensions;
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
            Configuration.ParseArguments<LoadOptions, RuleOptions, SaveOptions, StateOptions, int>(args)
                .MapResult(
                    (LoadOptions options) => serviceCollection.RegisterCommand<LoadOptions, LoadCommand>(options),
                    (RuleOptions options) => serviceCollection.RegisterCommand<RuleOptions, RuleCommand>(options),
                    (SaveOptions options) => serviceCollection.RegisterCommand<SaveOptions, SaveCommand>(options),
                    (StateOptions options) => serviceCollection.RegisterCommand<StateOptions, StateCommand>(options),
                    HandleCliErrors);
        }
        catch (Exception e)
        {
            throw new Exception("Unable to parse command line.", e);
        }
    }

    private static int HandleCliErrors(IEnumerable<Error> errors)
    {
        var errorList = errors.ToList();

        var translationList = new Dictionary<Type, string>
        {
            {typeof(NoVerbSelectedError), "Missing verb"}
        };

        Console.WriteLine("Error: Could not load FW Utility Cli");
        errorList.ForEach(error =>
        {
            Console.WriteLine(translationList.ContainsKey(error.GetType())
                ? translationList.FirstOrDefault(x => x.Key == error.GetType()).Value
                : error.ToString());
        });

        Environment.Exit(1);
        return 1;
    }
}