using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.ResponseModels
{
    public class PageResponse
    {
        public PageResponse() { }
        public PageResponse(Guid id, System.DateTime dateCreated, string name, string avatar, string background, string description,double follow,string userId)
        {
            Id = id;
            DateCreated = dateCreated;
            Name = name;
            Avatar = avatar;
            Backgound = background;
            Description = description;
            Follow = follow;
            UserId = userId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public double Follow { get; set; }
        public string Backgound { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserId { get; set; }
    }
}
