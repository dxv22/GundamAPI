using Microsoft.EntityFrameworkCore;

namespace GundamAPI.Models
{
    public class GundamContext : DbContext
    {
        public GundamContext(DbContextOptions<GundamContext> options) : base(options)
        { 
        
        }

        public DbSet<Gundam> Gundams { get; set; } = null;
    }
}
