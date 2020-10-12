/*
 * Configuring database context
 */
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.EF
{
    class ProjectDbContext : IdentityDbContext<AppUser, AppRole, System.Guid>
    {
        public ProjectDbContext(DbContextOptions dbContextOption) : base(dbContextOption)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        //this method is called on event model creating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //configure using fluent API

            base.OnModelCreating(builder);
        }
        
        public override int SaveChanges()
        {
            //auto add created datetime or update modified datetime
            return base.SaveChanges();
        }
    }
}
