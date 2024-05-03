using FitFriends.Application.Interfaces;
using FitFriends.Logic.Models;
using FitFriends.Persistence.Repositories;

namespace FitFriends.Application.Services
{
    public class OrderService(IOrderStore orderStore) : IOrderService
    {
        public async Task CreateAsync(Order order)
        {
            //логирование и тд

            Order? existedOrder = await orderStore.GetByNameAsync(order.Name);

            if (existedOrder is not null)
            {
                throw new Exception();
            }

            await orderStore.AddAsync(order);
        }
    }
}
