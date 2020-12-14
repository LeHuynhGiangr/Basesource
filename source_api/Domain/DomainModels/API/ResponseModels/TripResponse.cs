using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.ResponseModels
{
    public class TripResponse
    {
        public TripResponse() { }
        public TripResponse(Guid id, System.DateTime dateCreated, string content, string authorId,
            byte?[] image = null)
        {
            Id = id;
            DateCreated = dateCreated;
            Description = content;
            AuthorId = authorId;
            Image = image;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Location { get; set; }
        public byte?[] Image { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string AuthorId { get; set; }
    }
}
