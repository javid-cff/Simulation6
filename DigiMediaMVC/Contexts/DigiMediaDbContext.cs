using DigiMediaMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigiMediaMVC.Contexts
{
    public class DigiMediaDbContext : IdentityDbContext<AppUser>
    {
        public DigiMediaDbContext(DbContextOptions<DigiMediaDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
    }
}
