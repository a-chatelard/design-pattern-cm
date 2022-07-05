using CM.Infrastructure.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CM.Infrastructure.Mapping.Base;

public abstract class BaseConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity<TKey>
{
    void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);

        Configure(builder);
    }

    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}