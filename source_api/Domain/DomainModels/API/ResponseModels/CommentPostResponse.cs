using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.ResponseModels
{
    public class CommentPostResponse
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string AvarUrl { get; set; }
        public string Comment { get; set; }
    }
}
