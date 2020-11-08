using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF.Configurations
{
    public class RefreshTokenConfiguration: IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("refreshtokens");

            //add the shadow property to the model
            builder.Property<Guid>("userid");

            builder.HasOne(refreshToken => refreshToken.User).WithMany(user => user.RefreshTokens).HasForeignKey("userid").HasConstraintName("fk_refreshtoken_user_userid");
        }
        //WithOne or WithMany to identify the inverse navigation
        //HasOne/WithOne are used for reference navigation properties
        //HasMany/WithMany are used for collection navigation properties.
        //Dependent entity: This is the entity that contains the foreign key properties. Sometimes referred to as the 'child' of the relationship.
        //Principal entity: This is the entity that contains the primary/alternate key properties. Sometimes referred to as the 'parent' of the relationship.

    }
}
