using EnviromentalApp.ViewModels;
namespace EnviromentalApp.Views;
    
public partial class NotePage : ContentPage
{
    public NotePage(NoteViewModel viewModel)
    {
        this.BindingContext = viewModel;   
        InitializeComponent();
    }

}
