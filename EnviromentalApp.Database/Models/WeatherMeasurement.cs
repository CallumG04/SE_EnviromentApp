using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnviromentalApp.Database.Models;

[Table("WeatherMeasurements")]
[PrimaryKey(nameof(Id))]
public class WeatherMeasurement
{
    public int Id { get; set; }
    public int sensorId { get; set; }
    public DateTime Date { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double windSpeed { get; set; }
    public int windDirection { get; set; }

}