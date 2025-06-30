using Microsoft.AspNetCore.Identity;

namespace RetailEcommerce.Domain.Models
{
    public class AppUser :  IdentityUser
    {
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
