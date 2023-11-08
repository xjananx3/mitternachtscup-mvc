using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Spiel> Spiele { get; set; }
    public DbSet<Ergebnis> Ergebnisse { get; set; }
    
}