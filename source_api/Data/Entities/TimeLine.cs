using Data.Interfaces;
using System;


namespace Data.Entities
{
    public class TimeLine : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public byte[] Background { get; set; }
        public User User { get; set; }
    }
}
