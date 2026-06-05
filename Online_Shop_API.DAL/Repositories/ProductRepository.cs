using Microsoft.EntityFrameworkCore;
using Online_Shop_API.DAL.Data;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Discount = product.Discount;
                existingProduct.StockQuantity = product.StockQuantity;

                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
