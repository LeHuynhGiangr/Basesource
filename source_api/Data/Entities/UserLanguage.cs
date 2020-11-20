using Data.Interfaces;
using System;

namespace Data.Entities
{
    public class UserLanguage : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public User User { get; set; }
    }
}
