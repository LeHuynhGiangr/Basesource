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
    /*
LOB Type	SQL Server Data Type	Max. Size
BLOB	varbinary(MAX)
Image	2,147,483,647
-
CLOB	varchar(MAX)
Text	2,147,483,647
-
CLOB - Unicode	nvarchar(MAX)
NText	1,073,741,823
-
XML data	xml	2,147,483,647
     */
}
