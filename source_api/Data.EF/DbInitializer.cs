using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class DbInitializer
    {
        private readonly ProjectDbContext _context;
        public DbInitializer(ProjectDbContext projectDbContext)
        {
            _context = projectDbContext;
        }

        public async Task Seed()
        {
            Guid l_guid_1 = Guid.NewGuid();
            Guid l_guid_2 = Guid.NewGuid();
            Guid l_guid_3 = Guid.NewGuid();
            Guid l_guid_4 = Guid.NewGuid();

            if (_context.Users.Count() == 0)
            {
                _context.Users.AddRange(new List<User>(){
                    new User(){
                        Id=l_guid_1,
                        AccessFailedCount=0,
                        BirthDay=new DateTime(1999, 12, 1),
                        DateResetTokenExpired=DateTime.UtcNow.AddDays(7),

                        Email="gianghyn123456789@gmail.com",
                        PhoneNumber="0123456789",
                        FirstName="Le",
                        LastName="Giang",
                        Gender="Nam",
                        EmailConfirmed=false,
                        PhoneNumberConfirmed=false,
                        LockoutEnabled=false,

                        UserName="admin",
                        Password="123456",
                        PasswordHash=Encoding.ASCII.GetBytes("123456").ToString(),
                        Role=Enums.ERole.Admin,

                        VerificationShortToken=null,
                        DateVerified=DateTime.UtcNow,

                        TwoFactorEnabled=false,

                        RefreshTokens=new List<RefreshToken>
                        {
                            new RefreshToken
                            {
                                Id=l_guid_2,
                                CreatedByIp="127.0.0.1",
                                Expires=DateTime.UtcNow.AddDays(7),
                                Token="91322406899332748392"
                            }
                        }
                    }
                });

                //_context.SaveChanges();
            }
        }
    }
}
