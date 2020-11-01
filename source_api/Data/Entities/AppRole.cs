/*
 * class for role entity
 */
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class AppRole : IdentityRole<System.Guid>
    {
        //description role
        public string Description { get; set; }
    }
}
