using Online_Shop_API.DAL.Entities;

namespace Online_Shop_API.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
