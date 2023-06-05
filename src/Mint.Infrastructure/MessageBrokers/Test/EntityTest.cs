#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Mint.Infrastructure.MessageBrokers.Test;

public class AuditLogEntryTest : EntityTest<Guid>, IAggregateRoot
{
    public Guid UserId { get; set; }

    public string Action { get; set; }

    public string ObjectId { get; set; }

    public string Log { get; set; }
}

public class EntityTest<TKey> : IHasKey<TKey>, ITrackable
{
    public TKey Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }

    public DateTimeOffset CreatedDateTime { get; set; }

    public DateTimeOffset? UpdateDateTime { get; set; }
}

public interface IHasKey<T>
{
    T Id { get; set; }
}

public interface ITrackable
{
    byte[] RowVersion { get; set; }

    DateTimeOffset CreatedDateTime { get; set; }

    DateTimeOffset? UpdateDateTime { get; set; }
}

public interface IAggregateRoot
{

}
