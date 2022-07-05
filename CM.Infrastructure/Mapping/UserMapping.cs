using CM.Infrastructure.Entities;
using CM.Infrastructure.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CM.Infrastructure.Mapping;

public class UserMapping : BaseConfiguration<User, Guid>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Role).HasConversion<string>();
    }
}