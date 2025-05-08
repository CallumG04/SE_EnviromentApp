using EnviromentalApp.ViewModels;
using EnviromentalApp.Services;
using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;

namespace EnviromentalApp.Views;
    
public partial class AllAirQualityMeasurementsPage : ContentPage
{
    public AllAirQualityMeasurementsPage(AllAirQualityMeasurementsViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
{
    weatherMeasurementsCollection.SelectedItem = null;
}
private void OnGenerateReportClicked(object sender, EventArgs e)
{
    try
    {
        using var db = new EnviromentalApp.Database.Data.EnviromentalAppDbContext();
        var data = db.AirQualityMeasurements.ToList();

        var report = EnviromentalApp.Services.AirQualityReporter.GenerateDailyAverages(data);
        EnviromentalApp.Services.ReportExporter.ExportToCsv(report, "reports/air_quality.csv");

        DisplayAlert("Success", "Air quality report exported to /reports.", "OK");
    }
    catch (Exception ex)
    {
        DisplayAlert("Error", ex.Message, "OK");
    }
}

private void OnValidateDataClicked(object sender, EventArgs e)
{
    try
    {
        using var db = new EnviromentalApp.Database.Data.EnviromentalAppDbContext();
        var data = db.AirQualityMeasurements.ToList();

        var issues = EnviromentalApp.Services.SensorDataValidator.ValidateAirQualityData(data);

        if (!issues.Any())
        {
            DisplayAlert("Validation", "All data is valid!", "OK");
        }
        else
        {
            var message = string.Join("\n\n", issues.Select(i =>
                $"{i.Date:yyyy-MM-dd}:\n- {string.Join("\n- ", i.Issues)}"));

            DisplayAlert("Validation Issues", message, "OK");
        }
    }
    catch (Exception ex)
    {
        DisplayAlert("Error", ex.Message, "OK");
    }
}

}
