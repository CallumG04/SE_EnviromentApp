using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class ManageSensorAccountViewModel : ObservableObject, IQueryAttributable
{
    private Sensor _sensor;

    public int sensorId => _sensor.sensorId;

    public DateTime Date => _sensor.Date;
    public string Type
    {
        get => _sensor.Type;
        set
        {
            if (_sensor.Type != value)
            {
                _sensor.Type = value;
                OnPropertyChanged();
            }
        }
    }

    public string Position
    {
        get => _sensor.Position;
        set
        {
            if (_sensor.Position != value)
            {
                _sensor.Position = value;
                OnPropertyChanged();
            }
        }
    }

    public string Status
    {
        get => _sensor.Status;
        set
        {
            if (_sensor.Status != value)
            {
                _sensor.Status = value;
                OnPropertyChanged();
            }
        }
    }

    public string Name
    {
        get => _sensor.Name;
        set
        {
            if (_sensor.Name != value)
            {
                _sensor.Name = value;
                OnPropertyChanged();
            }
        }
    }

    private SensorsDbContext _context;
    
    public ManageSensorAccountViewModel(SensorsDbContext sensorsDbContext)
    {
        _context = sensorsDbContext;
        _sensor = new Sensor();
    }
    public ManageSensorAccountViewModel(SensorsDbContext sensorsDbContext, Sensor sensor)
    {
        _sensor = sensor;
        _context = sensorsDbContext;
    }


[RelayCommand]
private async Task Save()
{
    _sensor.Date = DateTime.Now;
    if (_sensor.sensorId == 0)
    {
        _context.Sensors.Add(_sensor);
    }
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_sensor.sensorId}");
}

[RelayCommand]
private async Task Delete()
{
    _context.Remove(_sensor);
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?deleted={_sensor.sensorId}");
}

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("load"))
    {
        _sensor = _context.Sensors.Single(s => s.sensorId == int.Parse(query["load"].ToString()));
        RefreshProperties();
    }
}

public void Reload()
{
    _context.Entry(_sensor).Reload();
    RefreshProperties();
}


    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Date));
        OnPropertyChanged(nameof(Type));
        OnPropertyChanged(nameof(Position));
        OnPropertyChanged(nameof(Status));
    }
}
