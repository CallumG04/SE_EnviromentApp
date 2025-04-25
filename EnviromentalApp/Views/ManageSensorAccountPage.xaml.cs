using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class ManageSensorAccountPage : ContentPage
{
    public ManageSensorAccountPage(ManageSensorAccountViewModel viewModel)
    {

        this.BindingContext = viewModel;   
        InitializeComponent();
    }

	 public List<string> SensorStatuses { get; } = new()
    {
        "Online", "Offline", "Need Calibration"
    };

}