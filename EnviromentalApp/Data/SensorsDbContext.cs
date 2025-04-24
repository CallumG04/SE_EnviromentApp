using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Models;

namespace EnviromentalApp.Data;
public class SensorsDbContext : DbContext
{

    public SensorsDbContext()
    { }
    public SensorsDbContext(DbContextOptions<SensorsDbContext> options) : base(options) { }

    public DbSet<Sensor> Sensors { get; set; }

}
