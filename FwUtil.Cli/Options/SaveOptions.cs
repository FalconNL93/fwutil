using CommandLine;

namespace FwUtil.Cli.Options;

[Verb("save", HelpText = "Save firewall rules to file")]
public class SaveOptions
{
    [Option('n', "name", HelpText = "Name of dump", Default = "FirewallDump")]
    public string Name { get; set; }

    [Option('f', "file", HelpText = "Filename", Default = "rules.json")]
    public string File { get; set; }
}