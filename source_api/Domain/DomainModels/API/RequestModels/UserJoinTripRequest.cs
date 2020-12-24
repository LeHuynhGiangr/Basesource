using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.RequestModels
{
    public class UserJoinTripRequest
    {
        public Guid TripId { get; set; }
        public bool Confirm { get; set; }
        public Guid UserId { get; set; }
    }
}
