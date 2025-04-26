using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class WeatherMeasurementPage : ContentPage
{
    public WeatherMeasurementPage(WeatherMeasurementViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }

}
