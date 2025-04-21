using System.Collections.ObjectModel;

namespace EnviromentalApp.Models;

internal class AllSensors
{
    public ObservableCollection<Sensor> Sensors { get; set; } = new ObservableCollection<Sensor>();

    public AllSensors() =>
        LoadSensors();

    public void LoadSensors()
    {
        Sensors.Clear();

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the \*.notes.txt files.
        IEnumerable<Sensor> sensors = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new Sensor()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetLastWriteTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (Sensor sensor in sensors)
            Sensors.Add(sensor);
    }
}
