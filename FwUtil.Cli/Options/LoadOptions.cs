using CommandLine;

namespace FwUtil.Cli.Options;

[Verb("load", HelpText = "Load firewall rules from file")]
public class LoadOptions
{
    private string _direction;
    private string _protocol;

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
}