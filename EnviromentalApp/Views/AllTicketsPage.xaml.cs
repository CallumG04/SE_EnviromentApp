using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class AllTicketsPage : ContentPage
{
    public AllTicketsPage(TicketsViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
{
    ticketsCollection.SelectedItem = null;
}

}
