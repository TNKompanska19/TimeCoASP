using Microsoft.AspNetCore.Identity;

namespace TimeCo.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional custom properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
