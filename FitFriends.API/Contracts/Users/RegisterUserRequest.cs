using System.ComponentModel.DataAnnotations;

namespace FitFriends.API.Contracts.Users
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Email,
        [Required] string Password);
}
