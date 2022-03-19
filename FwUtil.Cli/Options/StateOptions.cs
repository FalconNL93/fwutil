using CommandLine;

namespace FwUtil.Cli.Options;

[Verb("state", HelpText = "Manage firewall state")]
public class StateOptions : IOptions
{
    [Option('e', "enable", HelpText = "Enable firewall")]
    public bool Enable { get; set; }

    [Option('d', "disable", HelpText = "Disable firewall")]
    public bool Disable { get; set; }
}