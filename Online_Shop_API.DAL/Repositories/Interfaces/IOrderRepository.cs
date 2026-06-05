using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Enums;

namespace Online_Shop_API.DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
        // Additional methods specific to orders
        Task<bool> AddItemToOrderAsync(int orderId, OrderDetail item);
        Task<bool> RemoveItemFromOrderAsync(int orderId, int orderDetailId);
        Task<bool> ChangeOrderStatusAsync(int orderId, Status newStatus);
    }
}
