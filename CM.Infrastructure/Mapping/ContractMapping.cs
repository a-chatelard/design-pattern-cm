using CM.Infrastructure.Entities.Contracts;
using CM.Infrastructure.Entities.DTO;
using CM.Infrastructure.Mapping.Base;
using CM.Infrastructure.Mapping.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace CM.Infrastructure.Mapping;

public class ContractMapping : BaseConfiguration<Contract, Guid>
{
    public override void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.Property(c => c.State).HasConversion<ContractStateConverter>();

        builder.Property(c => c.TeleworkingAddress).HasConversion(
            a => JsonConvert.SerializeObject(a),
            a => JsonConvert.DeserializeObject<Address>(a));
    }
}