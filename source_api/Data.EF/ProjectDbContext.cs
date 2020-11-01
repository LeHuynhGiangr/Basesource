/*
 * Configuring database context
 */
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.EF
{
    public  class ProjectDbContext : IdentityDbContext<AppUser, AppRole, System.Guid>
    {
        public ProjectDbContext(DbContextOptions dbContextOption) : base(dbContextOption)
        {
        }

        //start declare entities 
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        //end declare entites

        //this method is called on event model creating
        //take an instance of ModelBuilder as a parameter, this is called by framework when db-context is first created to build the model and its mappings in memory.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //start configure using fluent API
            //builder.ApplyConfiguration()
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
