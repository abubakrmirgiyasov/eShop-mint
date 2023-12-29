using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Base;

namespace Mint.Infrastructure.Configurations;

/// <summary>
/// Represents a generic configuration class for an entity in EF Core.
/// This class is used to configure the mapping of the entity to a database table.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IEntityConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity> where TEntity : class;

/// <summary>
/// Represents a generic configuration class for an entity in EF Core that includes a custom key type.
/// This class is used to configure the mapping of the entity to a database table.
/// </summary>
/// <typeparam name="TEntity">The type of the entity being configured.</typeparam>
/// <typeparam name="TKey">The type of the custom key for the entity.</typeparam>
public interface IEntityConfiguration<TEntity, TKey>
    : IEntityTypeConfiguration<TEntity> where TEntity : Entity<TKey>;
