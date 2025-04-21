namespace EnviromentalApp.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class SensorPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

public SensorPage()
{
    InitializeComponent();

    string appDataPath = FileSystem.AppDataDirectory;
    string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

    LoadSensor(Path.Combine(appDataPath, randomFileName));
}

private async void SaveButton_Clicked(object sender, EventArgs e)
{
    if (BindingContext is Models.Sensor note)
        File.WriteAllText(note.Filename, TextEditor.Text);

    await Shell.Current.GoToAsync("..");
}

private async void DeleteButton_Clicked(object sender, EventArgs e)
{
    if (BindingContext is Models.Sensor sensor)
    {
        // Delete the file.
        if (File.Exists(sensor.Filename))
            File.Delete(sensor.Filename);
    }

    await Shell.Current.GoToAsync("..");
}

private void LoadSensor(string fileName)
{
    Models.Sensor sensorModel = new Models.Sensor();
    sensorModel.Filename = fileName;

    if (File.Exists(fileName))
    {
        sensorModel.Date = File.GetCreationTime(fileName);
        sensorModel.Text = File.ReadAllText(fileName);
    }

    BindingContext = sensorModel;
}

public string ItemId
{
    set { LoadSensor(value); }
}


}