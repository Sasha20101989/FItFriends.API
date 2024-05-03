using System.ComponentModel.DataAnnotations;

namespace FitFriends.API.Contracts.Users
{
    public record LoginUserRequest(
        [Required] string Email, 
        [Required] string Password);
}
