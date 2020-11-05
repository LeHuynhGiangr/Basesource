using System.ComponentModel.DataAnnotations;

namespace Domain.DomainModels.API.RequestModels
{
    public class AuthenticateRequest
    {
        [Required]//not null/]
        public string Username { get; set; }
        [Required]//not null/
        public string Password { get; set; }
    }
}
