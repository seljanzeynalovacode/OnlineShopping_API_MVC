using Microsoft.EntityFrameworkCore;
using Online_Shop_API.DAL.Data;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task UpdateAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;

                _context.Categories.Update(existingCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
