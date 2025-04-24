using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class AllUsersPage : ContentPage
{
    public AllUsersPage(ManageUsersViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
{
    usersCollection.SelectedItem = null;
}

}