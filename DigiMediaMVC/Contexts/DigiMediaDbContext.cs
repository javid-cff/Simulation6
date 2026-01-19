using DigiMediaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiMediaMVC.Contexts
{
    public class DigiMediaDbContext : DbContext
    {
        public DigiMediaDbContext(DbContextOptions<DigiMediaDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
    }
}
