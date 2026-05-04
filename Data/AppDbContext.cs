using Microsoft.EntityFrameworkCore;
using ValeAtivos324123036.Models;

namespace ValeAtivos324123036.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Equipamento> Equipamentos { get; set; }
    }
}
