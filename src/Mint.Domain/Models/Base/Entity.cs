﻿#nullable disable

using Mint.Domain.Models.Base.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Base;

/// <summary>
/// Base entity for MINT
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class Entity<TKey> : IHasKey<TKey>, ITrackable
{
    [Key]
    public TKey Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    
    public DateTimeOffset CreatedDate { get; internal set; } = DateTimeOffset.Now;
    
    public DateTimeOffset? UpdateDateTime { get; set; }
}
