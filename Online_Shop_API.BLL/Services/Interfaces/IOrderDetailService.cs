using Online_Shop_API.BLL.Dtos;

namespace Online_Shop_API.BLL.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task AddAsync(OrderDetailDto orderDetailDto);
        Task<OrderDetailDto> GetByIdAsync(int id);
        Task<IEnumerable<OrderDetailDto>> GetAllAsync();
        Task UpdateAsync(OrderDetailDto orderDetailDto);
        Task DeleteAsync(int id);
    }
}
