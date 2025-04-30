using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using EnviromentalApp.ViewModels;
using EnviromentalApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;

namespace EnviromentalApp.ViewModels;

public partial class AllWaterQualityMeasurementsViewModel : IQueryAttributable, INotifyPropertyChanged

{
    public ObservableCollection<ViewModels.WaterQualityMeasurementViewModel> AllWaterQualityMeasurements { get; }
     private float _averageNitrateN03;
    public float AverageNitrateN03
    {
        get => _averageNitrateN03;
        set
        {
            if (_averageNitrateN03 != value)
            {
                _averageNitrateN03 = value;
                OnPropertyChanged(nameof(AverageNitrateN03));
            }
        }
    }

    
    private float _averageNitrateN02;
    public float AverageNitrateN02
    {
        get => _averageNitrateN02;
        set
        {
            if (_averageNitrateN02 != value)
            {
                _averageNitrateN02 = value;
                OnPropertyChanged(nameof(AverageNitrateN02));
            }
        }
    }

    
    private float _averagePhosphate;
    public float AveragePhosphate
    {
        get => _averagePhosphate;
        set
        {
            if (_averagePhosphate != value)
            {
                _averagePhosphate = value;
                OnPropertyChanged(nameof(AveragePhosphate));
            }
        }
    }

    private float _averageEC;
    public float AverageEC
    {
        get => _averageEC;
        set
        {
            if (_averageEC != value)
            {
                _averageEC = value;
                OnPropertyChanged(nameof(AverageEC));
            }
        }
    }

    private float _averageIE;
    public float AverageIE
    {
        get => _averageIE;
        set
        {
            if (_averageIE != value)
            {
                _averageIE = value;
                OnPropertyChanged(nameof(AverageIE));
            }
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
    public ICommand NewCommand { get; }
    public ICommand SelectWaterQualityMeasurementCommand { get; }

private EnviromentalAppDbContext _context;
public AllWaterQualityMeasurementsViewModel(EnviromentalAppDbContext waterQualityMeasurementDbContext)
{
    _context = waterQualityMeasurementDbContext;
    AllWaterQualityMeasurements = new ObservableCollection<ViewModels.WaterQualityMeasurementViewModel>(_context.WaterQualityMeasurements.ToList().Select(w => new WaterQualityMeasurementViewModel(_context, w)));
    AverageNitrateN03 = AllWaterQualityMeasurements.Average(w => (float)w.NitrateN03);
    AverageNitrateN02 = AllWaterQualityMeasurements.Average(w => (float)w.NitrateN02);
    AveragePhosphate = AllWaterQualityMeasurements.Average(w => (float)w.Phosphate);
    AverageEC = AllWaterQualityMeasurements.Average(w => (float)w.EC);
    AverageIE = AllWaterQualityMeasurements.Average(w => (float)w.IE);
    NewCommand = new AsyncRelayCommand(NewWaterQualityMeasurementAsync);
    SelectWaterQualityMeasurementCommand = new AsyncRelayCommand<ViewModels.WaterQualityMeasurementViewModel>(measurement => SelectWaterQualityMeasurementAsync(measurement));

}


    private async Task NewWaterQualityMeasurementAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.WaterQualityMeasurementPage));
    }

    private async Task SelectWaterQualityMeasurementAsync(ViewModels.WaterQualityMeasurementViewModel waterQualityEntry)
    {
        if (waterQualityEntry != null)
            await Shell.Current.GoToAsync($"{nameof(Views.ManageSensorAccountPage)}?load={waterQualityEntry.Id}");
    }

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("deleted"))
    {
        string waterQualityMeasurementId = query["deleted"].ToString();
        WaterQualityMeasurementViewModel matchedWaterQualityMeasurement = AllWaterQualityMeasurements.Where((s) => s.Id == int.Parse(waterQualityMeasurementId)).FirstOrDefault();

        // If sensor exists, delete it
        if (matchedWaterQualityMeasurement != null)
            AllWaterQualityMeasurements.Remove(matchedWaterQualityMeasurement);
    }
    else if (query.ContainsKey("saved"))
    {
        string measurementId = query["saved"].ToString();
        WaterQualityMeasurementViewModel matchedMeasurement = AllWaterQualityMeasurements.Where((s) => s.Id == int.Parse(measurementId)).FirstOrDefault();


        // If sensor is found, update it
        if (matchedMeasurement != null)
        {
            matchedMeasurement.Reload();
            AllWaterQualityMeasurements.Move(AllWaterQualityMeasurements.IndexOf(matchedMeasurement), 0);
        }
        // If sensor isn't found, it's new; add it.
        else
            AllWaterQualityMeasurements.Insert(0, new WaterQualityMeasurementViewModel(_context, _context.WaterQualityMeasurements.Single(n => n.Id == int.Parse(measurementId))));

    }
}

}
