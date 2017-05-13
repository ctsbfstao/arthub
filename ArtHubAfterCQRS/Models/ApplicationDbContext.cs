using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArtHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<ExhibitType> ExhibitTypes { get; set; }

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