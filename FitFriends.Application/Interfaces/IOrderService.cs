using FitFriends.Logic.Models;

namespace FitFriends.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(Order order);
    }
}
