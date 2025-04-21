namespace EnviromentalApp.Views;

public partial class AllSensorsPage : ContentPage
{
    public AllSensorsPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllSensors();
    }

    protected override void OnAppearing()
    {
        ((Models.AllSensors)BindingContext).LoadSensors();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SensorPage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Sensor)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(SensorPage)}?{nameof(SensorPage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}
