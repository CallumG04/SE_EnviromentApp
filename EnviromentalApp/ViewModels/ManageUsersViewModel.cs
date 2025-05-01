using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using EnviromentalApp.ViewModels;
using EnviromentalApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;
public partial class ManageUsersViewModel : IQueryAttributable
{
    public ObservableCollection<ViewModels.ManageUserViewModel> AllUsers { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectUserCommand { get; }

    private EnviromentalAppDbContext _context; //define rhe db context so user accounts can be created, modified and deleted
    public ManageUsersViewModel(EnviromentalAppDbContext notesDbContext)
    {

        _context = notesDbContext;
        AllUsers = new ObservableCollection<ViewModels.ManageUserViewModel>(_context.Users.ToList().Select(n => new ManageUserViewModel(_context, n))); //create a list of users pulled from Users object
        NewCommand = new AsyncRelayCommand(NewUserAsync);
        SelectUserCommand = new AsyncRelayCommand<ViewModels.ManageUserViewModel>(user => SelectUserAsync(user)); 

    }

    private async Task NewUserAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.ManageUserPage));
    }

    private async Task SelectUserAsync(ViewModels.ManageUserViewModel user)
    {
        if (user != null)
            await Shell.Current.GoToAsync($"{nameof(Views.ManageUserPage)}?load={user.Id}");
    }

void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.ContainsKey("deleted"))
    {
        string userId = query["deleted"].ToString();
        ManageUserViewModel matchedUser = AllUsers.Where((u) => u.Id == int.Parse(userId)).FirstOrDefault();


        // If user exists, delete it
        if (matchedUser != null)
            AllUsers.Remove(matchedUser);
    }
    else if (query.ContainsKey("saved"))
    {
        string userId = query["saved"].ToString();
        ManageUserViewModel matchedUser = AllUsers.Where((u) => u.Id == int.Parse(userId)).FirstOrDefault();


        // If user is found, update it
        if (matchedUser != null)
        {
            matchedUser.Reload();
            AllUsers.Move(AllUsers.IndexOf(matchedUser), 0);
        }
        // If user isn't found, it's new; add it.
        else
            AllUsers.Insert(0, new ManageUserViewModel(_context, _context.Users.Single(u => u.Id == int.Parse(userId))));

    }
}

}