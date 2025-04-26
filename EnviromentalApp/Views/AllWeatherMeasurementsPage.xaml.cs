using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class AllWeatherMeasurementsPage : ContentPage
{
    public AllWeatherMeasurementsPage(AllWeatherMeasurementsViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
{
    weatherMeasurementsCollection.SelectedItem = null;
}

}
