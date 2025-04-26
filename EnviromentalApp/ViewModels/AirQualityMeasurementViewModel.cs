using EnviromentalApp.Data;
using EnviromentalApp.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class AirQualityMeasurementViewModel : ObservableObject, IQueryAttributable
{
    private Models.AirQualityMeasurement _airQualityMeasurement;
    
    public int Id => _airQualityMeasurement.Id;
    public int sensorId
    {
        get => _airQualityMeasurement.sensorId;
        set
        {
            if (_airQualityMeasurement.sensorId != value)
            {
                _airQualityMeasurement.sensorId = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime Date
    {
        get => _airQualityMeasurement.Date;
        set
        {
            if (_airQualityMeasurement.Date != value)
            {
                _airQualityMeasurement.Date = value;
                OnPropertyChanged();
            }
        }
    }

    public float N02
    {
        get => (float)_airQualityMeasurement.No2;
        set
        {
            if (_airQualityMeasurement.No2 != value)
            {
                _airQualityMeasurement.No2 = value;
                OnPropertyChanged();
            }
        }
    }

    public float S02
    {
        get => (float)_airQualityMeasurement.S02;
        set
        {
            if (_airQualityMeasurement.S02 != value)
            {
                _airQualityMeasurement.S02 = value;
                OnPropertyChanged();
            }
        }
    }

    public float PM25
    {
        get => (float)_airQualityMeasurement.PM25;
        set
        {
            if (_airQualityMeasurement.PM25 != value)
            {
                _airQualityMeasurement.PM25 = value;
                OnPropertyChanged();
            }
        }
    }

    public float PM10
    {
        get => (float)_airQualityMeasurement.PM10;
        set
        {
            if (_airQualityMeasurement.PM10 != value)
            {
                _airQualityMeasurement.PM10 = value;
                OnPropertyChanged();
            }
        }
    }

    private AirQualityMeasurementDbContext _context;

    
    
    public AirQualityMeasurementViewModel(AirQualityMeasurementDbContext airQualityMeasurementDbContext)
    {
        _context = airQualityMeasurementDbContext;
        _airQualityMeasurement = new AirQualityMeasurement();
    }
    public AirQualityMeasurementViewModel(AirQualityMeasurementDbContext weatherMeasurementDbContext, AirQualityMeasurement airQualityMeasurement)
    {
        _airQualityMeasurement = airQualityMeasurement;
        _context = weatherMeasurementDbContext;
    }


[RelayCommand]
private async Task Save()
{
    _airQualityMeasurement.Date = DateTime.Now;
    if (_airQualityMeasurement.Id == 0)
    {
        _context.AirQualityMeasurements.Add(_airQualityMeasurement);
    }
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_airQualityMeasurement.Id}");
}

[RelayCommand]
private async Task Delete()
{
    _airQualityMeasurement.Date = DateTime.Now;
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_airQualityMeasurement.Id}");
}

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("load"))
    {
        _airQualityMeasurement = _context.AirQualityMeasurements.Single(t => t.Id == int.Parse(query["load"].ToString()));
        RefreshProperties();
    }
}

public void Reload()
{
    _context.Entry(_airQualityMeasurement).Reload();
    RefreshProperties();
}


    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Date));
        OnPropertyChanged(nameof(PM10));
        OnPropertyChanged(nameof(PM25));
        OnPropertyChanged(nameof(N02));
        OnPropertyChanged(nameof(S02));
    }
}
