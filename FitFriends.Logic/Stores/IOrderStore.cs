using FitFriends.Logic.Models;
using FitFriends.Logic.Stores;

namespace FitFriends.Persistence.Repositories
{
    public interface IOrderStore
    {
        Task AddAsync(Order order);
        Task<IReadOnlyList<Order>> GetByFilterAsync(OrderFilter filter);
        Task<Order> GetByIdAsync(Guid id);
        Task<Order> GetByNameAsync(string name);
    }
}