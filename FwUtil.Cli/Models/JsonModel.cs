using FwUtil.Core.Models;

namespace FwUtil.Cli.Models;

public class JsonModel
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public List<FirewallRule> Rules { get; set; }
}