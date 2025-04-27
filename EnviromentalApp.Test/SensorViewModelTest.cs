using Xunit;
using EnviromentalApp.Models;
    
namespace EnviromentalApp.Test;
    
public class SensorViewModelTests
{
    [Fact]
    public void Save_NewSensor_ShouldCreateDatabaseRecord() {
    
        // Arrange
        var sensor = new Sensor();
        sensor.Date = DateTime.Now;
        sensor.Type = "Air Quality";
        sensor.Position = "Edinburgh Main Street";
        sensor.Status = "Online";
        sensor.Name = "Airly1";
        sensor.firmwareVersion = "V1.0.1";
        sensor.measurementFrequency = "Daily";
        sensor.Threshold = 122;
    
        // Act
    
        // Assert
    }

    public void Update_UpdateSensor_ShouldUpdateDatabaseRecord() {
    
        // Arrange
        var sensor = new Sensor();
        sensor.Date = DateTime.Now;
        sensor.Type = "Air Quality";
        sensor.Position = "Edinburgh Main Street";
        sensor.Status = "Online";
        sensor.Name = "Airly1";
        sensor.firmwareVersion = "V1.0.1";
        sensor.measurementFrequency = "Daily";
        sensor.Threshold = 122;
    
        // Act
    
        // Assert
    }

    public void Delete_DeleteSensor_ShouldDeleteDatabaseRecord() {
    
        // Arrange
        var sensor = new Sensor();
        sensor.Date = DateTime.Now;
        sensor.Type = "Air Quality";
        sensor.Position = "Edinburgh Main Street";
        sensor.Status = "Online";
        sensor.Name = "Airly1";
        sensor.firmwareVersion = "V1.0.1";
        sensor.measurementFrequency = "Daily";
        sensor.Threshold = 122;
    
        // Act
    
        // Assert
    }
}
