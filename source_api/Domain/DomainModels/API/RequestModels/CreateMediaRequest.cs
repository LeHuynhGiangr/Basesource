using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.RequestModels
{
    public class CreateMediaRequest
    {
        public byte[] MediaFile { get; set; }
        public Guid UserId { get; set; }
    }
}
