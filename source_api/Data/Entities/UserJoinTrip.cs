using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class UserJoinTrip : IEntity<Guid>,IDateTracking
    {
        [Key]
        public Guid Id { get; set; }
        public User User { get; set; }

        public Guid UserId { get; set; }

        public Trip Trip { get; set; }

        public Guid TripId { get; set; }

        public bool Confirmed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        
    }
}
