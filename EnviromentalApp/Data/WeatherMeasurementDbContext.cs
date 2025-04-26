using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Models;

namespace EnviromentalApp.Data;
public class WeatherMeasurementDbContext : DbContext
{

    public WeatherMeasurementDbContext()
    { }
    public WeatherMeasurementDbContext(DbContextOptions<WeatherMeasurementDbContext> options) : base(options) { }

    public DbSet<WeatherMeasurement> WeatherMeasurements { get; set; }

}
