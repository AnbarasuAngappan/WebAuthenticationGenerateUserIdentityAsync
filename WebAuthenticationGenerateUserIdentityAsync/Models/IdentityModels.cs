using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebAuthenticationGenerateUserIdentityAsync.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //ClaimsIdentity claimsIdentity = userIdentity as ClaimsIdentity;
            //Claim claim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

            userIdentity.AddClaim(new Claim(ClaimTypes.Name, UserName));
            // Add custom user claims here
            return userIdentity;
        }
    }

    //public string GetName(this IIdentity identity)
    //{
    //    ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
    //    Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Name);

    //    return claim?.Value ?? string.Empty;
    //}

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