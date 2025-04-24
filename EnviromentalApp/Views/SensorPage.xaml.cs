using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class SensorPage : ContentPage
{
    public SensorPage(SensorViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }

}
