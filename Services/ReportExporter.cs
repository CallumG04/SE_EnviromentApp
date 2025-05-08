using System.Text;
using System.IO;

public static class ReportExporter
{
    public static void ExportToCsv(List<AirQualityReporter.DailyAverageReport> report, string filePath)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Date,AvgNo2,AvgSO2,AvgPM2.5,AvgPM10");

        foreach (var row in report)
        {
            sb.AppendLine($"{row.Date:yyyy-MM-dd},{row.AvgNo2:F2},{row.AvgSO2:F2},{row.AvgPM25:F2},{row.AvgPM10:F2}");
        }

        File.WriteAllText(filePath, sb.ToString());
    }
}
