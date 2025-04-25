using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class AllSensorAccountsPage : ContentPage
{
    public AllSensorAccountsPage(ManageSensorAccountsViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
{
    sensorAccountsCollection.SelectedItem = null;
}

}
