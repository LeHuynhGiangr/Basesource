using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.RequestModels
{
    public class CreatePostRequest
    {
        public string UserId { get; set; }
        public string Status { get; set; }
        public string Base64Str { get; set; }
    }
}
