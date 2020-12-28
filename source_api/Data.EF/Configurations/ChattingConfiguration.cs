using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.EF.Configurations
{
    public class ChattingConfiguration : IEntityTypeConfiguration<Chatting>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Chatting> builder)
        {
            builder.ToTable("chattings");
        }
    }
}
