using FitFriends.Logic.Models;

namespace FitFriends.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}