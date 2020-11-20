using Data.Interfaces;
using System;


namespace Data.Entities
{
    public class PostComment : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
