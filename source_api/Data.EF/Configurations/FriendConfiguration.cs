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
            builder.ToTable("friends");
            builder.HasKey(e => new { e.User1, e.User2 });
            builder.HasOne(e => e.User1s).WithMany(e => e.Friends);
            builder.HasOne(e => e.User2s).WithMany();
            //builder.OnDelete(DeleteBehavior.ClientSetNull);!!!!
        }
    }
}
