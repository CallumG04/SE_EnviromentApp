using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using EnviromentalApp.ViewModels;
using EnviromentalApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace EnviromentalApp.ViewModels;

public partial class AllAirQualityMeasurementsViewModel : IQueryAttributable, INotifyPropertyChanged

{
    public ObservableCollection<ViewModels.AirQualityMeasurementViewModel> AllAirQualityMeasurements { get; }
     private float _averagen02;
    public float AverageN02
    {
        get => _averagen02;
        set
        {
            if (_averagen02 != value)
            {
                _averagen02 = value;
                OnPropertyChanged(nameof(AverageN02));
            }
        }
    }

    
    private float _averageS02;
    public float AverageS02
    {
        get => _averageS02;
        set
        {
            if (_averageS02 != value)
            {
                _averageS02 = value;
                OnPropertyChanged(nameof(AverageS02));
            }
        }
    }

    
    private float _averagePm25;
    public float AveragePm25
    {
        get => _averagePm25;
        set
        {
            if (_averagePm25 != value)
            {
                _averagePm25 = value;
                OnPropertyChanged(nameof(AveragePm25));
            }
        }
    }

    private float _averagePm10;
    public float AveragePm10
    {
        get => _averagePm10;
        set
        {
            if (_averagePm10 != value)
            {
                _averagePm10 = value;
                OnPropertyChanged(nameof(AveragePm10));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
    public ICommand NewCommand { get; }
    public ICommand SelectAirQualityMeasurementCommand { get; }

private EnviromentalAppDbContext _context;
public AllAirQualityMeasurementsViewModel(EnviromentalAppDbContext airQualityMeasurementDbContext)
{
    _context = airQualityMeasurementDbContext;
    AllAirQualityMeasurements = new ObservableCollection<ViewModels.AirQualityMeasurementViewModel>(_context.AirQualityMeasurements.ToList().Select(s => new AirQualityMeasurementViewModel(_context, s)));
    AverageN02 = AllAirQualityMeasurements.Average(w => (float)w.N02);
    AverageS02 = AllAirQualityMeasurements.Average(w => (float)w.S02);
    AveragePm25 = AllAirQualityMeasurements.Average(w => (float)w.PM25);
    AveragePm10 = AllAirQualityMeasurements.Average(w => (float)w.PM10);
    NewCommand = new AsyncRelayCommand(NewAirQualityMeasurementAsync);
    SelectAirQualityMeasurementCommand = new AsyncRelayCommand<ViewModels.AirQualityMeasurementViewModel>(sensor => SelectAirQualityMeasurementAsync(sensor));

}


    private async Task NewAirQualityMeasurementAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.WaterQualityMeasurementPage));
    }

    private async Task SelectAirQualityMeasurementAsync(ViewModels.AirQualityMeasurementViewModel airQualityEntry)
    {
        if (airQualityEntry != null)
            await Shell.Current.GoToAsync($"{nameof(Views.ManageSensorAccountPage)}?load={airQualityEntry.Id}");
    }

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("deleted"))
    {
        string airQualityMeasurementId = query["deleted"].ToString();
        AirQualityMeasurementViewModel matchedWeatherMeasurement = AllAirQualityMeasurements.Where((s) => s.Id == int.Parse(airQualityMeasurementId)).FirstOrDefault();

        // If sensor exists, delete it
        if (matchedWeatherMeasurement != null)
            AllAirQualityMeasurements.Remove(matchedWeatherMeasurement);
    }
    else if (query.ContainsKey("saved"))
    {
        string measurementId = query["saved"].ToString();
        AirQualityMeasurementViewModel matchedMeasurement = AllAirQualityMeasurements.Where((s) => s.Id == int.Parse(measurementId)).FirstOrDefault();


        // If sensor is found, update it
        if (matchedMeasurement != null)
        {
            matchedMeasurement.Reload();
            AllAirQualityMeasurements.Move(AllAirQualityMeasurements.IndexOf(matchedMeasurement), 0);
        }
        // If sensor isn't found, it's new; add it.
        else
            AllAirQualityMeasurements.Insert(0, new AirQualityMeasurementViewModel(_context, _context.AirQualityMeasurements.Single(n => n.Id == int.Parse(measurementId))));

    }
}

}
