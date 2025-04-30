using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using EnviromentalApp.Database.Models;

namespace EnviromentalApp.Database.Data
{
    public abstract class GenericDbContext : DbContext
    {
        internal abstract string connectionName { get; set; }

        public GenericDbContext() { }

        protected GenericDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AirQualityMeasurement> AirQualityMeasurements { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WaterQualityMeasurement> WaterQualityMeasurements { get; set; }
        public DbSet<WeatherMeasurement> WeatherMeasurements { get; set; }

    }

    public class EnviromentalAppDbContext : GenericDbContext
    {
        internal override string connectionName { get; set; } = "DevelopmentConnection";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("EnviromentalApp.Database.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            optionsBuilder.UseSqlServer(
                config.GetConnectionString(connectionName),
                m => m.MigrationsAssembly("EnviromentalApp.Migrations")
            );
        }
    }

    public class TestDbContext : GenericDbContext
    {
        internal override string connectionName { get; set; } = "TestConnection";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("EnviromentalApp.Database.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            optionsBuilder.UseSqlServer(
                config.GetConnectionString(connectionName),
                m => m.MigrationsAssembly("EnviromentalApp.Migrations")
            );
        }
    }
}
