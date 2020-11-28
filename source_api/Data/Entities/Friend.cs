using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Friend
    {
        public Guid User1 { get; set; }//temp
        public virtual User User1s { get; set; }
        public bool Confirm { get; set; }
        public Guid User2 { get; set; }//temp
        public virtual User User2s { get; set; }
    }
}
