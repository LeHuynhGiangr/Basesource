using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Email: IEntity<int>, IDateTracking
    {
        [Key]
        public int Id { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
