using Online_Shop_API.BLL.Dtos;

namespace Online_Shop_API.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(ProductDto productDto);
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task UpdateAsync(ProductDto productDto);
        Task DeleteAsync(int id);

    }
}
