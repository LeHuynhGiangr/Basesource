using Data.Interfaces;
using System;


namespace Data.Entities
{
    public class TimeLine : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public byte[] Background { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
