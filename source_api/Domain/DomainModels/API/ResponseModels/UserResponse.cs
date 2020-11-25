using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.ResponseModels
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public float Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Works { get; set; }
        public bool Active { get; set; }
        public byte[] Avatar { get; set; }
        public byte[] Background { get; set; }
        public bool FollowMe { get; set; }
        public bool RequestFriend { get; set; }
        public bool ViewListFriend { get; set; }
        public bool ViewTimeLine { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsVerified { get; set; }
    }
}
