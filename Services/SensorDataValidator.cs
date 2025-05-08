using EnviromentalApp.Database.Models;

namespace EnviromentalApp.Services
{
    public static class SensorDataValidator
    {
        public class ValidationResult
        {
            public DateTime Date { get; set; }
            public List<string> Issues { get; set; } = new();
        }

        public static List<ValidationResult> ValidateAirQualityData(List<AirQualityMeasurement> measurements)
        {
            var results = new List<ValidationResult>();

            foreach (var m in measurements)
            {
                var issues = new List<string>();

                if (m.No2 < 0) issues.Add("NO₂ value is negative.");
                if (m.S02 < 0) issues.Add("SO₂ value is negative.");
                if (m.PM25 < 0) issues.Add("PM2.5 value is negative.");
                if (m.PM10 < 0) issues.Add("PM10 value is negative.");
                if (m.Date > DateTime.Now) issues.Add("Measurement date is in the future.");

                if (issues.Any())
                {
                    results.Add(new ValidationResult
                    {
                        Date = m.Date,
                        Issues = issues
                    });
                }
            }

            return results;
        }
    }
}
