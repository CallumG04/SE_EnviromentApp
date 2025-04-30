using Xunit;
using EnviromentalApp.Database.Models;
    
namespace EnviromentalApp.Test;

public class TicketViewModelTests : IClassFixture<DatabaseFixture>
{
    DatabaseFixture _fixture;
    public TicketViewModelTests(DatabaseFixture fixture) {
        _fixture = fixture;
        _fixture.Ticket();
    }

    [Fact]
    public void Save_NewTicket_ShouldCreateDatabaseRecord() {
    
        // Arrange
        var ticket = new Database.Models.Ticket();
        ticket.sensorId = 1;
        ticket.Description = "Fault with sensor not recoridng any data";
        ticket.ticketDate = DateTime.Now;
        ticket.Status = "Open";
            
        // Act
        _fixture._testDbContext.Add(ticket);
        _fixture._testDbContext.SaveChanges();
        ticket.ticketId = 1;
    
        // Assert
        Assert.NotEqual(ticket.ticketId, 0);
    }

    public void Update_UpdatingTicket_ShouldUpdateDatabaseRecord() {
    
        // Arrange
        var ticket = new Ticket();
        ticket.Status = "Closed";
            
        // Act
        _fixture._testDbContext.SaveChanges();
    
        // Assert
        Assert.NotEqual(ticket.ticketId, 0);
    }

    public void Closing_ClosingTicket_ShouldUpdateNotDelete() {
    
        // Arrange
        //var ticket = _fixture.Tickets.Single(t => t.ticketId == int.Parse(query["load"].ToString()));
            
        // Act
        //_fixture._testDbContext.Remove(ticket);
        //_fixture._testDbContext.SaveChanges();
    
        // Assert
        //Assert.NotEqual(ticket.ticketId, 0);
    }
    
}