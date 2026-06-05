using Online_Shop_API.BLL.Dtos;

namespace Online_Shop_API.BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsync(CustomerDto customerDto);
        Task<CustomerDto> GetByIdAsync(int id);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task UpdateAsync(CustomerDto customerDto);
        Task DeleteAsync(int id);
    }
}
