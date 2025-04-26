using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using EnviromentalApp.Models;

namespace EnviromentalApp.Data;
public class TicketsDbContext : DbContext
{

    public TicketsDbContext()
    { }
    public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options) { }

    public DbSet<Ticket> Tickets { get; set; }

}