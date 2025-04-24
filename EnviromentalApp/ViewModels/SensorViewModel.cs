using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EnviromentalApp.Models;
using EnviromentalApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EnviromentalApp.ViewModels;

public partial class SensorViewModel : ObservableObject
{
    private readonly SensorService _sensorService;

    [ObservableProperty]
    private ObservableCollection<Sensor> sensors;

    public SensorViewModel(SensorService sensorService)
    {
        _sensorService = sensorService;
        Sensors = new ObservableCollection<Sensor>();
    }

    [RelayCommand]
    public async Task LoadSensors()
    {
        // Simulating delay to mimic async DB/API call
        await Task.Delay(500);

        var data = _sensorService.GetSensors();
        Sensors.Clear();

        foreach (var sensor in data)
        {
            Sensors.Add(sensor);
        }
    }

    [RelayCommand]
    public void Refresh()
    {
        // For now, just reload dummy data
        var data = _sensorService.GetSensors();
        Sensors.Clear();

        foreach (var sensor in data)
        {
            Sensors.Add(sensor);
        }
    }
}
