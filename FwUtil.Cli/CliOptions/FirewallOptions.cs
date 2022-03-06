using CommandLine;

namespace FwUtil.Cli.CliOptions;

public class FirewallOptions
{
    [Option('b', "block", Required = true, HelpText = "")]
    public string Command { get; set; }
}