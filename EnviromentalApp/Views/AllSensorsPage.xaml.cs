using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class AllSensorsPage : ContentPage
{
    public AllSensorsPage(SensorsViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
{
    sensorsCollection.SelectedItem = null;
}

}
