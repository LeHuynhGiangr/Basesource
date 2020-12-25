using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.ResponseModels
{
    public class UserJoinTripResponse
    {
        public UserJoinTripResponse() { }
        public UserJoinTripResponse(Guid uid, System.DateTime dateCreated, bool confirm, Guid tid)
        {
            UserId = uid;
            DateCreated = dateCreated;
            Confirm = confirm;
            TripId = tid;
        }
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }
        public bool Confirm { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
