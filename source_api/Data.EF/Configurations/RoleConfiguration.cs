using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
/// <summary>
/// configuring by fluent api
/// </summary>
namespace Data.EF.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Data.Entities.Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("approles");
            builder.Property(propertyExpression: _ => _.Description)
                .HasMaxLength(maxLength: 200)
                .IsUnicode(unicode: true)
                .IsRequired(required: false);
        }
    }
}
