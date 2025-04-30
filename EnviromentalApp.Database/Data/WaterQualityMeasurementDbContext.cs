using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Database.Models;

namespace EnviromentalApp.Database.Data;
public class WaterQualityMeasurementDbContext : DbContext
{

    public WaterQualityMeasurementDbContext()
    { }
    public WaterQualityMeasurementDbContext(DbContextOptions<WaterQualityMeasurementDbContext> options) : base(options) { }

    public DbSet<WaterQualityMeasurement> WaterQualityMeasurements { get; set; }

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
