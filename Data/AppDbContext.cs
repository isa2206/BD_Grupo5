using apiwithdb.Models;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Book> books => Set<Book>();

        public DbSet<Event> _events => Set<Event>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired().HasMaxLength(200);
                b.Property(x => x.Year).IsRequired();
            });

            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).IsRequired().HasMaxLength(200);
                e.Property(x => x.Date).IsRequired();
                e.Property(x => x.Capacity).IsRequired();
            });
        }
    }
}
