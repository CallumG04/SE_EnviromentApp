using Xunit;
using System;
using System.Collections.Generic;
using EnviromentalApp.Services;
using EnviromentalApp.Database.Models;

public class SensorDataValidatorTests
{
    [Fact]
    public void ValidateAirQualityData_ReturnsEmptyList_WhenDataIsValid()
    {
        var data = new List<AirQualityMeasurement>
        {
            new()
            {
                Date = DateTime.Now.AddDays(-1),
                No2 = 10, S02 = 5, PM25 = 12, PM10 = 20
            }
        };

        var result = SensorDataValidator.ValidateAirQualityData(data);
        Assert.Empty(result);
    }

    [Fact]
    public void ValidateAirQualityData_ReturnsIssues_ForNegativeValues()
    {
        var data = new List<AirQualityMeasurement>
        {
            new()
            {
                Date = DateTime.Now.AddDays(-1),
                No2 = -1, S02 = -5, PM25 = -10, PM10 = -20
            }
        };

        var result = SensorDataValidator.ValidateAirQualityData(data);

        Assert.Single(result);
        Assert.Contains("NO₂ value is negative.", result[0].Issues);
        Assert.Contains("SO₂ value is negative.", result[0].Issues);
        Assert.Contains("PM2.5 value is negative.", result[0].Issues);
        Assert.Contains("PM10 value is negative.", result[0].Issues);
    }

    [Fact]
    public void ValidateAirQualityData_ReturnsIssue_ForFutureDate()
    {
        var data = new List<AirQualityMeasurement>
        {
            new()
            {
                Date = DateTime.Now.AddDays(1),
                No2 = 10, S02 = 10, PM25 = 10, PM10 = 10
            }
        };

        var result = SensorDataValidator.ValidateAirQualityData(data);

        Assert.Single(result);
        Assert.Contains("Measurement date is in the future.", result[0].Issues);
    }

    [Fact]
    public void ValidateAirQualityData_ReturnsEmptyList_ForEmptyInput()
    {
        var result = SensorDataValidator.ValidateAirQualityData(new List<AirQualityMeasurement>());
        Assert.Empty(result);
    }
}
