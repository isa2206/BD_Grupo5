using apiwithdb.Models;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Data
{
    public class AppDbContextTickets : DbContext
    {
        public AppDbContextTickets(DbContextOptions<AppDbContextTickets> options) : base(options) { }

        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(t =>
            {
                t.HasKey(x => x.Id);
                t.Property(x => x.Notes)
                    .HasColumnType("text[]")  
                    .IsRequired(false);
            });
        }
    }
}
