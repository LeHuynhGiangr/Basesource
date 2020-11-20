using Data.Interfaces;
using System;


namespace Data.Entities
{
    public class UserAcademic : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public string AcademicLevel { get; set; }
        public string StudyingAt { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public User User { get; set; }
    }
}
