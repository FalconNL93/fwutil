using CommandLine;

namespace FwUtil.Cli.Helpers;

public static class CliParserHelper
{
    private static readonly Dictionary<Type, string> TranslationList = new()
    {
        {typeof(NoVerbSelectedError), "Missing parameter"}
    };

    public static int HandleCliErrors(IEnumerable<Error> errors)
    {
        Console.WriteLine("Error: Could not load FW Utility Cli");
        errors.ToList().ForEach(error =>
        {
            Console.WriteLine(TranslationList.ContainsKey(error.GetType())
                ? TranslationList.FirstOrDefault(x => x.Key == error.GetType()).Value
                : error.ToString());
        });

        Environment.Exit(1);
        return 1;
    }
}