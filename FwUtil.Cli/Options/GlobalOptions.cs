using CommandLine;

namespace FwUtil.Cli.Options;

[Verb("global", HelpText = "Rule management")]
public class GlobalOptions : IOptions
{
    [Option('b', "block", HelpText = "Block all outgoing connections")]
    public bool BlockAll { get; set; }
}