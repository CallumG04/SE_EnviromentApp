using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Models;

namespace EnviromentalApp.Data;
public class AirQualityMeasurementDbContext : DbContext
{

    public AirQualityMeasurementDbContext()
    { }
    public AirQualityMeasurementDbContext(DbContextOptions<AirQualityMeasurementDbContext> options) : base(options) { }

    public DbSet<AirQualityMeasurement> AirQualityMeasurements { get; set; }

}
