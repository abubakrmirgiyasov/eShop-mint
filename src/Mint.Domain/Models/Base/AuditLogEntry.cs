#nullable disable

using Mint.Domain.Models.Base.Interfaces;

namespace Mint.Domain.Models.Base;

public class AuditLogEntry : Entity<Guid>, IAggregateRoot
{
    public Guid UserId { get; set; }

    public string Action { get; set; }

    public string ObjectId { get; set; }

    public string Log { get; set; }
}
