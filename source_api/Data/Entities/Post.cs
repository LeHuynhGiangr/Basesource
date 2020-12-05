using Data.Interfaces;
using System;

namespace Data.Entities
{
    public class Post : IEntity<int>, IDateTracking
    {
        public int Id { get; set; }

        public string Content { get; set; }
        //public int Likes { get; set; }
        public byte[] ImageUri { get; set; }
        public string LikeObjectsJson { get; set; }
        public string CommentObjectsJson { get; set; }
        //public bool Active { get; set; }
        //public string Privacy { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        //reference navigation
        public User User { get; set; }
    }
}
