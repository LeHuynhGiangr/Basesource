using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
/// <summary>
/// configuring by fluent api
/// </summary>
namespace Data.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Data.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Data.Entities.User> builder)
        {
            builder.ToTable("appusers");
            builder.Property(propertyExpression: _ => _.FirstName)
                .HasMaxLength(maxLength: 200)
                .IsUnicode(unicode: true)
                .IsRequired(required: true);

            builder.Property(propertyExpression: _ => _.LastName)
                .HasMaxLength(maxLength: 200)
                .IsUnicode(unicode: true)
                .IsRequired(required: true);

            builder.Property(propertyExpression: _ => _.BirthDay).IsRequired(required: true);
        }
    }
}
