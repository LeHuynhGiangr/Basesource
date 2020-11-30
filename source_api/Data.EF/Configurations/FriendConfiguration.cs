using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF.Configurations
{
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            //builder.ToTable("friends");

            //builder.Property(_ => _.FriendId).IsRequired(required: true);

            ////add the shadow property to the model
            //builder.Property<Guid>("userid");

            //builder.HasOne(e => e.User).WithMany(e => e.Friends).HasForeignKey("userid").HasConstraintName("fk_friend_user_userid").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
