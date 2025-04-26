using EnviromentalApp.Data;
using EnviromentalApp.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class TicketViewModel : ObservableObject, IQueryAttributable
{
    private Models.Ticket _ticket;
    

    public int ticketId => _ticket.ticketId;
    public int sensorId
    {
        get => _ticket.sensorId;
        set
        {
            if (_ticket.sensorId != value)
            {
                _ticket.sensorId = value;
                OnPropertyChanged();
            }
        }
    }
    public string Description
    {
        get => _ticket.Description;
        set
        {
            if (_ticket.Description != value)
            {
                _ticket.Description = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime Date
    {
        get => _ticket.ticketDate;
        set
        {
            if (_ticket.ticketDate != value)
            {
                _ticket.ticketDate = value;
                OnPropertyChanged();
            }
        }
    }

    public string Status
    {
        get => _ticket.Status;
        set
        {
            if (_ticket.Status != value)
            {
                _ticket.Status = value;
                OnPropertyChanged();
            }
        }
    }

    private TicketsDbContext _context;

    
    
    public TicketViewModel(TicketsDbContext ticketsDbContext)
    {
        _context = ticketsDbContext;
        _ticket = new Ticket();
    }
    public TicketViewModel(TicketsDbContext ticketsDbContext, Ticket ticket)
    {
        _ticket = ticket;
        _context = ticketsDbContext;
    }


[RelayCommand]
private async Task Save()
{
    _ticket.ticketDate = DateTime.Now;
    if (_ticket.ticketId == 0)
    {
        _context.Tickets.Add(_ticket);
    }
    Console.WriteLine("Sensor ID" + _ticket.sensorId);
    Console.WriteLine("Sensor Status" + _ticket.Status);
    Console.WriteLine("Sensor Description" + _ticket.Description);
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_ticket.ticketId}");
}

[RelayCommand]
private async Task Delete()
{
    _ticket.ticketDate = DateTime.Now;
    _ticket.Status = "Closed";
    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_ticket.ticketId}");
}

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("load"))
    {
        _ticket = _context.Tickets.Single(t => t.ticketId == int.Parse(query["load"].ToString()));
        RefreshProperties();
    }
}

public void Reload()
{
    _context.Entry(_ticket).Reload();
    RefreshProperties();
}


    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Date));
        OnPropertyChanged(nameof(Description));
        OnPropertyChanged(nameof(Status));
    }
}
