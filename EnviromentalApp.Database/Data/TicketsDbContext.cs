using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Database.Models;

namespace EnviromentalApp.Database.Data;
public class TicketsDbContext : DbContext
{

    public TicketsDbContext()
    { }
    public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options) { }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     var a = Assembly.GetExecutingAssembly();
     var resources = a.GetManifestResourceNames();
     using var stream = a.GetManifestResourceStream("EnviromentalApp.Database.appsettings.json");
    
     var config = new ConfigurationBuilder()
         .AddJsonStream(stream)
         .Build();
    
     optionsBuilder.UseSqlServer(
         config.GetConnectionString("DevelopmentConnection"),
         m => m.MigrationsAssembly("EnviromentalApp.Migrations")
     );
 }

}