/*
 * class for user entity
 */
using Data.Enums;
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public string Gender { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public DateTime? DateVerified { get; set; }

        public string VerificationShortToken { get; set; }
        public string ResetToken { get; set; }
        public DateTime? DateResetTokenExpired { get; set; }

        //Reference navigation
        //public Role Role { get; set; }
        public ERole Role { get; set; }

        //collection navigation
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        //method
        public bool IsRefreshTokenOwned(string token)
        {
            /*
             * The Find method on DbSet uses the primary key value to attempt to find an entity tracked by the context. 
             * If the entity is not found in the context then a query will be sent to the database to find the entity there. 
             * Null is returned if the entity is not found in the context or in the database. 
             */
            return this.RefreshTokens?.Single(_ => _.Token == token) != null;
        }
    }
}
