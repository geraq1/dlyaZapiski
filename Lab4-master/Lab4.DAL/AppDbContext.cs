using Lab4.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Appointment> Appointment { get; set; } = null!;
        public DbSet<Staff> Staff { get; set; } = null!;
        public DbSet<Service> Service { get; set; } = null!;
        public DbSet<Salon> Salon { get; set; } = null!;
        public DbSet<Client> Client { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;


    }
}
