using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.RequestModels
{
    public class CreateMediaRequest
    {
        public IFormFile MediaFile { get; set; }
        public Guid UserId { get; set; }
    }
}
