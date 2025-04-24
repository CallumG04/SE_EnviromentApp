using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Models;

namespace EnviromentalApp.Data;
public class UsersDbContext : DbContext
{

    public UsersDbContext()
    { }
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }


    public DbSet<User> Users { get; set; }

}