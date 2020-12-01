using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DomainModels.API.RequestModels
{
    public class UpdateInterestRequest
    {
        [Required]
        public string Hobby { get; set; }
        [Required]
        public string Language { get; set; }
    }
}
