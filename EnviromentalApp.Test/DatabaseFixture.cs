using Microsoft.EntityFrameworkCore;
using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;

namespace EnviromentalApp.Test;

public class DatabaseFixture 
{
    internal TestDbContext? _testDbContext { get; private set; }

    public DatabaseFixture()
    {
        _testDbContext = new TestDbContext();

        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Database.EnsureCreated();
        _testDbContext.Database.OpenConnection();
        _testDbContext.Database.Migrate();
    }

    internal void Sensor() {
        var sensor = new Database.Models.Sensor();
        sensor.Date = DateTime.Now;
        sensor.Type = "Air Quality";
        sensor.Position = "Edinburgh Main St";
        sensor.Status = "Online";
        sensor.Name = "Airly Test";
        sensor.firmwareVersion = "V1.001";
        sensor.measurementFrequency = "Daily";
        sensor.Threshold = 122;

        _testDbContext.Add(sensor);
        _testDbContext.SaveChanges();

    }

    
    internal void User() {
        var user = new Database.Models.User();
        user.Username = "John Test";
        user.Password = "superSecure111";
        user.Role = "Administrator";

        _testDbContext.Add(user);
        _testDbContext.SaveChanges();

    }

    internal void Ticket() {
        var ticket = new Database.Models.Ticket();
        ticket.sensorId = 1;
        ticket.Description = "Fault with sensor not recoridng any data";
        ticket.ticketDate = DateTime.Now;
        ticket.Status = "Open";

        _testDbContext.Add(ticket);
        _testDbContext.SaveChanges();

    }



}