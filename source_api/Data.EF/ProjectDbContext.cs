/*
 * Configuring database context
 */
using Data.EF.Configurations;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.EF
{
    public class ProjectDbContext : IdentityDbContext<User, Role, System.Guid>
    {
        public ProjectDbContext(DbContextOptions dbContextOption) : base(dbContextOption)
        {
        }

        //start declare entities 
        public override DbSet<User> Users { get; set; }
        public override DbSet<Role> Roles { get; set; }
        public DbSet<PostMedia> PostMedias { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TimeLine> TimeLines { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageType> PageTypes { get; set; }
        public DbSet<UserAcademic> UserAcademics { get; set; }
        public DbSet<UserHobby> UserHobbies { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<TripMedia> TripMedias { get; set; }
        public DbSet<ReviewTrip> ReviewTrips { get; set; }
        public DbSet<UserJoinTrip> UserJoinTrips { get; set; }
        public DbSet<Friend> Friends { get; set; }

        //end declare entites

        //this method is called on event model creating
        //take an instance of ModelBuilder as a parameter, this is called by framework when db-context is first created to build the model and its mappings in memory.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //start configure using fluent API
            //config asp identity
            builder.ApplyConfiguration(new RefreshTokenConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("userclaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("userlogins").HasKey(_ => _.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("userroles").HasKey(_ => new { _.UserId, _.RoleId });
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("roleclaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("usertokens").HasKey(_ => _.UserId);
            builder.Entity<Friend>(b =>
            {
                b.HasKey(e => new { e.User1, e.User2 });
                b.HasOne(e => e.User1s).WithMany(e => e.Friends);
                b.HasOne(e => e.User2s).WithMany().OnDelete(DeleteBehavior.ClientSetNull);
            });
            //end config asp identity
            //end configure

            //seeding data by extension method
            builder.SeedData();

            //base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            //auto add created datetime or update modified datetime
            var l_modifiedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (var modifiedEntity in l_modifiedEntities)
            {
                if (modifiedEntity is IDateTracking l_dateTrackedEntity)
                {
                    if (modifiedEntity.State == EntityState.Added)
                    {
                        l_dateTrackedEntity.DateCreated = DateTime.Now;
                    }
                    l_dateTrackedEntity.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
