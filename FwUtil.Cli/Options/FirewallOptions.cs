using CommandLine;

namespace FwUtil.Cli.CliOptions;

public class FirewallOptions : ICliOptions
{
    [Option('t', "test", HelpText = "")]
    public bool Test { get; set; }
}