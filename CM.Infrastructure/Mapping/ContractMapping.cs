using CM.Infrastructure.Entities;
using CM.Infrastructure.Mapping.Base;
using CM.Infrastructure.Mapping.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CM.Infrastructure.Mapping;

public class ContractMapping : BaseConfiguration<Contract, Guid>
{
    public override void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.Property(c => c.State).HasConversion<ContractStateConverter>();

        builder.HasOne(c => c.User).WithMany(u => u.Contracts).HasForeignKey(c => c.UserId);
    }
}