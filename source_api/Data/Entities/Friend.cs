using Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Friend:IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }

        //json string, storing list of friends
        public string FriendsJsonString { get; set; }

        //reference navigation
        public User User { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
