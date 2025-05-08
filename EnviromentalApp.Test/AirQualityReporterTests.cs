using Xunit;
using System;
using System.Collections.Generic;
using EnviromentalApp.Database.Models;
using System.Linq;

public class AirQualityReporterTests
{
    [Fact]
    public void GenerateDailyAverages_ReturnsCorrectAverages()
    {
        // Arrange
        var measurements = new List<AirQualityMeasurement>
        {
            new() { Date = new DateTime(2024, 01, 01), No2 = 10, S02 = 20, PM25 = 30, PM10 = 40 },
            new() { Date = new DateTime(2024, 01, 01), No2 = 20, S02 = 30, PM25 = 40, PM10 = 50 },
            new() { Date = new DateTime(2024, 01, 02), No2 = 15, S02 = 25, PM25 = 35, PM10 = 45 }
        };

        // Act
        var report = AirQualityReporter.GenerateDailyAverages(measurements);

        // Assert
        Assert.Equal(2, report.Count);

        var day1 = report.First(r => r.Date == new DateTime(2024, 01, 01));
        Assert.Equal(15, day1.AvgNo2);
        Assert.Equal(25, day1.AvgSO2);
        Assert.Equal(35, day1.AvgPM25);
        Assert.Equal(45, day1.AvgPM10);

        var day2 = report.First(r => r.Date == new DateTime(2024, 01, 02));
        Assert.Equal(15, day2.AvgNo2);
        Assert.Equal(25, day2.AvgSO2);
        Assert.Equal(35, day2.AvgPM25);
        Assert.Equal(45, day2.AvgPM10);
    }

    [Fact]
    public void GenerateDailyAverages_WithEmptyList_ReturnsEmpty()
    {
        // Arrange
        var measurements = new List<AirQualityMeasurement>();

        // Act
        var report = AirQualityReporter.GenerateDailyAverages(measurements);

        // Assert
        Assert.Empty(report);
    }
}
