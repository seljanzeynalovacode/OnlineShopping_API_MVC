using Online_Shop_API.DAL.Entities;

namespace Online_Shop_API.DAL.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task AddAsync(OrderDetail orderDetail);
        Task<OrderDetail> GetByIdAsync(int id);
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task UpdateAsync(OrderDetail orderDetail);
        Task DeleteAsync(int id);
    }
}
