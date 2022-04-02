using CommandLine;

namespace FwUtil.Cli.Helpers;

public static class CliParserHelper
{
    public static int HandleCliErrors(IEnumerable<Error> errors)
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