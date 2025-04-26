using EnviromentalApp.ViewModels;
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

}
