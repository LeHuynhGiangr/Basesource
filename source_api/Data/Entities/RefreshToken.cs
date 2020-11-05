using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text.Json.Serialization;

namespace Data.Entities
{
    public class RefreshToken:IdentityUserToken<Guid>, IEntity<Guid>, IDateTracking
    {
        //key/
        [JsonIgnore]
        public Guid Id { get; set; }

        //properties/
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime DateCreated { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
        public DateTime DateModified { get; set; }

        ////foreign key/
        //public Guid UserId { get; set; }

        //navigation/
        public User User { get; set; }
    }
}
