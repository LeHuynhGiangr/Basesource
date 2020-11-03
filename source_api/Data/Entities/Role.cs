/*
 * class for role entity
 */
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Data.Entities
{
    public class Role : IdentityRole<System.Guid>, IDateTracking
    {
        //description role
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
