using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using EnviromentalApp.ViewModels;
using EnviromentalApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace EnviromentalApp.ViewModels;

public partial class AllWeatherMeasurementsViewModel : IQueryAttributable, INotifyPropertyChanged

{
    public ObservableCollection<ViewModels.WeatherMeasurementViewModel> AllWeatherMeasurements { get; }
     private float _averageTemp;
    public float AverageTemp
    {
        get => _averageTemp;
        set
        {
            if (_averageTemp != value)
            {
                _averageTemp = value;
                OnPropertyChanged(nameof(AverageTemp));
            }
        }
    }

    
     private float _averageHumidity;
    public float AverageHumidity
    {
        get => _averageHumidity;
        set
        {
            if (_averageHumidity != value)
            {
                _averageHumidity = value;
                OnPropertyChanged(nameof(AverageHumidity));
            }
        }
    }

    
    private float _averageWindSpeed;
    public float AverageWindSpeed
    {
        get => _averageWindSpeed;
        set
        {
            if (_averageWindSpeed != value)
            {
                _averageWindSpeed = value;
                OnPropertyChanged(nameof(AverageWindSpeed));
            }
        }
    }

    private float _averageWindDirection;
    public float AverageWindDirection
    {
        get => _averageWindDirection;
        set
        {
            if (_averageWindDirection != value)
            {
                _averageWindDirection = value;
                OnPropertyChanged(nameof(AverageWindDirection));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
    public ICommand NewCommand { get; }
    public ICommand SelectWeatherMeasurementCommand { get; }

private WeatherMeasurementDbContext _context;
public AllWeatherMeasurementsViewModel(WeatherMeasurementDbContext weatherMeasurementDbContext)
{
    _context = weatherMeasurementDbContext;
    AllWeatherMeasurements = new ObservableCollection<ViewModels.WeatherMeasurementViewModel>(_context.WeatherMeasurements.ToList().Select(s => new WeatherMeasurementViewModel(_context, s)));
    AverageTemp = AllWeatherMeasurements.Average(w => (float)w.Temperature);
    AverageHumidity = AllWeatherMeasurements.Average(w => (float)w.Humidity);
    AverageWindSpeed = AllWeatherMeasurements.Average(w => (float)w.WindSpeed);
    AverageWindDirection = AllWeatherMeasurements.Average(w => (float)w.WindDirection);
    NewCommand = new AsyncRelayCommand(NewWeatherMeasurementAsync);
    SelectWeatherMeasurementCommand = new AsyncRelayCommand<ViewModels.WeatherMeasurementViewModel>(sensor => SelectWeatherMeasurementAsync(sensor));

}


    private async Task NewWeatherMeasurementAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.WeatherMeasurementPage));
    }

    private async Task SelectWeatherMeasurementAsync(ViewModels.WeatherMeasurementViewModel sensor)
    {
        if (sensor != null)
            await Shell.Current.GoToAsync($"{nameof(Views.ManageSensorAccountPage)}?load={sensor.Id}");
    }

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("deleted"))
    {
        string measurementId = query["deleted"].ToString();
        WeatherMeasurementViewModel matchedWeatherMeasurement = AllWeatherMeasurements.Where((s) => s.Id == int.Parse(measurementId)).FirstOrDefault();


        // If sensor exists, delete it
        if (matchedWeatherMeasurement != null)
            AllWeatherMeasurements.Remove(matchedWeatherMeasurement);
    }
    else if (query.ContainsKey("saved"))
    {
        string measurementId = query["saved"].ToString();
        WeatherMeasurementViewModel matchedMeasurement = AllWeatherMeasurements.Where((s) => s.Id == int.Parse(measurementId)).FirstOrDefault();


        // If sensor is found, update it
        if (matchedMeasurement != null)
        {
            matchedMeasurement.Reload();
            AllWeatherMeasurements.Move(AllWeatherMeasurements.IndexOf(matchedMeasurement), 0);
        }
        // If sensor isn't found, it's new; add it.
        else
            AllWeatherMeasurements.Insert(0, new WeatherMeasurementViewModel(_context, _context.WeatherMeasurements.Single(n => n.Id == int.Parse(measurementId))));

    }
}

}
