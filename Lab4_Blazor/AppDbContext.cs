using Microsoft.EntityFrameworkCore;
using Lab4_Blazor.Models;

namespace Lab4_Blazor
{
    public class AppDbContext : DbContext
    {
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Funds> Funds { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}