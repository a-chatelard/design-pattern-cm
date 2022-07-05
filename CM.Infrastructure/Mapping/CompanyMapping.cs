using CM.Infrastructure.Entities.Companies;
using CM.Infrastructure.Entities.DTO;
using CM.Infrastructure.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace CM.Infrastructure.Mapping
{
    public class CompanyMapping : BaseConfiguration<Company, Guid>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.Address).HasConversion(
                a => JsonConvert.SerializeObject(a),
                a => JsonConvert.DeserializeObject<Address>(a));

            builder.Property(c => c.Type).HasConversion<string>();
        }
    }
}
