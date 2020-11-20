using Data.Interfaces;
using System;

namespace Data.Entities
{
    public class TripMedia : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public byte[] MediaFile { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Trip Trip { get; set; }
        public User User { get; set; }
    }
}
