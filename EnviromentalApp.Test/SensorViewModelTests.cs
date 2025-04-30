using Xunit;
//using EnviromentalApp.Database.Models;
    
namespace EnviromentalApp.Test;

public class SensorViewModelTests : IClassFixture<DatabaseFixture>
{
    DatabaseFixture _fixture;

    /*
    public SensorViewModelTests(DatabaseFixture fixture) {
        _fixture = fixture;
        _fixture.Seed();
    }

    [Fact]
    public void Save_NewSensor_ShouldCreateDatabaseRecord() {
    
        // Arrange
        var sensor = new Sensor();
        sensor.Date = DateTime.Now;
        sensor.Type = "Air Quality";
        sensor.Position = "Edinburgh High Street";
        sensor.Status = "Online";
        sensor.Name = "Airly Best";
        sensor.firmwareVersion = "V1.002";
        sensor.measurementFrequency = "Daily";
        sensor.Threshold = 122;
            
        // Act
        _fixture._testDbContext.Add(sensor);
        _fixture._testDbContext.SaveChanges();
        sensor.sensorId = 1;
    
        // Assert
        Assert.NotEqual(sensor.sensorId, 0);
    }

    public void Update_UpdatingSensor_ShouldUpdateDatabaseRecord() {
    
        // Arrange
        var sensor = new Sensor();
        sensor.Date = DateTime.Now;
        sensor.Type = "Air Quality";
        sensor.Position = "Edinburgh High Street";
        sensor.Status = "Online";
        sensor.Name = "Airly Best";
        sensor.firmwareVersion = "V1.002";
        sensor.measurementFrequency = "Daily";
        sensor.Threshold = 122;
            
        // Act
        _fixture._testDbContext.Add(sensor);
        _fixture._testDbContext.SaveChanges();
        sensor.sensorId = 1;
    
        // Assert
        Assert.NotEqual(sensor.sensorId, 0);
    }

    public void Delete_DeletingSensor_ShouldDeletesDatabaseRecord() {
    
        // Arrange
        var sensor = new Sensor();
        sensor.Date = DateTime.Now;
        sensor.Type = "Air Quality";
        sensor.Position = "Edinburgh High Street";
        sensor.Status = "Online";
        sensor.Name = "Airly Best";
        sensor.firmwareVersion = "V1.002";
        sensor.measurementFrequency = "Daily";
        sensor.Threshold = 122;
            
        // Act
        _fixture._testDbContext.Add(sensor);
        _fixture._testDbContext.SaveChanges();
        sensor.sensorId = 1;
    
        // Assert
        Assert.NotEqual(sensor.sensorId, 0);
    }
*/
    
}