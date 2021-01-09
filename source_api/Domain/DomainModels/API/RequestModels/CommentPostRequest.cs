using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.RequestModels
{
    public class CommentPostRequest
    {
        public string PostId { get; set; }
        public string Comment { get; set; }
    }
}
