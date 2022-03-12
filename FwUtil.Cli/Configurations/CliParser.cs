using CommandLine;
using CommandLine.Text;
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

    public static void ConfigureCliOptions<T>(this IServiceCollection services) where T : class
    {
        try
        {
            var parserResult = Configuration.ParseArguments<T>(Environment.GetCommandLineArgs())
                .WithParsed(delegate(T optionClass)
                {
                    services.AddSingleton(optionClass);
                });

            if (parserResult.Tag != ParserResultType.NotParsed) return;

            var builder = SentenceBuilder.Create();
            var errorMessages = HelpText.RenderParsingErrorsTextAsLines(parserResult, builder.FormatError,
                builder.FormatMutuallyExclusiveSetErrors, 1);

            Console.WriteLine(
                $"Error(s) during parsing command line options: {string.Join(Environment.NewLine, errorMessages)}");

            Console.WriteLine(
                $"Command Line: {Environment.NewLine}{string.Join(Environment.NewLine, Environment.GetCommandLineArgs())}");

            Environment.Exit(1);
        }
        catch (Exception e)
        {
            throw new Exception("Unable to parse command line.", e);
        }
    }
}