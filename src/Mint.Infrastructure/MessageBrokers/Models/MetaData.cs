namespace Mint.Infrastructure.MessageBrokers.Models;

public class MetaData
{
    public Guid MessageId { get; set; }

    public string MessageVersion { get; set; } = null!;

    public string CorrelationId { get; set; } = null!;

    public DateTimeOffset? CreationDateTime { get; set; }

    public DateTimeOffset? EnqueuedDateTime { get; set; }

    public string AccessToken { get; set; } = null!;
}
