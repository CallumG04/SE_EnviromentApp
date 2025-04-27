using Xunit;
using EnviromentalApp.Models;
    
namespace EnviromentalApp.Test;
    
public class ManageUserViewModelTests
{
    [Fact]
    public void Save_NewUserAccount_ShouldCreateDatabaseRecord() {
    
        // Arrange
        var user = new User();
        user.Username = "John Bore";
        user.Password = "jBore123!";
        user.Role = "Operations Manager";
    
        // Act
    
        // Assert
    }

    public void Update_UpdateUserAccount_ShouldUpdateDatabaseRecord() {
    
        // Arrange
    
        // Act
    
        // Assert
    }

    public void Delete_DeleteUserAccount_ShouldDeleteDatabaseRecord() {
    
        // Arrange
    
        // Act
    
        // Assert
    }
}
