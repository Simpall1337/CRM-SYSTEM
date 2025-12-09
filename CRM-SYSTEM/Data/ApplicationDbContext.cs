using Microsoft.EntityFrameworkCore;
using System.Data;
using CRM_SYSTEM.Models;

namespace CRM_SYSTEM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Clients> Clients { get; set; }
    }
}
