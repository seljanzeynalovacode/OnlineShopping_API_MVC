using Online_Shop_API.DAL.Entities;

namespace Online_Shop_API.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
