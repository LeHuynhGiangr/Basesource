using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class UserJoinTrip : IEntity<Guid>, IDateTracking
    {
        public User User { get; set; }
        [ForeignKey("User")]
        public Guid Id { get; set; }

        public Trip Trip { get; set; }
        [ForeignKey("Trip")]
        public Guid Id2 { get; set; }

        public bool Confirmed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
