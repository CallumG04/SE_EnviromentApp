using Xunit;
using System.Collections.Generic;
using System.IO;
using System;

public class ReportExporterTests
{
    [Fact]
    public void ExportToCsv_CreatesCorrectFileContent()
    {
        // Arrange
        var report = new List<AirQualityReporter.DailyAverageReport>
        {
            new() { Date = new DateTime(2024, 01, 01), AvgNo2 = 10, AvgSO2 = 20, AvgPM25 = 30, AvgPM10 = 40 }
        };

        var path = "test_output.csv";

        // Act
        ReportExporter.ExportToCsv(report, path);

        // Assert
        Assert.True(File.Exists(path));

        var content = File.ReadAllText(path);
        Assert.Contains("Date,AvgNo2,AvgSO2,AvgPM2.5,AvgPM10", content);
        Assert.Contains("2024-01-01,10.00,20.00,30.00,40.00", content);

        // Cleanup
        File.Delete(path);
    }
}
