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

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<StatusOrder> StatusOrder { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
