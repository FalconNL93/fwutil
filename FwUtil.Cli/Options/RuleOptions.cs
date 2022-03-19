using CommandLine;

namespace FwUtil.Cli.Options;

[Verb("rules", HelpText = "Rule management")]
public class RuleOptions
{
    [Option('a', "all", HelpText = "Show list of firewall rules")]
    public bool ShowAll { get; set; }
}