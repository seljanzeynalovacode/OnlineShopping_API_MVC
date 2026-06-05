using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.DAL.Enums;

namespace Online_Shop_API.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddAsync(OrderDto orderDto);
        Task<OrderDto> GetByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task UpdateAsync(OrderDto orderDto);
        Task DeleteAsync(int id);

        // Additional methods specific to orders
        Task<bool> AddItemToOrderAsync(int orderId, OrderDetailDto item);
        Task<bool> RemoveItemFromOrderAsync(int orderId, int orderDetailId);
        Task<bool> ChangeOrderStatusAsync(int orderId, Status newStatus);

    }
}
