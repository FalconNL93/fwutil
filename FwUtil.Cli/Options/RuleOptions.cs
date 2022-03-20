using CommandLine;

namespace FwUtil.Cli.Options;

[Verb("rule", HelpText = "Rule management")]
public class RuleOptions
{
    private string _action;
    private string _direction;
    private string _protocol;


    [Option('l', "list", HelpText = "Show list of firewall rules")]
    public bool ShowAll { get; set; }

    [Value(0, MetaName = "action", HelpText = "Block, Accept or Reject")]
    public string Action
    {
        get => _action;
        set => _action = value.ToLower();
    }

    [Option('p', "port", HelpText = "Port number")]
    public string Port { get; set; }

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