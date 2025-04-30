using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using EnviromentalApp.ViewModels;
using EnviromentalApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class SensorsViewModel : IQueryAttributable
{
    public ObservableCollection<ViewModels.SensorViewModel> AllSensors { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectSensorCommand { get; }

private SensorsDbContext _context;
public SensorsViewModel(SensorsDbContext sensorsDbContext)
{
    _context = sensorsDbContext;
    AllSensors = new ObservableCollection<ViewModels.SensorViewModel>(_context.Sensors.ToList().Select(s => new SensorViewModel(_context, s)));
    NewCommand = new AsyncRelayCommand(NewSensorAsync);
    SelectSensorCommand = new AsyncRelayCommand<ViewModels.SensorViewModel>(sensor => SelectSensorAsync(sensor));

}


    private async Task NewSensorAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.SensorPage));
    }

    private async Task SelectSensorAsync(ViewModels.SensorViewModel sensor)
    {
        if (sensor != null)
            await Shell.Current.GoToAsync($"{nameof(Views.SensorPage)}?load={sensor.sensorId}");
    }

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("deleted"))
    {
        string sensorId = query["deleted"].ToString();
        SensorViewModel matchedSensor = AllSensors.Where((s) => s.sensorId == int.Parse(sensorId)).FirstOrDefault();


        // If note exists, delete it
        if (matchedSensor != null)
            AllSensors.Remove(matchedSensor);
    }
    else if (query.ContainsKey("saved"))
    {
        string sensorId = query["saved"].ToString();
        SensorViewModel matchedSensor = AllSensors.Where((s) => s.sensorId == int.Parse(sensorId)).FirstOrDefault();


        // If note is found, update it
        if (matchedSensor != null)
        {
            matchedSensor.Reload();
            AllSensors.Move(AllSensors.IndexOf(matchedSensor), 0);
        }
        // If note isn't found, it's new; add it.
        else
            AllSensors.Insert(0, new SensorViewModel(_context, _context.Sensors.Single(n => n.sensorId == int.Parse(sensorId))));

    }
}

}
