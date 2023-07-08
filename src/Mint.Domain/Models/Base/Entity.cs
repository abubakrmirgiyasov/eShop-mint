#nullable disable

using Mint.Domain.Models.Base.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Base;

public class Entity<TKey> : IHasKey<TKey>, ITrackable
{
    [Key]
    public TKey Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    
    public DateTimeOffset CreatedDate { get; } = DateTimeOffset.Now;
    
    public DateTimeOffset? UpdateDateTime { get; set; }
}
