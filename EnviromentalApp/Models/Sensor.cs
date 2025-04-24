using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnviromentalApp.Models

{
// [Table("note")]
// [PrimaryKey(nameof(Id))]
    public class Sensor
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Position { get; set; }
        public SensorStatus Status { get; set; }
    }

    public enum SensorStatus
    {
            Online,
            Offline,
            NeedsCalibration,
            MaintenanceDue
    }

}