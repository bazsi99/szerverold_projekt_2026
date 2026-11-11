using Microsoft.EntityFrameworkCore;
using ReceptApi.Models;

namespace ReceptApi.Data
{
    public class ReceptContext : DbContext
    {
        public ReceptContext(DbContextOptions<ReceptContext> options) : base(options) { }

        public DbSet<Recept> Receptek { get; set; }
        public DbSet<Hozzavalo> Hozzavalok { get; set; }
        public DbSet<ReceptHozzavalo> ReceptHozzavalok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceptHozzavalo>()
                .HasKey(x => new { x.ReceptId, x.HozzavaloId });

            modelBuilder.Entity<ReceptHozzavalo>()
                .HasOne<Recept>().WithMany(r => r.Hozzavalok).HasForeignKey(x => x.ReceptId);

            modelBuilder.Entity<ReceptHozzavalo>()
                .HasOne(x => x.Hozzavalo).WithMany().HasForeignKey(x => x.HozzavaloId);
        }
    }
}