using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class ManageUserPage : ContentPage
{
    public ManageUserPage(ManageUserViewModel viewModel)
    {

        this.BindingContext = viewModel;   
        InitializeComponent();
    }

}