using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using EnviromentalApp.ViewModels;
using EnviromentalApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class TicketsViewModel : IQueryAttributable
{
    public ObservableCollection<ViewModels.TicketViewModel> AllTickets { get; }
    public ObservableCollection<ViewModels.TicketViewModel> AllSensors { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectTicketCommand { get; }

    

private TicketsDbContext _context;
public TicketsViewModel(TicketsDbContext ticketsDbContext)
{
    _context = ticketsDbContext;
    AllTickets = new ObservableCollection<ViewModels.TicketViewModel>(_context.Tickets.ToList().Select(t => new TicketViewModel(_context, t)));
    //AllTickets = new ObservableCollection<ViewModels.TicketViewModel>(_context.Sensors.ToList().Select(t => new TicketViewModel(_context, t)));
    NewCommand = new AsyncRelayCommand(NewTicketAsync);
    SelectTicketCommand = new AsyncRelayCommand<ViewModels.TicketViewModel>(ticket => SelectTicketAsync(ticket));

}


    private async Task NewTicketAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.TicketPage));
    }

    private async Task SelectTicketAsync(ViewModels.TicketViewModel ticket)
    {
        if (ticket != null)
            await Shell.Current.GoToAsync($"{nameof(Views.TicketPage)}?load={ticket.ticketId}");
    }

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("deleted"))
    {
        string ticketId = query["deleted"].ToString();
        TicketViewModel matchedTicket = AllTickets.Where((t) => t.ticketId == int.Parse(ticketId)).FirstOrDefault();


        // If note exists, delete it
        if (matchedTicket != null)
            AllTickets.Remove(matchedTicket);
    }
    else if (query.ContainsKey("saved"))
    {
        string ticketId = query["saved"].ToString();
        TicketViewModel matchedTicket = AllTickets.Where((t) => t.ticketId == int.Parse(ticketId)).FirstOrDefault();


        // If note is found, update it
        if (matchedTicket != null)
        {
            matchedTicket.Reload();
            AllTickets.Move(AllTickets.IndexOf(matchedTicket), 0);
        }
        // If note isn't found, it's new; add it.
        else
            AllTickets.Insert(0, new TicketViewModel(_context, _context.Tickets.Single(t => t.ticketId == int.Parse(ticketId))));

    }
}

}
