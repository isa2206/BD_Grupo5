using apiwithdb.Models;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Data
{
    public class AppDbContextGuests : DbContext
    {
        public AppDbContextGuests(DbContextOptions<AppDbContextGuests> options) : base(options) { }

        public DbSet<Guest> Guests => Set<Guest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(g =>
            {
                g.HasKey(x => x.Id);
                g.Property(x => x.FullName).IsRequired().HasMaxLength(100);
                g.Property(x => x.Confirmed);
            });
        }
    }
}