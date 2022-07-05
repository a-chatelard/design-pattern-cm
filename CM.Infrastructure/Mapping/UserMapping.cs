using System.Text.Json.Serialization;
using CM.Infrastructure.Entities;
using CM.Infrastructure.Entities.DTO;
using CM.Infrastructure.Mapping.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace CM.Infrastructure.Mapping;

public class UserMapping : BaseConfiguration<User, Guid>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Role).HasConversion<string>();

        builder.Property(u => u.Address).HasConversion(
            a => JsonConvert.SerializeObject(a),
            a => JsonConvert.DeserializeObject<Address>(a)!);
    }
}