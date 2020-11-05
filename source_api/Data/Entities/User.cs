/*
 * class for user entity
 */
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    //principal entity/
    public class User : IdentityUser<Guid>, IEntity<Guid>, IDateTracking
    {
        //key/
        //inherit from IdentityUser<Guid>

        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        //collection navigation
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
