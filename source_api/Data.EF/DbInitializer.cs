using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.EF
{
    public static class DbInitializer
    {
        private static Guid l_guid_admin = Guid.NewGuid();
        private static Guid l_guid_admin_token = Guid.NewGuid();

        private static Guid l_guid_user1 = Guid.NewGuid();
        private static Guid l_guid_user_token1 = Guid.NewGuid();
        private static string l_string_user_fullname1 = "Huynh Le";
        private static string l_string_user_pic1 = Utilities.UriHandler.GetImageUri("avar_thumb1.jpg");

        private static Guid l_guid_user2 = Guid.NewGuid();
        private static Guid l_guid_user_token2 = Guid.NewGuid();
        private static string l_string_user_fullname2 = "Dang Bao";
        private static string l_string_user_pic2 = Utilities.UriHandler.GetImageUri("avar_thumb2.jpg");

        private static Guid l_guid_user3 = Guid.NewGuid();
        private static Guid l_guid_user_token3 = Guid.NewGuid();
        private static string l_string_user_fullname3 = "Thu Hang";
        private static string l_string_user_pic3 = Utilities.UriHandler.GetImageUri("avar_thumb3.jpg");

        private static Guid l_guid_user4 = Guid.NewGuid();
        private static Guid l_guid_user_token4 = Guid.NewGuid();
        private static string l_string_user_fullname4 = "Bich Hoang";
        private static string l_string_user_pic4 = Utilities.UriHandler.GetImageUri("avar_thumb4.jpg");

        private static Guid l_guid_user5 = Guid.NewGuid();
        private static Guid l_guid_user_token5 = Guid.NewGuid();
        private static string l_string_user_fullname5 = "Van Tien";
        private static string l_string_user_pic5 = Utilities.UriHandler.GetImageUri("avar_thumb5.jpg");

        private static Guid l_guid_user6 = Guid.NewGuid();
        private static Guid l_guid_user_token6 = Guid.NewGuid();
        private static string l_string_user_fullname6 = "Dong Khoi";
        private static string l_string_user_pic6 = Utilities.UriHandler.GetImageUri("avar_thumb6.jpg");

        private static string l_string_post_pic1 = Utilities.UriHandler.GetImageUri("post_pic4.png");
        private static string l_string_post_pic2 = Utilities.UriHandler.GetImageUri("post_pic3.png");
        private static string l_string_post_pic3 = Utilities.UriHandler.GetImageUri("post_pic9.jpg");
        private static string l_string_post_pic4 = Utilities.UriHandler.GetImageUri("post_pic17.jpg");
        private static string l_string_post_pic5 = Utilities.UriHandler.GetImageUri("post_pic5.png");
        private static string l_string_post_pic6 = Utilities.UriHandler.GetImageUri("post_pic6.jpg");
        private static string l_string_post_pic7 = Utilities.UriHandler.GetImageUri("post_pic7.jpg");
        private static string l_string_post_pic8 = Utilities.UriHandler.GetImageUri("post_pic8.png");
        private static string l_string_post_pic9 = Utilities.UriHandler.GetImageUri("post_pic12.png");
        private static string l_string_post_pic10 = Utilities.UriHandler.GetImageUri("post_pic15.jpg");
        private static string l_string_post_pic11 = Utilities.UriHandler.GetImageUri("post_pic16.png");
        private static string l_string_post_pic12 = Utilities.UriHandler.GetImageUri("post_pic11.png");
        private static string l_string_post_pic13 = Utilities.UriHandler.GetImageUri("post_pic10.png");
        private static string l_string_post_pic14 = Utilities.UriHandler.GetImageUri("post_pic1.png");
        private static string l_string_post_pic15 = Utilities.UriHandler.GetImageUri("post_pic14.png");

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                //admin
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
                    Description = "No description",
                    Active = true,
                    Address = "Ho Chi Minh",
                    FollowMe = true,
                    Location = 111,
                    ViewListFriend = true,
                    ViewTimeLine = true,
                    Works = "Ho Chi Minh",
                    UserName = "admin",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.Admin,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,
                },

                //user1
                //friends of user1, +{2,3,4}, -{5, 6)
                new User()
                {
                    Id = l_guid_user1,
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
                    Description = "No description",
                    Active = true,
                    Address = "Ho Chi Minh",
                    FollowMe = true,
                    Location = 111,
                    ViewListFriend = true,
                    ViewTimeLine = true,
                    Works = "Ho Chi Minh",
                    UserName = "user1",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.User,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,

                    //list friend in json format
                    FriendsJsonString = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id = l_guid_user2,
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2
                        },

                        new
                        {
                            Id = l_guid_user3,
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3
                        },

                        new
                        {
                            Id = l_guid_user4,
                            Name=l_string_user_fullname4,
                            avarThumb=l_string_user_pic4
                        },
                    })
                },

                //user2
                //friends of user2, +{1,3,4}, -{5, 6)
                new User()
                {
                    Id = l_guid_user2,
                    AccessFailedCount = 0,
                    BirthDay = new DateTime(1999, 12, 1),
                    DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                    Email = "gianghyn123456789@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Dang",
                    LastName = "Bao",
                    Gender = "Nam",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = false,
                    Description = "No description",
                    Active = true,
                    Address = "Ho Chi Minh",
                    FollowMe = true,
                    Location = 111,
                    ViewListFriend = true,
                    ViewTimeLine = true,
                    Works = "Ho Chi Minh",
                    UserName = "user2",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.User,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,

                    //list friend in json format
                    FriendsJsonString = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id = l_guid_user1,
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1

                        },

                        new
                        {
                            Id = l_guid_user3,
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3
                        },

                        new
                        {
                            Id = l_guid_user4,
                            Name=l_string_user_fullname4,
                            avarThumb=l_string_user_pic4
                        },
                    })
                },

                //user3
                //friends of user3, +{1,2,4,5,6}
                new User()
                {
                    Id = l_guid_user3,
                    AccessFailedCount = 0,
                    BirthDay = new DateTime(1999, 12, 1),
                    DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                    Email = "gianghyn123456789@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Thu",
                    LastName = "Hang",
                    Gender = "Nu",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = false,
                    Description = "No description",
                    Active = true,
                    Address = "Ho Chi Minh",
                    FollowMe = true,
                    Location = 111,
                    ViewListFriend = true,
                    ViewTimeLine = true,
                    Works = "Ho Chi Minh",
                    UserName = "user3",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.User,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,

                    //list friend in json format
                    FriendsJsonString = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id = l_guid_user1,
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1
                        },

                        new
                        {
                            Id = l_guid_user2,
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2
                        },

                        new
                        {
                            Id = l_guid_user4,
                            Name=l_string_user_fullname4,
                            avarThumb=l_string_user_pic4
                        },

                        new
                        {
                            Id = l_guid_user5,
                            Name=l_string_user_fullname5,
                            avarThumb=l_string_user_pic5
                        },

                        new
                        {
                            Id = l_guid_user6,
                            Name=l_string_user_fullname6,
                            avarThumb=l_string_user_pic6
                        },
                    })
                },

                //user4
                //friends of user4, +{1,2,3,6}, -{5}
                new User()
                {
                    Id = l_guid_user4,
                    AccessFailedCount = 0,
                    BirthDay = new DateTime(1999, 12, 1),
                    DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                    Email = "gianghyn123456789@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Bich",
                    LastName = "Hoang",
                    Gender = "Nu",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = false,
                    Description = "No description",
                    Active = true,
                    Address = "Ho Chi Minh",
                    FollowMe = true,
                    Location = 111,
                    ViewListFriend = true,
                    ViewTimeLine = true,
                    Works = "Ho Chi Minh",
                    UserName = "user4",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.User,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,

                    //list friend in json format
                    FriendsJsonString = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id = l_guid_user1,
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1
                        },

                        new
                        {
                            Id = l_guid_user2,
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2
                        },

                        new
                        {
                            Id = l_guid_user3,
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3
                        },

                        new
                        {
                            Id = l_guid_user6,
                            Name=l_string_user_fullname6,
                            avarThumb=l_string_user_pic6

                        }
                    })
                },

                //user5
                //friends of user5, +{3,6}, -{1,2,4)
                new User()
                {
                    Id = l_guid_user5,
                    AccessFailedCount = 0,
                    BirthDay = new DateTime(1999, 12, 1),
                    DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                    Email = "gianghyn123456789@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Van",
                    LastName = "Tien",
                    Gender = "Nam",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = false,
                    Description = "No description",
                    Active = true,
                    Address = "Ho Chi Minh",
                    FollowMe = true,
                    Location = 111,
                    ViewListFriend = true,
                    ViewTimeLine = true,
                    Works = "Ho Chi Minh",
                    UserName = "user5",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.User,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,

                    //list friend in json format
                    FriendsJsonString = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id = l_guid_user3,
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3

                        },

                        new
                        {
                            Id = l_guid_user6,
                            Name=l_string_user_fullname6,
                            avarThumb=l_string_user_pic6
                        }
                    })
                },

                //user6
                //friends of user6, +{3,4,5}, -{1,2)
                new User()
                {
                    Id = l_guid_user6,
                    AccessFailedCount = 0,
                    BirthDay = new DateTime(1999, 12, 1),
                    DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                    Email = "gianghyn123456789@gmail.com",
                    PhoneNumber = "0123456789",
                    FirstName = "Dong",
                    LastName = "Khoi",
                    Gender = "Nam",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = false,
                    Description = "No description",
                    Active = true,
                    Address = "Ho Chi Minh",
                    FollowMe = true,
                    Location = 111,
                    ViewListFriend = true,
                    ViewTimeLine = true,
                    Works = "Ho Chi Minh",
                    UserName = "user6",
                    Password = "123456",
                    PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                    Role = Enums.ERole.User,

                    VerificationShortToken = null,
                    DateVerified = DateTime.UtcNow,

                    TwoFactorEnabled = false,

                    //list friend in json format
                    FriendsJsonString = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id = l_guid_user3,
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3
                        },

                        new
                        {
                            Id = l_guid_user4,
                            Name=l_string_user_fullname4,
                            avarThumb=l_string_user_pic4
                        },

                        new
                        {
                            Id = l_guid_user5,
                            Name=l_string_user_fullname5,
                            avarThumb=l_string_user_pic5
                        }
                    })
                }
            );

            modelBuilder.Entity<RefreshToken>().HasData(
                new
                {
                    Id = l_guid_admin_token,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "91322406899332748392",
                    DateCreated = DateTime.Now,
                    userid = l_guid_admin
                },
                new
                {
                    Id = l_guid_user_token1,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "93327224064839291389",
                    DateCreated = DateTime.Now,
                    userid = l_guid_user1
                },
                new
                {
                    Id = l_guid_user_token2,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "93327224064839291389",
                    DateCreated = DateTime.Now,
                    userid = l_guid_user2
                },
                new
                {
                    Id = l_guid_user_token3,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "93327224064839291389",
                    DateCreated = DateTime.Now,
                    userid = l_guid_user3
                },
                new
                {
                    Id = l_guid_user_token4,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "93327224064839291389",
                    DateCreated = DateTime.Now,
                    userid = l_guid_user4
                },
                new
                {
                    Id = l_guid_user_token5,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "93327224064839291389",
                    DateCreated = DateTime.Now,
                    userid = l_guid_user5
                },
                new
                {
                    Id = l_guid_user_token6,
                    CreatedByIp = "127.0.0.1",
                    Expires = DateTime.UtcNow.AddDays(7),
                    Token = "93327224064839291389",
                    DateCreated = DateTime.Now,
                    userid = l_guid_user6
                }
            );

            modelBuilder.Entity<Post>().HasData(
                //post of user1
                new
                {
                    Id = 1,
                    Content = "Hello everyone!",
                    ImageUri = l_string_post_pic1,
                    //ImageUriByte = new byte[3] { 0x20, 0x30, 0xab},
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user2.ToString(),
                                Name=l_string_user_fullname2,
                            },
                            new
                            {
                                Id = l_guid_user3.ToString(),
                                Name=l_string_user_fullname3,
                            }
                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user2.ToString(),
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2,
                            Comment="i like it!"
                        },
                        new
                        {
                            Id = l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="i will be here"
                        }
                    }),

                    DateCreated = DateTime.Now,

                    userid = l_guid_user1
                },

                new
                {
                    Id = 2,
                    Content = "Today is wonderful day",
                    ImageUri = l_string_post_pic2,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user2.ToString(),
                                Name=l_string_user_fullname2,
                                avarThumb=l_string_user_pic2
                            },
                            new
                            {
                                Id = l_guid_user3.ToString(),
                                Name=l_string_user_fullname3,
                                avarThumb=l_string_user_pic3
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user2.ToString(),
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2,
                            Comment="i like it!"
                        },
                        new
                        {
                            Id = l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="i will be here"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user1
                },

                //post of user2
                new
                {
                    Id = 3,
                    Content = "Halong Bay is a beautiful natural wonder in northern Vietnam near the Chinese border. The Bay is dotted with 1,600 limestone islands and islets and covers an area of over 1,500 sqkm. This extraordinary area was declared a UNESCO World Heritage Site in 1994. For many tourists, this place is like something right out of a movie. The fact is that Halong Bay features a wide range of biodiversity, while the surrealistic scenery has indeed featured in endless movies.",
                    ImageUri = l_string_post_pic3,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user1.ToString(),
                                Name=l_string_user_fullname1
                            },
                            new
                            {
                                Id = l_guid_user3.ToString(),
                                Name=l_string_user_fullname3
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user1.ToString(),
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1,
                            Comment="i like it!"
                        },
                        new
                        {
                            Id = l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="i will be here"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user2
                },

                new
                {
                    Id = 4,
                    Content = "Bà Nà là khu du lich toạ lạc 1 khu vực thuộc về dãy núi Trường Sơn nằm ở xã Hòa Ninh, huyện Hòa Vang, cách Đà Nẵng 25 km về phía Tây Nam. Trung tâm du lịch của Bà Nà nằm trên đỉnh Núi Chúa có độ cao 1489 m so với mực nước biển.",
                    ImageUri = l_string_post_pic4,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user1.ToString(),
                                Name=l_string_user_fullname1
                            },
                            new
                            {
                                Id = l_guid_user3.ToString(),
                                Name=l_string_user_fullname3
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user1.ToString(),
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1,
                            Comment="i like it!"
                        },
                        new
                        {
                            Id = l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="i will be here"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user2
                },

                new
                {
                    Id = 5,
                    Content = "Ghềnh Đá Dĩa là một tập hợp các trụ đá hình lăng trụ xếp liền nhau, hòn nọ nối hòn kia kề với sóng nước. Bãi đá trải rộng san sát nhau chung màu đen huyền bí. Có trụ thẳng đứng, có trụ nghiêng vẹo nhưng vẫn chồng chất tầng tầng trông như chồng bát dĩa nên có tên gọi là Ghềnh Đá Dĩa. Nhìn từ xa, Ghềnh Đá trông giống một tổ ong thiên tạo khổng lồ vô cùng kỳ vĩ. " +
                    "Các cột đá badan của Ghềnh Đá Dĩa được các nhà nghiên cứu cho là hình thành cách đây hàng triệu năm," +
                    "khi các dòng nham thạch nóng chảy phun ra từ các núi lửa ở cao nguyên Vân Hoà(cách 30km) gặp nước biển lạnh nên đông cứng và nứt vỡ mà thành." +
                    "Liền kề với Ghềnh Đá Dĩa là Bãi Bàng tĩnh lặng với bãi cát trải mịn màng.Rất có tiềm năng phát triển du lịch biển với bãi cát trắng mịn và hàng dừa xanh mát.Nằm cạnh là ngôi đình thờ lăng ông linh thiêng của ngư dân thôn Phú Hạnh.Những phiến đá ở đây dân địa phương còn gọi là vảy rồng(xưa kia khu vực này hoàn toàn là đá vẩy rồng) do nhu cầu canh tác nên họ bồi đất lên, nếu ta đào sâu xuống bên dưới chỉ toàn đá.",
                    ImageUri = l_string_post_pic5,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user1.ToString(),
                                Name=l_string_user_fullname1
                            },
                            new
                            {
                                Id = l_guid_user3.ToString(),
                                Name=l_string_user_fullname3
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user1.ToString(),
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1,
                            Comment="i like it!"
                        },
                        new
                        {
                            Id = l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="i will be here"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user2
                },

                //post of user3
                new
                {
                    Id = 6,
                    Content = "Dalat travel guide: full experiences with useful travel tips,Dalat travel guide: full experiences and useful travel tips in Da Lat city such as transportation, accommodation, local food, famous tourist places…",
                    ImageUri = l_string_post_pic6,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user1.ToString(),
                                Name=l_string_user_fullname1
                            },
                            new
                            {
                                Id = l_guid_user2.ToString(),
                                Name=l_string_user_fullname2
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user1.ToString(),
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1,
                            Comment="Where to stay in here!"
                        },
                        new
                        {
                            Id = l_guid_user2.ToString(),
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2,
                            Comment="greatest place i've ever seen"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user3
                },

                //post of user4
                new
                {
                    Id = 7,
                    Content = "Travel to Phu Yen – Everything you need to know Phu Yen Overview: Phu Yen is another off beat track destination in Central of Vietnam with pristine beaches, busy fisherman villages, glistening mini desserts, mouth-watering seafood and astounding natural landscapes. If you’re planning to travel to Phu Yen for a peaceful holiday, you certainly won’t be disappointed.",
                    ImageUri = l_string_post_pic7,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user1.ToString(),
                                Name=l_string_user_fullname1
                            },
                            new
                            {
                                Id = l_guid_user2.ToString(),
                                Name=l_string_user_fullname2
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user1.ToString(),
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1,
                            Comment=":)"
                        },
                        new
                        {
                            Id = l_guid_user2.ToString(),
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2,
                            Comment="woow!!!"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user4
                },

                new
                {
                    Id = 8,
                    Content = "Getting Around in Phu Yen: Once you travel to Phu Yen, you’ll need transportation to get to all the beautiful sights. Since they are quite spread out, some as far as 50 kilometers from Tuy Hoa, walking or biking is not an option for most travelers.",
                    ImageUri = l_string_post_pic8,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user1.ToString(),
                                Name=l_string_user_fullname1
                            },
                            new
                            {
                                Id = l_guid_user2.ToString(),
                                Name=l_string_user_fullname2
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user1.ToString(),
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1,
                            Comment=":)"
                        },
                        new
                        {
                            Id = l_guid_user2.ToString(),
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2,
                            Comment="woow!!!"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user4
                },

                new
                {
                    Id = 9,
                    Content = "Where to Stay in Phu Yen: As more people are discovering Phu Yen, more hotels, hostels, and homestays are popping up. This gives you several places to choose from in categories ranging from luxury to budget." +
                    "Want to surprise your partner with a nice room ? Then you can splurge on the Vietstar Resort & Spa, a five - star property close to the city with a beautiful pool and sweeping views of the ocean. If you’re looking for a more budget - friendly place to stay which is also closer to the beach, have a look at the Sala Tuy Hoa Beach Hotel.This newly opened hotel is only a four - minute walk from the sea and offers great amenities and even an airport shuttle.",
                    ImageUri = l_string_post_pic9,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user1.ToString(),
                                Name=l_string_user_fullname1
                            },
                            new
                            {
                                Id = l_guid_user2.ToString(),
                                Name=l_string_user_fullname2
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user1.ToString(),
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1,
                            Comment=":)"
                        },
                        new
                        {
                            Id = l_guid_user2.ToString(),
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2,
                            Comment="woow!!!"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user4
                },

                new
                {
                    Id = 10,
                    Content = "Explore Tuy Hoa: The capital of Phu Yen province, Tuy Hoa is the center of cultural and economic life in the area. It is also home to some great historical spots such as the Ngoc Lang temple and the Nhan tower built by the Champa people. Take a few hours to check out the city before heading out into the countryside, it’s well worth it.",
                    ImageUri = l_string_post_pic10,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user1.ToString(),
                                Name=l_string_user_fullname1
                            },
                            new
                            {
                                Id = l_guid_user2.ToString(),
                                Name=l_string_user_fullname2
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user1.ToString(),
                            Name=l_string_user_fullname1,
                            avarThumb=l_string_user_pic1,
                            Comment=":)"
                        },
                        new
                        {
                            Id = l_guid_user2.ToString(),
                            Name=l_string_user_fullname2,
                            avarThumb=l_string_user_pic2,
                            Comment="woow!!!"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user4
                },

                //post of user5
                new
                {
                    Id = 11,
                    Content = "Xep Beach: A small beach with the length of only 500 meters, Xep Beach is a quiet place suitable for those seeking peace and tranquility during their trip. There are black stones lining along the beach, adding some sharpness to the softness of the ocean." +
                    "You can climb onto a hill nearby for a sweeping view of Xep Beach from above. This hill became popular to tourists as the place where the children from “I see yellow flowers on the green grass” flew kites. In real life, this place is a small meadow where the locals’ cows are herded. I did not see any yellow flower there though, unfortunately.",
                    ImageUri = l_string_post_pic11,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user3.ToString(),
                                Name=l_string_user_fullname3
                            },
                            new
                            {
                                Id = l_guid_user6.ToString(),
                                Name=l_string_user_fullname6
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="haha"
                        },
                        new
                        {
                            Id = l_guid_user6.ToString(),
                            Name=l_string_user_fullname6,
                            avarThumb=l_string_user_pic6,
                            Comment="You can climb onto a hill nearby for a sweeping view of Xep Beach from above"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user5
                },

                new
                {
                    Id = 12,
                    Content = "O Loan Lagoon: Since O Loan Lagoon is quite large, it’s not easy to identify the most picture-perfect corner to stop at. We rode along O Loan Lagoon under the heat of midday and stopped at a local seafood restaurant with a view of part of the lagoon. That view was not so impressive to be honest. Yet we had the chance to taste Blood Oyster: a must-try local cuisine.",
                    ImageUri = l_string_post_pic12,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user3.ToString(),
                                Name=l_string_user_fullname3
                            },
                            new
                            {
                                Id = l_guid_user6.ToString(),
                                Name=l_string_user_fullname6
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="haha"
                        },
                        new
                        {
                            Id = l_guid_user6.ToString(),
                            Name=l_string_user_fullname6,
                            avarThumb=l_string_user_pic6,
                            Comment="You can climb onto a hill nearby for a sweeping view of Xep Beach from above"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user5
                },

                new
                {
                    Id = 13,
                    Content = "Mui Dien Cape – the easternmost point of Vietnam’s territory: Theoretically speaking, Mui Dien Cape is the first location in Vietnam to receive sunlight for a new day. After climbing steps for around 30 minutes (slow pace), you will reach the foot of the Mui Dien Lighthouse. Climbing up to the lighthouse gives a stunning view of the sea below.",
                    ImageUri = l_string_post_pic13,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user3.ToString(),
                                Name=l_string_user_fullname3
                            },
                            new
                            {
                                Id = l_guid_user6.ToString(),
                                Name=l_string_user_fullname6
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="haha"
                        },
                        new
                        {
                            Id = l_guid_user6.ToString(),
                            Name=l_string_user_fullname6,
                            avarThumb=l_string_user_pic6,
                            Comment="You can climb onto a hill nearby for a sweeping view of Xep Beach from above"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user5
                },

                //post of user6
                new
                {
                    Id = 14,
                    Content = "Bai Mon Beach: Bai Mon Beach can be accessed from the entrance to Mui Dien area as well. You need to pay an entrance fee and also a parking fee (very cheap!). There are shower rooms near the entrance for you to change before walking 200 meters to the beach.",
                    ImageUri = l_string_post_pic14,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user3.ToString(),
                                Name=l_string_user_fullname3
                            },
                            new
                            {
                                Id = l_guid_user4.ToString(),
                                Name=l_string_user_fullname4
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="haha"
                        },
                        new
                        {
                            Id = l_guid_user4.ToString(),
                            Name=l_string_user_fullname4,
                            avarThumb=l_string_user_pic4,
                            Comment="đẹp quá"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user6
                },

                new
                {
                    Id = 15,
                    Content = "What to eat in Phu Yen Candidate #1 – Chicken Rice (Com Ga)",
                    ImageUri = l_string_post_pic15,
                    LikeObjectsJson = JsonSerializer.Serialize(new
                    {
                        count = 2,
                        subjects = new List<object>
                        {
                            new
                            {
                                Id=l_guid_user3.ToString(),
                                Name=l_string_user_fullname3
                            },
                            new
                            {
                                Id = l_guid_user4.ToString(),
                                Name=l_string_user_fullname4
                            }


                        }
                    }),

                    CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                    {
                        new
                        {
                            Id=l_guid_user3.ToString(),
                            Name=l_string_user_fullname3,
                            avarThumb=l_string_user_pic3,
                            Comment="Quê mình có bánh tráng nha"
                        },
                        new
                        {
                            Id = l_guid_user4.ToString(),
                            Name=l_string_user_fullname4,
                            avarThumb=l_string_user_pic4,
                            Comment="Cơm gà là món mình rất thích"
                        }
                    }),

                    DateCreated = DateTime.Now,
                    userid = l_guid_user6
                }

            );
        }

        public static void SeedData(ProjectDbContext projectDbContext)
        {
            if (!projectDbContext.Users.Any())
            {
                projectDbContext.Users.AddRange(new List<User>() {
                    //admin
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
                        Description = "No description",
                        Active = true,
                        Address = "Ho Chi Minh",
                        FollowMe = true,
                        Location = 111,
                        ViewListFriend = true,
                        ViewTimeLine = true,
                        Works = "Ho Chi Minh",
                        UserName = "admin",
                        Password = "123456",
                        PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                        Role = Enums.ERole.Admin,

                        VerificationShortToken = null,
                        DateVerified = DateTime.UtcNow,

                        TwoFactorEnabled = false,

                        RefreshTokens=new List<RefreshToken>
                        {
                            new RefreshToken
                            {
                                Id = l_guid_admin_token,
                                CreatedByIp = "127.0.0.1",
                                Expires = DateTime.UtcNow.AddDays(7),
                                Token = "91322406899332748392",
                                DateCreated = DateTime.Now,
                            }
                        },
                    },

                    //user1
                    //friends of user1, +{2,3,4}, -{5, 6)
                    new User()
                    {
                        Id = l_guid_user1,
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
                        Description = "No description",
                        Active = true,
                        Address = "Ho Chi Minh",
                        FollowMe = true,
                        Location = 111,
                        ViewListFriend = true,
                        ViewTimeLine = true,
                        Works = "Ho Chi Minh",
                        UserName = "user1",
                        Password = "123456",
                        PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                        Role = Enums.ERole.User,

                        VerificationShortToken = null,
                        DateVerified = DateTime.UtcNow,

                        TwoFactorEnabled = false,

                        //list friend in json format
                        FriendsJsonString = JsonSerializer.Serialize(new List<object>
                        {
                            new
                            {
                                Id = l_guid_user2,
                                Name=l_string_user_fullname2,
                                avarThumb=l_string_user_pic2
                            },

                            new
                            {
                                Id = l_guid_user3,
                                Name=l_string_user_fullname3,
                                avarThumb=l_string_user_pic3
                            },

                            new
                            {
                                Id = l_guid_user4,
                                Name=l_string_user_fullname4,
                                avarThumb=l_string_user_pic4
                            },
                        }),

                        RefreshTokens=new List<RefreshToken>
                        {
                            new RefreshToken
                            {
                                Id = l_guid_user_token1,
                                CreatedByIp = "127.0.0.1",
                                Expires = DateTime.UtcNow.AddDays(7),
                                Token = "93327224064839291389",
                                DateCreated = DateTime.Now,
                            }
                        },

                        Posts = new List<Post>
                        {
                            new Post
                            {
                                //Id = 1,
                                Content = "Hello everyone!",
                                ImageUri = l_string_post_pic1,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user2.ToString(),
                                            Name=l_string_user_fullname2,
                                        },
                                        new
                                        {
                                            Id = l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3,
                                        }
                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user2.ToString(),
                                        Name=l_string_user_fullname2,
                                        avarThumb=l_string_user_pic2,
                                        Comment="i like it!"
                                    },
                                    new
                                    {
                                        Id = l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="i will be here"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },

                            new Post
                            {
                                //Id = 2,
                                Content = "Today is wonderful day",
                                ImageUri = l_string_post_pic2,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user2.ToString(),
                                            Name=l_string_user_fullname2,
                                            avarThumb=l_string_user_pic2
                                        },
                                        new
                                        {
                                            Id = l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3,
                                            avarThumb=l_string_user_pic3
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user2.ToString(),
                                        Name=l_string_user_fullname2,
                                        avarThumb=l_string_user_pic2,
                                        Comment="i like it!"
                                    },
                                    new
                                    {
                                        Id = l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="i will be here"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },
                        }
                    },

                    //user2
                    //friends of user2, +{1,3,4}, -{5, 6)
                    new User()
                    {
                        Id = l_guid_user2,
                        AccessFailedCount = 0,
                        BirthDay = new DateTime(1999, 12, 1),
                        DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                        Email = "gianghyn123456789@gmail.com",
                        PhoneNumber = "0123456789",
                        FirstName = "Dang",
                        LastName = "Bao",
                        Gender = "Nam",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        Description = "No description",
                        Active = true,
                        Address = "Ho Chi Minh",
                        FollowMe = true,
                        Location = 111,
                        ViewListFriend = true,
                        ViewTimeLine = true,
                        Works = "Ho Chi Minh",
                        UserName = "user2",
                        Password = "123456",
                        PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                        Role = Enums.ERole.User,

                        VerificationShortToken = null,
                        DateVerified = DateTime.UtcNow,

                        TwoFactorEnabled = false,

                        //list friend in json format
                        FriendsJsonString = JsonSerializer.Serialize(new List<object>
                        {
                            new
                            {
                                Id = l_guid_user1,
                                Name=l_string_user_fullname1,
                                avarThumb=l_string_user_pic1

                            },

                            new
                            {
                                Id = l_guid_user3,
                                Name=l_string_user_fullname3,
                                avarThumb=l_string_user_pic3
                            },

                            new
                            {
                                Id = l_guid_user4,
                                Name=l_string_user_fullname4,
                                avarThumb=l_string_user_pic4
                            },
                        }),

                        RefreshTokens=new List<RefreshToken>
                        {
                            new RefreshToken
                            {
                                Id = l_guid_user_token2,
                                CreatedByIp = "127.0.0.1",
                                Expires = DateTime.UtcNow.AddDays(7),
                                Token = "93327224064839291389",
                                DateCreated = DateTime.Now,
                            }
                        },

                        Posts=new List<Post>
                        {
                            new Post
                            {
                                //Id = 3,
                                Content = "Halong Bay is a beautiful natural wonder in northern Vietnam near the Chinese border. The Bay is dotted with 1,600 limestone islands and islets and covers an area of over 1,500 sqkm. This extraordinary area was declared a UNESCO World Heritage Site in 1994. For many tourists, this place is like something right out of a movie. The fact is that Halong Bay features a wide range of biodiversity, while the surrealistic scenery has indeed featured in endless movies.",
                                ImageUri = l_string_post_pic3,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user1.ToString(),
                                            Name=l_string_user_fullname1
                                        },
                                        new
                                        {
                                            Id = l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user1.ToString(),
                                        Name=l_string_user_fullname1,
                                        avarThumb=l_string_user_pic1,
                                        Comment="i like it!"
                                    },
                                    new
                                    {
                                        Id = l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="i will be here"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },

                            new Post
                            {
                                //Id = 4,
                                Content = "Bà Nà là khu du lich toạ lạc 1 khu vực thuộc về dãy núi Trường Sơn nằm ở xã Hòa Ninh, huyện Hòa Vang, cách Đà Nẵng 25 km về phía Tây Nam. Trung tâm du lịch của Bà Nà nằm trên đỉnh Núi Chúa có độ cao 1489 m so với mực nước biển.",
                                ImageUri = l_string_post_pic4,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user1.ToString(),
                                            Name=l_string_user_fullname1
                                        },
                                        new
                                        {
                                            Id = l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user1.ToString(),
                                        Name=l_string_user_fullname1,
                                        avarThumb=l_string_user_pic1,
                                        Comment="i like it!"
                                    },
                                    new
                                    {
                                        Id = l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="i will be here"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },

                            new Post
                            {
                                //Id = 5,
                                Content = "Ghềnh Đá Dĩa là một tập hợp các trụ đá hình lăng trụ xếp liền nhau, hòn nọ nối hòn kia kề với sóng nước. Bãi đá trải rộng san sát nhau chung màu đen huyền bí. Có trụ thẳng đứng, có trụ nghiêng vẹo nhưng vẫn chồng chất tầng tầng trông như chồng bát dĩa nên có tên gọi là Ghềnh Đá Dĩa. Nhìn từ xa, Ghềnh Đá trông giống một tổ ong thiên tạo khổng lồ vô cùng kỳ vĩ. " +
                                "Các cột đá badan của Ghềnh Đá Dĩa được các nhà nghiên cứu cho là hình thành cách đây hàng triệu năm," +
                                "khi các dòng nham thạch nóng chảy phun ra từ các núi lửa ở cao nguyên Vân Hoà(cách 30km) gặp nước biển lạnh nên đông cứng và nứt vỡ mà thành." +
                                "Liền kề với Ghềnh Đá Dĩa là Bãi Bàng tĩnh lặng với bãi cát trải mịn màng.Rất có tiềm năng phát triển du lịch biển với bãi cát trắng mịn và hàng dừa xanh mát.Nằm cạnh là ngôi đình thờ lăng ông linh thiêng của ngư dân thôn Phú Hạnh.Những phiến đá ở đây dân địa phương còn gọi là vảy rồng(xưa kia khu vực này hoàn toàn là đá vẩy rồng) do nhu cầu canh tác nên họ bồi đất lên, nếu ta đào sâu xuống bên dưới chỉ toàn đá.",
                                ImageUri = l_string_post_pic5,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user1.ToString(),
                                            Name=l_string_user_fullname1
                                        },
                                        new
                                        {
                                            Id = l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user1.ToString(),
                                        Name=l_string_user_fullname1,
                                        avarThumb=l_string_user_pic1,
                                        Comment="i like it!"
                                    },
                                    new
                                    {
                                        Id = l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="i will be here"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },
                        }
                    },

                    //user3
                    //friends of user3, +{1,2,4,5,6}
                    new User()
                    {
                        Id = l_guid_user3,
                        AccessFailedCount = 0,
                        BirthDay = new DateTime(1999, 12, 1),
                        DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                        Email = "gianghyn123456789@gmail.com",
                        PhoneNumber = "0123456789",
                        FirstName = "Thu",
                        LastName = "Hang",
                        Gender = "Nu",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        Description = "No description",
                        Active = true,
                        Address = "Ho Chi Minh",
                        FollowMe = true,
                        Location = 111,
                        ViewListFriend = true,
                        ViewTimeLine = true,
                        Works = "Ho Chi Minh",
                        UserName = "user3",
                        Password = "123456",
                        PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                        Role = Enums.ERole.User,

                        VerificationShortToken = null,
                        DateVerified = DateTime.UtcNow,

                        TwoFactorEnabled = false,

                        //list friend in json format
                        FriendsJsonString = JsonSerializer.Serialize(new List<object>
                        {
                            new
                            {
                                Id = l_guid_user1,
                                Name=l_string_user_fullname1,
                                avarThumb=l_string_user_pic1
                            },

                            new
                            {
                                Id = l_guid_user2,
                                Name=l_string_user_fullname2,
                                avarThumb=l_string_user_pic2
                            },

                            new
                            {
                                Id = l_guid_user4,
                                Name=l_string_user_fullname4,
                                avarThumb=l_string_user_pic4
                            },

                            new
                            {
                                Id = l_guid_user5,
                                Name=l_string_user_fullname5,
                                avarThumb=l_string_user_pic5
                            },

                            new
                            {
                                Id = l_guid_user6,
                                Name=l_string_user_fullname6,
                                avarThumb=l_string_user_pic6
                            },
                        }),

                        RefreshTokens=new List<RefreshToken>
                        {
                            new RefreshToken
                            {
                                Id = l_guid_user_token3,
                                CreatedByIp = "127.0.0.1",
                                Expires = DateTime.UtcNow.AddDays(7),
                                Token = "93327224064839291389",
                                DateCreated = DateTime.Now,
                            }
                        },

                        Posts = new List<Post>
                        {
                            new Post
                            {
                                //Id = 6,
                                Content = "Dalat travel guide: full experiences with useful travel tips,Dalat travel guide: full experiences and useful travel tips in Da Lat city such as transportation, accommodation, local food, famous tourist places…",
                                ImageUri = l_string_post_pic6,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user1.ToString(),
                                            Name=l_string_user_fullname1
                                        },
                                        new
                                        {
                                            Id = l_guid_user2.ToString(),
                                            Name=l_string_user_fullname2
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user1.ToString(),
                                        Name=l_string_user_fullname1,
                                        avarThumb=l_string_user_pic1,
                                        Comment="Where to stay in here!"
                                    },
                                    new
                                    {
                                        Id = l_guid_user2.ToString(),
                                        Name=l_string_user_fullname2,
                                        avarThumb=l_string_user_pic2,
                                        Comment="greatest place i've ever seen"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },
                        }
                    },

                    //user4
                    //friends of user4, +{1,2,3,6}, -{5}
                    new User()
                    {
                        Id = l_guid_user4,
                        AccessFailedCount = 0,
                        BirthDay = new DateTime(1999, 12, 1),
                        DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                        Email = "gianghyn123456789@gmail.com",
                        PhoneNumber = "0123456789",
                        FirstName = "Bich",
                        LastName = "Hoang",
                        Gender = "Nu",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        Description = "No description",
                        Active = true,
                        Address = "Ho Chi Minh",
                        FollowMe = true,
                        Location = 111,
                        ViewListFriend = true,
                        ViewTimeLine = true,
                        Works = "Ho Chi Minh",
                        UserName = "user4",
                        Password = "123456",
                        PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                        Role = Enums.ERole.User,

                        VerificationShortToken = null,
                        DateVerified = DateTime.UtcNow,

                        TwoFactorEnabled = false,

                        //list friend in json format
                        FriendsJsonString = JsonSerializer.Serialize(new List<object>
                        {
                            new
                            {
                                Id = l_guid_user1,
                                Name=l_string_user_fullname1,
                                avarThumb=l_string_user_pic1
                            },

                            new
                            {
                                Id = l_guid_user2,
                                Name=l_string_user_fullname2,
                                avarThumb=l_string_user_pic2
                            },

                            new
                            {
                                Id = l_guid_user3,
                                Name=l_string_user_fullname3,
                                avarThumb=l_string_user_pic3
                            },

                            new
                            {
                                Id = l_guid_user6,
                                Name=l_string_user_fullname6,
                                avarThumb=l_string_user_pic6

                            }
                        }),

                        RefreshTokens=new List<RefreshToken>
                        {
                            new RefreshToken
                            {
                                Id = l_guid_user_token4,
                                CreatedByIp = "127.0.0.1",
                                Expires = DateTime.UtcNow.AddDays(7),
                                Token = "93327224064839291389",
                                DateCreated = DateTime.Now,
                            }
                        },

                        Posts = new List<Post>{
                            new Post
                            {
                                //Id = 7,
                                Content = "Travel to Phu Yen – Everything you need to know Phu Yen Overview: Phu Yen is another off beat track destination in Central of Vietnam with pristine beaches, busy fisherman villages, glistening mini desserts, mouth-watering seafood and astounding natural landscapes. If you’re planning to travel to Phu Yen for a peaceful holiday, you certainly won’t be disappointed.",
                                ImageUri = l_string_post_pic7,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user1.ToString(),
                                            Name=l_string_user_fullname1
                                        },
                                        new
                                        {
                                            Id = l_guid_user2.ToString(),
                                            Name=l_string_user_fullname2
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user1.ToString(),
                                        Name=l_string_user_fullname1,
                                        avarThumb=l_string_user_pic1,
                                        Comment=":)"
                                    },
                                    new
                                    {
                                        Id = l_guid_user2.ToString(),
                                        Name=l_string_user_fullname2,
                                        avarThumb=l_string_user_pic2,
                                        Comment="woow!!!"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },

                            new Post
                            {
                                //Id = 8,
                                Content = "Getting Around in Phu Yen: Once you travel to Phu Yen, you’ll need transportation to get to all the beautiful sights. Since they are quite spread out, some as far as 50 kilometers from Tuy Hoa, walking or biking is not an option for most travelers.",
                                ImageUri = l_string_post_pic8,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user1.ToString(),
                                            Name=l_string_user_fullname1
                                        },
                                        new
                                        {
                                            Id = l_guid_user2.ToString(),
                                            Name=l_string_user_fullname2
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user1.ToString(),
                                        Name=l_string_user_fullname1,
                                        avarThumb=l_string_user_pic1,
                                        Comment=":)"
                                    },
                                    new
                                    {
                                        Id = l_guid_user2.ToString(),
                                        Name=l_string_user_fullname2,
                                        avarThumb=l_string_user_pic2,
                                        Comment="woow!!!"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },

                            new Post
                            {
                                //Id = 9,
                                Content = "Where to Stay in Phu Yen: As more people are discovering Phu Yen, more hotels, hostels, and homestays are popping up. This gives you several places to choose from in categories ranging from luxury to budget." +
                                "Want to surprise your partner with a nice room ? Then you can splurge on the Vietstar Resort & Spa, a five - star property close to the city with a beautiful pool and sweeping views of the ocean. If you’re looking for a more budget - friendly place to stay which is also closer to the beach, have a look at the Sala Tuy Hoa Beach Hotel.This newly opened hotel is only a four - minute walk from the sea and offers great amenities and even an airport shuttle.",
                                ImageUri = l_string_post_pic9,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user1.ToString(),
                                            Name=l_string_user_fullname1
                                        },
                                        new
                                        {
                                            Id = l_guid_user2.ToString(),
                                            Name=l_string_user_fullname2
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user1.ToString(),
                                        Name=l_string_user_fullname1,
                                        avarThumb=l_string_user_pic1,
                                        Comment=":)"
                                    },
                                    new
                                    {
                                        Id = l_guid_user2.ToString(),
                                        Name=l_string_user_fullname2,
                                        avarThumb=l_string_user_pic2,
                                        Comment="woow!!!"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },

                            new Post
                            {
                                //Id = 10,
                                Content = "Explore Tuy Hoa: The capital of Phu Yen province, Tuy Hoa is the center of cultural and economic life in the area. It is also home to some great historical spots such as the Ngoc Lang temple and the Nhan tower built by the Champa people. Take a few hours to check out the city before heading out into the countryside, it’s well worth it.",
                                ImageUri = l_string_post_pic10,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user1.ToString(),
                                            Name=l_string_user_fullname1
                                        },
                                        new
                                        {
                                            Id = l_guid_user2.ToString(),
                                            Name=l_string_user_fullname2
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user1.ToString(),
                                        Name=l_string_user_fullname1,
                                        avarThumb=l_string_user_pic1,
                                        Comment=":)"
                                    },
                                    new
                                    {
                                        Id = l_guid_user2.ToString(),
                                        Name=l_string_user_fullname2,
                                        avarThumb=l_string_user_pic2,
                                        Comment="woow!!!"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },
                        }
                    },

                    //user5
                    //friends of user5, +{3,6}, -{1,2,4)
                    new User()
                    {
                        Id = l_guid_user5,
                        AccessFailedCount = 0,
                        BirthDay = new DateTime(1999, 12, 1),
                        DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                        Email = "gianghyn123456789@gmail.com",
                        PhoneNumber = "0123456789",
                        FirstName = "Van",
                        LastName = "Tien",
                        Gender = "Nam",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        Description = "No description",
                        Active = true,
                        Address = "Ho Chi Minh",
                        FollowMe = true,
                        Location = 111,
                        ViewListFriend = true,
                        ViewTimeLine = true,
                        Works = "Ho Chi Minh",
                        UserName = "user5",
                        Password = "123456",
                        PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                        Role = Enums.ERole.User,

                        VerificationShortToken = null,
                        DateVerified = DateTime.UtcNow,

                        TwoFactorEnabled = false,

                        //list friend in json format
                        FriendsJsonString = JsonSerializer.Serialize(new List<object>
                        {
                            new
                            {
                                Id = l_guid_user3,
                                Name=l_string_user_fullname3,
                                avarThumb=l_string_user_pic3

                            },

                            new
                            {
                                Id = l_guid_user6,
                                Name=l_string_user_fullname6,
                                avarThumb=l_string_user_pic6
                            }
                        }),

                        RefreshTokens=new List<RefreshToken>
                        {
                            new RefreshToken
                            {
                                Id = l_guid_user_token5,
                                CreatedByIp = "127.0.0.1",
                                Expires = DateTime.UtcNow.AddDays(7),
                                Token = "93327224064839291389",
                                DateCreated = DateTime.Now,
                            }
                        },

                        Posts=new List<Post>
                        {
                            new Post
                            {
                                //Id = 11,
                                Content = "Xep Beach: A small beach with the length of only 500 meters, Xep Beach is a quiet place suitable for those seeking peace and tranquility during their trip. There are black stones lining along the beach, adding some sharpness to the softness of the ocean." +
                                "You can climb onto a hill nearby for a sweeping view of Xep Beach from above. This hill became popular to tourists as the place where the children from “I see yellow flowers on the green grass” flew kites. In real life, this place is a small meadow where the locals’ cows are herded. I did not see any yellow flower there though, unfortunately.",
                                ImageUri = l_string_post_pic11,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3
                                        },
                                        new
                                        {
                                            Id = l_guid_user6.ToString(),
                                            Name=l_string_user_fullname6
                                        }
                            
                            
                                    }
                                }),
                            
                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="haha"
                                    },
                                    new
                                    {
                                        Id = l_guid_user6.ToString(),
                                        Name=l_string_user_fullname6,
                                        avarThumb=l_string_user_pic6,
                                        Comment="You can climb onto a hill nearby for a sweeping view of Xep Beach from above"
                                    }
                                }),
                            
                                DateCreated = DateTime.Now,
                            },
                            
                            new Post
                            {
                                //Id = 12,
                                Content = "O Loan Lagoon: Since O Loan Lagoon is quite large, it’s not easy to identify the most picture-perfect corner to stop at. We rode along O Loan Lagoon under the heat of midday and stopped at a local seafood restaurant with a view of part of the lagoon. That view was not so impressive to be honest. Yet we had the chance to taste Blood Oyster: a must-try local cuisine.",
                                ImageUri = l_string_post_pic12,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3
                                        },
                                        new
                                        {
                                            Id = l_guid_user6.ToString(),
                                            Name=l_string_user_fullname6
                                        }
                            
                            
                                    }
                                }),
                            
                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="haha"
                                    },
                                    new
                                    {
                                        Id = l_guid_user6.ToString(),
                                        Name=l_string_user_fullname6,
                                        avarThumb=l_string_user_pic6,
                                        Comment="You can climb onto a hill nearby for a sweeping view of Xep Beach from above"
                                    }
                                }),
                            
                                DateCreated = DateTime.Now,
                            },
                            
                            new Post
                            {
                                //Id = 13,
                                Content = "Mui Dien Cape – the easternmost point of Vietnam’s territory: Theoretically speaking, Mui Dien Cape is the first location in Vietnam to receive sunlight for a new day. After climbing steps for around 30 minutes (slow pace), you will reach the foot of the Mui Dien Lighthouse. Climbing up to the lighthouse gives a stunning view of the sea below.",
                                ImageUri = l_string_post_pic13,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3
                                        },
                                        new
                                        {
                                            Id = l_guid_user6.ToString(),
                                            Name=l_string_user_fullname6
                                        }
                            
                            
                                    }
                                }),
                            
                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="haha"
                                    },
                                    new
                                    {
                                        Id = l_guid_user6.ToString(),
                                        Name=l_string_user_fullname6,
                                        avarThumb=l_string_user_pic6,
                                        Comment="You can climb onto a hill nearby for a sweeping view of Xep Beach from above"
                                    }
                                }),
                            
                                DateCreated = DateTime.Now,
                            },
                        }
                    },

                    //user6
                    //friends of user6, +{3,4,5}, -{1,2)
                    new User()
                    {
                        Id = l_guid_user6,
                        AccessFailedCount = 0,
                        BirthDay = new DateTime(1999, 12, 1),
                        DateResetTokenExpired = DateTime.UtcNow.AddDays(7),

                        Email = "gianghyn123456789@gmail.com",
                        PhoneNumber = "0123456789",
                        FirstName = "Dong",
                        LastName = "Khoi",
                        Gender = "Nam",
                        EmailConfirmed = false,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false,
                        Description = "No description",
                        Active = true,
                        Address = "Ho Chi Minh",
                        FollowMe = true,
                        Location = 111,
                        ViewListFriend = true,
                        ViewTimeLine = true,
                        Works = "Ho Chi Minh",
                        UserName = "user6",
                        Password = "123456",
                        PasswordHash = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("123456")).ToString(),
                        Role = Enums.ERole.User,

                        VerificationShortToken = null,
                        DateVerified = DateTime.UtcNow,

                        TwoFactorEnabled = false,

                        //list friend in json format
                        FriendsJsonString = JsonSerializer.Serialize(new List<object>
                        {
                            new
                            {
                                Id = l_guid_user3,
                                Name=l_string_user_fullname3,
                                avarThumb=l_string_user_pic3
                            },

                            new
                            {
                                Id = l_guid_user4,
                                Name=l_string_user_fullname4,
                                avarThumb=l_string_user_pic4
                            },

                            new
                            {
                                Id = l_guid_user5,
                                Name=l_string_user_fullname5,
                                avarThumb=l_string_user_pic5
                            }
                        }),

                        RefreshTokens=new List<RefreshToken>
                        {
                            new RefreshToken
                            {
                                Id = l_guid_user_token6,
                                CreatedByIp = "127.0.0.1",
                                Expires = DateTime.UtcNow.AddDays(7),
                                Token = "93327224064839291389",
                                DateCreated = DateTime.Now,
                            }
                        },

                        Posts = new List<Post>
                        {
                            new Post
                            {
                                //Id = 14,
                                Content = "Bai Mon Beach: Bai Mon Beach can be accessed from the entrance to Mui Dien area as well. You need to pay an entrance fee and also a parking fee (very cheap!). There are shower rooms near the entrance for you to change before walking 200 meters to the beach.",
                                ImageUri = l_string_post_pic14,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3
                                        },
                                        new
                                        {
                                            Id = l_guid_user4.ToString(),
                                            Name=l_string_user_fullname4
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="haha"
                                    },
                                    new
                                    {
                                        Id = l_guid_user4.ToString(),
                                        Name=l_string_user_fullname4,
                                        avarThumb=l_string_user_pic4,
                                        Comment="đẹp quá"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            },

                            new Post
                            {
                                //Id = 15,
                                Content = "What to eat in Phu Yen Candidate #1 – Chicken Rice (Com Ga)",
                                ImageUri = l_string_post_pic15,
                                LikeObjectsJson = JsonSerializer.Serialize(new
                                {
                                    count = 2,
                                    subjects = new List<object>
                                    {
                                        new
                                        {
                                            Id=l_guid_user3.ToString(),
                                            Name=l_string_user_fullname3
                                        },
                                        new
                                        {
                                            Id = l_guid_user4.ToString(),
                                            Name=l_string_user_fullname4
                                        }


                                    }
                                }),

                                CommentObjectsJson = JsonSerializer.Serialize(new List<object>
                                {
                                    new
                                    {
                                        Id=l_guid_user3.ToString(),
                                        Name=l_string_user_fullname3,
                                        avarThumb=l_string_user_pic3,
                                        Comment="Quê mình có bánh tráng nha"
                                    },
                                    new
                                    {
                                        Id = l_guid_user4.ToString(),
                                        Name=l_string_user_fullname4,
                                        avarThumb=l_string_user_pic4,
                                        Comment="Cơm gà là món mình rất thích"
                                    }
                                }),

                                DateCreated = DateTime.Now,
                            }
                        }
                    }
                });

            }
            projectDbContext.SaveChanges();
        }
    }
}
/*
 * reference: https://focusasiatravel.com/travel-to-phu-yen-everything-you-need-to-know/
 */