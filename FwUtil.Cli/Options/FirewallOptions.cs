using CommandLine;

namespace FwUtil.Cli.Options;

public class FirewallOptions : IOptions
{
    [Option('h', "help", HelpText = "Show list of available commands")]
    public bool ShowHelp { get; set; }
    
    [Option('s', "show", HelpText = "Show list of firewall rules")]
    public bool ShowRules { get; set; }
}