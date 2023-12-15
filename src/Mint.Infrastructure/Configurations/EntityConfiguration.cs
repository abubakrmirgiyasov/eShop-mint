using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Base;

namespace Mint.Infrastructure.Configurations;

internal class EntityConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity> where TEntity : class
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
}

internal class EntityConfiguration<TEntity,TKey>
    : IEntityTypeConfiguration<TEntity> where TEntity : Entity<TKey>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
}
