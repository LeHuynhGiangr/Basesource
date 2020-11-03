/*
 * class for user entity
 */
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Data.Entities
{
    public class User : IdentityUser<Guid>, IDateTracking
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
