using Data.Interfaces;
using System;

namespace Data.Entities
{
    public class Post : IEntity<Guid>, IDateTracking
    {
        public Post() { }
        //constructor for create new post
        public Post(Guid id, string content, string imageData, Guid userId)
        {
            Id = id;
            Content = content;
            ImageUri = imageData;
            UserId = userId;
        }
        public Guid Id { get; set; }

        public string Content { get; set; }
        //public int Likes { get; set; }
        public string ImageUri { get; set; }
        public string LikeObjectsJson { get; set; }
        public string CommentObjectsJson { get; set; }
        //public bool Active { get; set; }
        //public string Privacy { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        //reference navigation
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
