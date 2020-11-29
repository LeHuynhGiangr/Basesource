using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Friend:IEntity<int>
    {
        //public Guid Id { get; set; }//temp
        public int Id { get; set; }
        public Guid FriendId { get; set; }
        //reference navigation/
        public virtual User User { get; set; }
        
    }
}
