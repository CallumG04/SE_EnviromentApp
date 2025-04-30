using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using EnviromentalApp.ViewModels;
using EnviromentalApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class ManageSensorAccountsViewModel : IQueryAttributable
{
    public ObservableCollection<ViewModels.ManageSensorAccountViewModel> AllSensorAccounts { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectSensorCommand { get; }

private EnviromentalAppDbContext _context;
public ManageSensorAccountsViewModel(EnviromentalAppDbContext sensorsDbContext)
{
    _context = sensorsDbContext;
    AllSensorAccounts = new ObservableCollection<ViewModels.ManageSensorAccountViewModel>(_context.Sensors.ToList().Select(s => new ManageSensorAccountViewModel(_context, s)));
    NewCommand = new AsyncRelayCommand(NewSensorAccountAsync);
    SelectSensorCommand = new AsyncRelayCommand<ViewModels.ManageSensorAccountViewModel>(sensor => SelectSensorAccountAsync(sensor));

}


    private async Task NewSensorAccountAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.ManageSensorAccountPage));
    }

    private async Task SelectSensorAccountAsync(ViewModels.ManageSensorAccountViewModel sensor)
    {
        if (sensor != null)
            await Shell.Current.GoToAsync($"{nameof(Views.ManageSensorAccountPage)}?load={sensor.sensorId}");
    }

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("deleted"))
    {
        string sensorId = query["deleted"].ToString();
        ManageSensorAccountViewModel matchedSensor = AllSensorAccounts.Where((s) => s.sensorId == int.Parse(sensorId)).FirstOrDefault();


        // If sensor exists, delete it
        if (matchedSensor != null)
            AllSensorAccounts.Remove(matchedSensor);
    }
    else if (query.ContainsKey("saved"))
    {
        string sensorId = query["saved"].ToString();
        ManageSensorAccountViewModel matchedSensor = AllSensorAccounts.Where((s) => s.sensorId == int.Parse(sensorId)).FirstOrDefault();


        // If sensor is found, update it
        if (matchedSensor != null)
        {
            matchedSensor.Reload();
            AllSensorAccounts.Move(AllSensorAccounts.IndexOf(matchedSensor), 0);
        }
        // If sensor isn't found, it's new; add it.
        else
            AllSensorAccounts.Insert(0, new ManageSensorAccountViewModel(_context, _context.Sensors.Single(n => n.sensorId == int.Parse(sensorId))));

    }
}

}
