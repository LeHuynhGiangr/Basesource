using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts");

            builder.Property<System.Guid>("userid");
            builder.HasOne(post => post.User).WithMany(user => user.Posts).HasForeignKey("userid").HasConstraintName("fk_post_user_userid");
        }
    }
}
