using Xunit;
using EnviromentalApp.Models;
    
namespace EnviromentalApp.Test;
    
public class TicketViewModelTests
{
    [Fact]
    public void Save_NewTicket_ShouldCreateDatabaseRecord() {
    
        // Arrange
        var ticket = new Ticket();
        ticket.sensorId = 1002;
        ticket.Description = "Water Quality";
        ticket.ticketDate = DateTime.Now;
        ticket.Status = "Open";
    
        // Act
    
        // Assert
    }

    public void Updat_UpdateTicket_ShouldUpdateDatabaseRecord() {
    
        // Arrange
    
        // Act
    
        // Assert
    }

    public void Closing_CloseTicket_ShouldUpdateDatabaseRecordNotDelete() {
    
        // Arrange

    
        // Act
    
        // Assert
    }
}
