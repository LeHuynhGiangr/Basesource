using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class OTP : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int OTPcode { get; set; }
        public string MailAddress { get; set; }

    }
}
