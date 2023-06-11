namespace Mint.Gateaway.Common;

public class OcelotOptions
{
    public OcelotRoutesOptions Routes { get; set; } = new();
}

public class OcelotRoutesOptions : Dictionary<string, OcelotRouteOptions> { }

public class OcelotRouteOptions
{
    public List<string> UpstreamPathTemplates { get; set; } = new();

    public string Downstream { get; set; } = "";
}