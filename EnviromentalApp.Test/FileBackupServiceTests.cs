using EnviromentalApp.Database.Models;
using EnviromentalApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

public class FileBackupServiceTests
{
    [Fact]
    public void BackupToCsv_CreatesFileWithCorrectContent()
    {
        // Arrange
        var testPath = "test_backup.csv";
        var data = new List<AirQualityMeasurement>
        {
            new()
            {
                Date = new DateTime(2024, 01, 01),
                No2 = 12,
                So2 = 8,
                PM25 = 18,
                PM10 = 25
            }
        };

        // Act
        FileBackupService.BackupToCsv(data, testPath);

        // Assert
        Assert.True(File.Exists(testPath));

        var lines = File.ReadAllLines(testPath);
        Assert.Equal(2, lines.Length); // header + 1 data row
        Assert.Equal("Date,NO2,SO2,PM2.5,PM10", lines[0]);
        Assert.Contains("2024-01-01", lines[1]);

        // Cleanup
        File.Delete(testPath);
    }

    [Fact]
    public void RestoreFromCsv_ReadsDataCorrectly()
    {
        // Arrange
        var testPath = "test_restore.csv";
        File.WriteAllLines(testPath, new[]
        {
            "Date,NO2,SO2,PM2.5,PM10",
            "2024-01-01,12,8,18,25"
        });

        // Act
        var restored = FileBackupService.RestoreFromCsv(testPath);

        // Assert
        Assert.Single(restored);
        var record = restored[0];
        Assert.Equal(new DateTime(2024, 01, 01), record.Date);
        Assert.Equal(12, record.No2);
        Assert.Equal(8, record.So2);
        Assert.Equal(18, record.PM25);
        Assert.Equal(25, record.PM10);

        // Cleanup
        File.Delete(testPath);
    }

    [Fact]
    public void RestoreFromCsv_IgnoresInvalidRows()
    {
        // Arrange
        var testPath = "test_invalid.csv";
        File.WriteAllLines(testPath, new[]
        {
            "Date,NO2,SO2,PM2.5,PM10",
            "invalid,row,that,should,fail"
        });

        // Act
        var restored = FileBackupService.RestoreFromCsv(testPath);

        // Assert
        Assert.Empty(restored);

        // Cleanup
        File.Delete(testPath);
    }
}
