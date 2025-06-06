using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnviromentalApp.Database.Models;

[Table("Sensor")]
[PrimaryKey(nameof(sensorId))]
public class Sensor
{
    public int sensorId { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public string Position { get; set; }

    public string Status {get; set;}

    public string Name {get; set;}

    public string firmwareVersion {get; set;}

    public string measurementFrequency {get; set;}

    public int Threshold {get; set;}
}