/*
 * Configuring database context
 */
using Data.EF.Configurations;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.EF
{
    public  class ProjectDbContext : IdentityDbContext<User, Role, System.Guid>
    {
        public ProjectDbContext(DbContextOptions dbContextOption) : base(dbContextOption)
        {
        }

        //start declare entities 
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Role> AppRoles { get; set; }
        //end declare entites

        //this method is called on event model creating
        //take an instance of ModelBuilder as a parameter, this is called by framework when db-context is first created to build the model and its mappings in memory.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //start configure using fluent API
            //config asp identity
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("userclaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("usertokens");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("userlogins");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("userroles");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("roleclaims");
            //end config asp identity
            //end configure

            base.OnModelCreating(builder);
        }
        
        public override int SaveChanges()
        {
            //auto add created datetime or update modified datetime
            return base.SaveChanges();
        }
    }
}
