using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Chatting : IEntity<Guid>, IDateTracking
    {
        public Guid Id {get; set; }

        public string ChatMessagesJson { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
