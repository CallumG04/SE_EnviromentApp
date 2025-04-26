using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnviromentalApp.Models;

[Table("WaterQualityMeasurements")]
[PrimaryKey(nameof(Id))]
public class WaterQualityMeasurement
{
    public int Id { get; set; }
    public int sensorId { get; set; }
    public DateTime Date { get; set; }
    public double NitrateN03 { get; set; }
    public double NitrateN02 { get; set; }
    public double Phosphate { get; set; }
    public double EC { get; set; }
    public double IE { get; set; }

}