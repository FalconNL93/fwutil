using CommandLine;

namespace FwUtil.Cli.Options;

[Verb("load", HelpText = "Load firewall rules from file")]
public class LoadOptions
{
    private string _direction;
    private string _protocol;

    [Option('f', "file", HelpText = "Filename", Default = "rules.json")]
    public string File { get; set; }

    [Option('d', "direction", HelpText = "(Out)bound or (In)bound")]
    public string Direction
    {
        get => _direction;
        set => _direction = value.ToLower();
    }

    [Option('c', "protocol", HelpText = "TCP/UDP/Any")]
    public string Protocol
    {
        get => _protocol;
        set => _protocol = value.ToLower();
    }

    [Option('a', "apply", Default = false, HelpText = "Apply loaded firewall rules")]
    public bool Apply { get; set; }
}