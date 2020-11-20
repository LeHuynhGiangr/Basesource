using Data.Interfaces;
using System;

namespace Data.Entities
{
    public class RefreshToken: IEntity<Guid>, IDateTracking
    {
        //properties/
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime DateCreated { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
        public DateTime? DateModified { get; set; }

        ////foreign key/
        //public Guid UserId { get; set; }

        //navigation/
        public virtual User User { get; set; }
    }
}
