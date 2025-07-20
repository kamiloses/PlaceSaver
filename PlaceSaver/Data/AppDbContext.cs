using Microsoft.EntityFrameworkCore;
using PlaceSaver.Entities;

namespace PlaceSaver.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    
   // public DbSet<Address> Addresses { get; set; }
    
    
}