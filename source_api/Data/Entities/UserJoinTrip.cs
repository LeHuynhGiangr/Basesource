using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class UserJoinTrip : IEntity<Guid>,IDateTracking
    {
        [ForeignKey("UserId"), Column(Order = 0)]
        public Guid Id { get; set; }
        public User User { get; set; }
        [ForeignKey("TripId"), Column(Order = 1)]
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }

        public bool Confirmed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        
    }
}
