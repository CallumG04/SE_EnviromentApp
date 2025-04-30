using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnviromentalApp.Database.Models;

[Table("AirQualityMeasurements")]
[PrimaryKey(nameof(Id))]
public class AirQualityMeasurement
{
    public int Id { get; set; }
    public int sensorId { get; set; }
    public DateTime Date { get; set; }
    public double No2 { get; set; }
    public double S02 { get; set; }
    public double PM25 { get; set; }
    public double PM10 { get; set; }

}