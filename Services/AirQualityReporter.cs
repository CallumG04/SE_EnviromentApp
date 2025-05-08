using EnviromentalApp.Database.Models;

public static class AirQualityReporter
{
    public class DailyAverageReport
    {
        public DateTime Date { get; set; }
        public double AvgNo2 { get; set; }
        public double AvgSO2 { get; set; }
        public double AvgPM25 { get; set; }
        public double AvgPM10 { get; set; }
    }

    public static List<DailyAverageReport> GenerateDailyAverages(List<AirQualityMeasurement> measurements)
    {
        return measurements
            .GroupBy(m => m.Date.Date)
            .Select(g => new DailyAverageReport
            {
                Date = g.Key,
                AvgNo2 = g.Average(m => m.No2),
                AvgSO2 = g.Average(m => m.S02),
                AvgPM25 = g.Average(m => m.PM25),
                AvgPM10 = g.Average(m => m.PM10)
            })
            .OrderBy(r => r.Date)
            .ToList();
    }
}
