using Data.Interfaces;
using System;


namespace Data.Entities
{
    public class ReviewTrip : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public User User { get; set; }
        public Trip Trip { get; set; }
    }
}
