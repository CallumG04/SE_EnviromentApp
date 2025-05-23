using EnviromentalApp.Database.Data;
using EnviromentalApp.Database.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace EnviromentalApp.ViewModels;

public partial class ManageUserViewModel : ObservableObject, IQueryAttributable
{
    private User _user;

    public int Id => _user.Id;

    public string Username
    {
        get => _user.Username;
        set
        {
            if (_user.Username != value)
            {
                _user.Username = value;
                OnPropertyChanged();
            }
        }
    }

    public string Password
    {
        get => _user.Password;
        set
        {
            if (_user.Password != value)
            {
                _user.Password = value;
                OnPropertyChanged();
            }
        }
    }

    public string Role
    {
        get => _user.Role;
        set
        {
            if (_user.Role != value)
            {
                _user.Role = value;
                OnPropertyChanged();
            }
        }
    }

    private EnviromentalAppDbContext _context;
    
    public ManageUserViewModel(EnviromentalAppDbContext notesDbContext)
    {
        _context = notesDbContext;
        _user = new User();
    }
    public ManageUserViewModel(EnviromentalAppDbContext notesDbContext, User user)
    {
        _user = user;
        _context = notesDbContext;
    }


//save the details of a user
[RelayCommand]
private async Task Save()
{
    if (_user.Id == 0)
    {
        _context.Users.Add(_user);
    }

    _context.SaveChanges();
    await Shell.Current.GoToAsync($"..?saved={_user.Id}");
}

    //delete user acccount
    [RelayCommand]
    private async Task Delete()
    {
        _context.Remove(_user);
        _context.SaveChanges();
        await Shell.Current.GoToAsync($"..?deleted={_user.Id}");
    }

    //initaillty load all of the user accounts
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("load"))
        {
            Console.WriteLine("Got hgere");
            _user = _context.Users.Single(u => u.Id == int.Parse(query["load"].ToString()));
            RefreshProperties();
        }
    }

    //reload is called when a user account is saved or deldted
    public void Reload()
    {
        _context.Entry(_user).Reload();
        RefreshProperties();
    }


    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Username));
        OnPropertyChanged(nameof(Password));
        OnPropertyChanged(nameof(Role));
    }
}