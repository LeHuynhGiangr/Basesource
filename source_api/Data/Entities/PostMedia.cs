using System;
using Data.Interfaces;

namespace Data.Entities
{
    public class PostMedia : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public byte[] MediaFile { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
