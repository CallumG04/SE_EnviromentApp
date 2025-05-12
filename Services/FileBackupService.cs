using EnviromentalApp.Database.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnviromentalApp.Services
{
    public static class FileBackupService
    {
        public static void BackupToCsv(List<AirQualityMeasurement> data, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Date,NO2,SO2,PM2.5,PM10");

            foreach (var d in data)
            {
                sb.AppendLine($"{d.Date},{d.No2},{d.So2},{d.PM25},{d.PM10}");
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        public static List<AirQualityMeasurement> RestoreFromCsv(string filePath)
        {
            var measurements = new List<AirQualityMeasurement>();
            var lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++) // Skip header
            {
                var parts = lines[i].Split(',');
                if (parts.Length == 5)
                {
                    measurements.Add(new AirQualityMeasurement
                    {
                        Date = DateTime.Parse(parts[0]),
                        No2 = float.Parse(parts[1]),
                        So2 = float.Parse(parts[2]),
                        PM25 = float.Parse(parts[3]),
                        PM10 = float.Parse(parts[4])
                    });
                }
            }

            return measurements;
        }
    }
}
