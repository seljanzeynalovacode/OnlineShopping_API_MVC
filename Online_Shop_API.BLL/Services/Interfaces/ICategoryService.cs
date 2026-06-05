using Online_Shop_API.BLL.Dtos;

namespace Online_Shop_API.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task AddAsync(CategoryDto categoryDto);
        Task<CategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task UpdateAsync(CategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
