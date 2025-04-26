using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Models;

namespace EnviromentalApp.Data;
public class WaterQualityMeasurementDbContext : DbContext
{

    public WaterQualityMeasurementDbContext()
    { }
    public WaterQualityMeasurementDbContext(DbContextOptions<WaterQualityMeasurementDbContext> options) : base(options) { }

    public DbSet<WaterQualityMeasurement> WaterQualityMeasurements { get; set; }

}
