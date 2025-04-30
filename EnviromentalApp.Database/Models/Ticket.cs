using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnviromentalApp.Database.Models;

[Table("SensorTicket")]
[PrimaryKey(nameof(ticketId))]
public class Ticket
{
    public int ticketId { get; set; }
    [Required]
    public int sensorId { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime ticketDate { get; set; }
    public string Status { get; set; }
}