using DefaultWPFBlueprint.Models;
using Microsoft.EntityFrameworkCore;

namespace DefaultWPFBlueprint.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=data.db");
    }
}