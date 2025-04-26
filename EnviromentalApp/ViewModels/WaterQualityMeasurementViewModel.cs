using EnviromentalApp.Data;
using EnviromentalApp.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class WaterQualityMeasurementViewModel : ObservableObject, IQueryAttributable
{
    private Models.WaterQualityMeasurement _waterQualityMeasurement;
    
    public int Id => _waterQualityMeasurement.Id;
    public int sensorId
    {
        get => _waterQualityMeasurement.sensorId;
        set
        {
            if (_waterQualityMeasurement.sensorId != value)
            {
                _waterQualityMeasurement.sensorId = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime Date
    {
        get => _waterQualityMeasurement.Date;
        set
        {
            if (_waterQualityMeasurement.Date != value)
            {
                _waterQualityMeasurement.Date = value;
                OnPropertyChanged();
            }
        }
    }

    public float NitrateN03
    {
        get => (float)_waterQualityMeasurement.NitrateN03;
        set
        {
            if (_waterQualityMeasurement.NitrateN03 != value)
            {
                _waterQualityMeasurement.NitrateN03 = value;
                OnPropertyChanged();
            }
        }
    }

    public float NitrateN02
    {
        get => (float)_waterQualityMeasurement.NitrateN02;
        set
        {
            if (_waterQualityMeasurement.NitrateN02 != value)
            {
                _waterQualityMeasurement.NitrateN02 = value;
                OnPropertyChanged();
            }
        }
    }

    public float Phosphate
    {
        get => (float)_waterQualityMeasurement.Phosphate;
        set
        {
            if (_waterQualityMeasurement.Phosphate != value)
            {
                _waterQualityMeasurement.Phosphate = value;
                OnPropertyChanged();
            }
        }
    }

    public float EC
    {
        get => (float)_waterQualityMeasurement.EC;
        set
        {
            if (_waterQualityMeasurement.EC != value)
            {
                _waterQualityMeasurement.EC = value;
                OnPropertyChanged();
            }
        }
    }

   public float IE
    {
        get => (float)_waterQualityMeasurement.IE;
        set
        {
            if (_waterQualityMeasurement.IE != value)
            {
                _waterQualityMeasurement.IE = value;
                OnPropertyChanged();
            }
        }
    }

    private WaterQualityMeasurementDbContext _context;

    public WaterQualityMeasurementViewModel(WaterQualityMeasurementDbContext waterQualityMeasurementDbContext)
    {
        _context = waterQualityMeasurementDbContext;
        _waterQualityMeasurement = new WaterQualityMeasurement();
    }
    public WaterQualityMeasurementViewModel(WaterQualityMeasurementDbContext waterQualityMeasurementDbContext, WaterQualityMeasurement waterQualityMeasurement)
    {
        _waterQualityMeasurement = waterQualityMeasurement;
        _context = waterQualityMeasurementDbContext;
    }


[RelayCommand]
private async Task Save()
{
    _waterQualityMeasurement.Date = DateTime.Now;
    if (_waterQualityMeasurement.Id == 0)
    {
        _context.WaterQualityMeasurements.Add(_waterQualityMeasurement);
    }
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_waterQualityMeasurement.Id}");
}

[RelayCommand]
private async Task Delete()
{
    _waterQualityMeasurement.Date = DateTime.Now;
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_waterQualityMeasurement.Id}");
}

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("load"))
    {
        _waterQualityMeasurement = _context.WaterQualityMeasurements.Single(w => w.Id == int.Parse(query["load"].ToString()));
        RefreshProperties();
    }
}

public void Reload()
{
    _context.Entry(_waterQualityMeasurement).Reload();
    RefreshProperties();
}


    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Date));
        OnPropertyChanged(nameof(NitrateN03));
        OnPropertyChanged(nameof(NitrateN02));
        OnPropertyChanged(nameof(Phosphate));
        OnPropertyChanged(nameof(EC));
        OnPropertyChanged(nameof(IE));
    }
}
