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
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Works { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public byte[] Background { get; set; }
        [Required]
        public bool FollowMe { get; set; }
        [Required]
        public bool RequestFriend { get; set; }
        [Required]
        public bool ViewListFriend { get; set; }
        [Required]
        public bool ViewTimeLine { get; set; }
        [Required]
        public byte[] Avatar { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
