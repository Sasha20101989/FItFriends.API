using FitFriends.Logic.Models;
using FitFriends.Logic.Stores;

namespace FitFriends.Persistence.Repositories
{
    public class OrderRepository : IOrderStore
    {
        //Dbcontext

        public Task AddAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetByFilterAsync(OrderFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
