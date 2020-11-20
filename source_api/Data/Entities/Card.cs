using Data.Interfaces;
using System;


namespace Data.Entities
{
    public class Card : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public double Balance { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public User User { get; set; }
    }
}
