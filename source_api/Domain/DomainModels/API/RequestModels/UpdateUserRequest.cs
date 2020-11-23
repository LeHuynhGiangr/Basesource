using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DomainModels.API.RequestModels
{
    public class UpdateUserRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Location { get; set; }
        [Required]
        public string Works { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool FollowMe { get; set; }
        [Required]
        public bool RequestFriend { get; set; }
        [Required]
        public bool ViewListFriend { get; set; }
        [Required]
        public bool ViewTimeLine { get; set; }
    }
}
