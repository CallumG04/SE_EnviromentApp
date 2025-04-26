using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class WaterQualityMeasurementPage : ContentPage
{
    public WaterQualityMeasurementPage(WaterQualityMeasurementViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }

}
