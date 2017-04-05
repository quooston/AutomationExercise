using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SampleWebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [MinLength(2, ErrorMessage = "First Name is too short")]
        [MaxLength(30, ErrorMessage = "First Name is too long")]
        [RegularExpression("^([A-Za-z0-9]+([ ._][A-Za-z0-9]+)*)$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Last Name too short")]
        [MaxLength(30, ErrorMessage = "Last Name too long")]
        [RegularExpression("^([A-Za-z0-9]+([ ._][A-Za-z0-9]+)*)$", ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Username is too short")]
        [MaxLength(76, ErrorMessage = "Username is too long")]
        [RegularExpression("^[A-Za-z0-9\\._%+-]+\\@[A-Za-z0-9\\.-]+(\\.[A-Za-z]+)+$", ErrorMessage = "Invalid Email format")]
        public override string Email { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}