using Microsoft.EntityFrameworkCore;
using ReceptApi.Models;

namespace ReceptApi.Data
{
    public class ReceptContext : DbContext
    {
        public ReceptContext(DbContextOptions<ReceptContext> options) : base(options) { }
        
        public DbSet<Foetel> Foetelek { get; set; }
        public DbSet<Leves> Levesek { get; set; }
        public DbSet<Desszert> Desszertek { get; set; }
    }
}