using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class UserJoinTrip : IDateTracking
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
    //    [ForeignKey("User")]

        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
//        [ForeignKey("Trip")]

        public bool Confirmed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
