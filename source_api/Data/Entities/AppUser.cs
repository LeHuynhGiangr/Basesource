/*
 * class for user entity
 */
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Data.Entities
{
    public class AppUser : IdentityUser<Guid>, IDateTracking
    {
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
