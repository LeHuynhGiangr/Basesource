using System;
using Data.Interfaces;

namespace Data.Entities
{
    public class UserMedia : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public byte[] MediaFile { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
