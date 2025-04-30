using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Database.Models;

namespace EnviromentalApp.Database.Data;
public class EnviromentalAppDbContext : DbContext
{

    public EnviromentalAppDbContext()
    { }
    public EnviromentalAppDbContext(DbContextOptions<EnviromentalAppDbContext> options) : base(options) { }

    public DbSet<AirQualityMeasurement> AirQualityMeasurements { get; set; }
    public DbSet<Sensor> Sensors { get; set; }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<WaterQualityMeasurement> WaterQualityMeasurements { get; set; }

    public DbSet<WeatherMeasurement> WeatherMeasurements { get; set; }

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
