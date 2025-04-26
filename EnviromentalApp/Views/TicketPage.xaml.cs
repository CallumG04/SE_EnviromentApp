using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class TicketPage : ContentPage
{
    public TicketPage(TicketViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }

}
