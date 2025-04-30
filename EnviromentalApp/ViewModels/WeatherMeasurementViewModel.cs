using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class WeatherMeasurementViewModel : ObservableObject, IQueryAttributable
{
    private WeatherMeasurement _weatherMeasurement;
    
    public int Id => _weatherMeasurement.Id;
    public int sensorId
    {
        get => _weatherMeasurement.sensorId;
        set
        {
            if (_weatherMeasurement.sensorId != value)
            {
                _weatherMeasurement.sensorId = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime Date
    {
        get => _weatherMeasurement.Date;
        set
        {
            if (_weatherMeasurement.Date != value)
            {
                _weatherMeasurement.Date = value;
                OnPropertyChanged();
            }
        }
    }

    public float Temperature
    {
        get => (float)_weatherMeasurement.Temperature;
        set
        {
            if (_weatherMeasurement.Temperature != value)
            {
                _weatherMeasurement.Temperature = value;
                OnPropertyChanged();
            }
        }
    }

    public float Humidity
    {
        get => (float)_weatherMeasurement.Humidity;
        set
        {
            if (_weatherMeasurement.Humidity != value)
            {
                _weatherMeasurement.Humidity = value;
                OnPropertyChanged();
            }
        }
    }

    public float WindSpeed
    {
        get => (float)_weatherMeasurement.windSpeed;
        set
        {
            if (_weatherMeasurement.windSpeed != value)
            {
                _weatherMeasurement.windSpeed = value;
                OnPropertyChanged();
            }
        }
    }

    public int WindDirection
    {
        get => _weatherMeasurement.windDirection;
        set
        {
            if (_weatherMeasurement.windDirection != value)
            {
                _weatherMeasurement.windDirection = value;
                OnPropertyChanged();
            }
        }
    }

    private EnviromentalAppDbContext _context;

    
    
    public WeatherMeasurementViewModel(EnviromentalAppDbContext weatherMeasurementDbContext)
    {
        _context = weatherMeasurementDbContext;
        _weatherMeasurement = new WeatherMeasurement();
    }
    public WeatherMeasurementViewModel(EnviromentalAppDbContext weatherMeasurementDbContext, WeatherMeasurement weatherMeasurement)
    {
        _weatherMeasurement = weatherMeasurement;
        _context = weatherMeasurementDbContext;
    }


[RelayCommand]
private async Task Save()
{
    _weatherMeasurement.Date = DateTime.Now;
    if (_weatherMeasurement.Id == 0)
    {
        _context.WeatherMeasurements.Add(_weatherMeasurement);
    }
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_weatherMeasurement.Id}");
}

[RelayCommand]
private async Task Delete()
{
    _weatherMeasurement.Date = DateTime.Now;
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_weatherMeasurement.Id}");
}

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("load"))
    {
        _weatherMeasurement = _context.WeatherMeasurements.Single(t => t.Id == int.Parse(query["load"].ToString()));
        RefreshProperties();
    }
}

public void Reload()
{
    _context.Entry(_weatherMeasurement).Reload();
    RefreshProperties();
}


    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Date));
        OnPropertyChanged(nameof(Temperature));
        OnPropertyChanged(nameof(Humidity));
        OnPropertyChanged(nameof(WindSpeed));
        OnPropertyChanged(nameof(WindDirection));
    }
}
