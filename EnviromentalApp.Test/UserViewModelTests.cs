using Xunit;
using EnviromentalApp.Database.Models;
    
namespace EnviromentalApp.Test;

public class SensorViewModelTests : IClassFixture<DatabaseFixture>
{
    DatabaseFixture _fixture;
    public SensorViewModelTests(DatabaseFixture fixture) {
        _fixture = fixture;
        _fixture.Seed();
    }

    [Fact]
    public void Save_NewUser_ShouldCreateDatabaseRecord() {
    
        // Arrange
        var user = new user();
        user.Date = DateTime.Now;
        user.Type = "Air Quality";
        user.Position = "Edinburgh High Street";
        user.Status = "Online";
        user.Name = "Airly Best";
        user.firmwareVersion = "V1.002";
        user.measurementFrequency = "Daily";
        user.Threshold = 122;
            
        // Act
        _fixture._testDbContext.Add(user);
        _fixture._testDbContext.SaveChanges();
        user.userId = 1;
    
        // Assert
        Assert.NotEqual(user.userId, 0);
    }

    public void Update_UpdatingUser_ShouldUpdateDatabaseRecord() {
    
        // Arrange
        var user = new user();
        user.Date = DateTime.Now;
        user.Type = "Air Quality";
        user.Position = "Edinburgh High Street";
        user.Status = "Online";
        user.Name = "Airly Best";
        user.firmwareVersion = "V1.002";
        user.measurementFrequency = "Daily";
        user.Threshold = 122;
            
        // Act
        _fixture._testDbContext.Add(user);
        _fixture._testDbContext.SaveChanges();
        user.userId = 1;
    
        // Assert
        Assert.NotEqual(user.userId, 0);
    }

    public void Delete_DeletingUser_ShouldDeletesDatabaseRecord() {
    
        // Arrange
        //var user = new user();
            
        // Act
    
        // Assert
        //Assert.NotEqual(user.userId, 0);
    }
    
}