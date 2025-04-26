using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class AllWaterQualityMeasurementsPage : ContentPage
{
    public AllWaterQualityMeasurementsPage(AllWaterQualityMeasurementsViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
{
    waterQualityMeasurementsCollection.SelectedItem = null;
}

}
