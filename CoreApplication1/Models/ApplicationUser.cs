using Microsoft.AspNetCore.Identity;

namespace CoreApplication1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }


    }
}
