using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public static class DbInitializer
    {
        //private readonly ProjectDbContext _context;
        //public DbInitializer(ProjectDbContext projectDbContext)
        //{
        //    _context = projectDbContext;
        //}

        //public async Task Seed(this )
        //{
        //    Guid l_guid_1 = Guid.NewGuid();
        //    Guid l_guid_2 = Guid.NewGuid();
        //    Guid l_guid_3 = Guid.NewGuid();
        //    Guid l_guid_4 = Guid.NewGuid();

        //    if (_context.Users.Count() == 0)
        //    {
        //        _context.Users.AddRange(new List<User>(){
        //            new User(){
        //                Id=l_guid_1,
        //                AccessFailedCount=0,
        //                BirthDay=new DateTime(1999, 12, 1),
        //                DateResetTokenExpired=DateTime.UtcNow.AddDays(7),

        //                Email="gianghyn123456789@gmail.com",
        //                PhoneNumber="0123456789",
        //                FirstName="Le",
        //                LastName="Giang",
        //                Gender="Nam",
        //                EmailConfirmed=false,
        //                PhoneNumberConfirmed=false,
        //                LockoutEnabled=false,

        //                UserName="admin",
        //                Password="123456",
        //                PasswordHash=System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
        //                Role=Enums.ERole.Admin,

        //                VerificationShortToken=null,
        //                DateVerified=DateTime.UtcNow,

        //                TwoFactorEnabled=false,

        //                RefreshTokens=new List<RefreshToken>
        //                {
        //                    new RefreshToken
        //                    {
        //                        Id=l_guid_2,
        //                        CreatedByIp="127.0.0.1",
        //                        Expires=DateTime.UtcNow.AddDays(7),
        //                        Token="91322406899332748392"
        //                    }
        //                }
        //            }
        //        });

        //        _context.SaveChanges();
        //    }
        //}
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            Guid l_guid_admin = Guid.NewGuid();
            Guid l_guid_user = Guid.NewGuid();
            Guid l_guid_admin_token = Guid.NewGuid();
            Guid l_guid_user_token = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = l_guid_admin,
                    AccessFailedCount = 0,
                    BirthDay = new DateTime(1999, 12, 1),
                    DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                    Email = "gianghyn123456789@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Le",
                    LastName = "Giang",
                    Gender = "Nam",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = false,

                    UserName = "admin",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.Admin,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,
                },

                new User()
                {
                    Id = l_guid_user,
                    AccessFailedCount = 0,
                    BirthDay = new DateTime(1998, 1, 12),
                    DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                    Email = "gianghyn123456789@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Huynh",
                    LastName = "Le",
                    Gender = "Nu",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = false,

                    UserName = "user",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.User,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,
                }
            );

            modelBuilder.Entity<RefreshToken>().HasData(
                new
                {
                    Id=l_guid_admin_token,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "91322406899332748392",
                    DateCreated= DateTime.Now,
                    userid =l_guid_admin
                },

                new
                {
                    Id = l_guid_user_token,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "93327224064839291389",
                    DateCreated = DateTime.Now,
                    userid = l_guid_user
                }
            );
        }
    }
}