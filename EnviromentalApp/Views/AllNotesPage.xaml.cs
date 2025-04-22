using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class AllNotesPage : ContentPage
{
    public AllNotesPage(NotesViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }


	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
{
    notesCollection.SelectedItem = null;
}

}
