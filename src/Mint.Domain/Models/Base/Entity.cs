#nullable disable

using Mint.Domain.Models.Base.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Base;

public class Entity<TKey> : IHasKey<TKey>, ITrackable
{
    public TKey Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    
    public DateTimeOffset CreatedDateTime { get; set; }
    
    public DateTimeOffset? UpdateDateTime { get; set; }
}
