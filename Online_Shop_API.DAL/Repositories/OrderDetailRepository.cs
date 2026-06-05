using Microsoft.EntityFrameworkCore;
using Online_Shop_API.DAL.Data;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.DAL.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _context;
        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            var details = await _context.OrderDetails.ToListAsync();
            return details;
        }
        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            var detail = await _context.OrderDetails.FindAsync(id);
            return detail;
        }
        public async Task AddAsync(OrderDetail orderDetail)
        {
            
            var product = await _context.Products.FindAsync(orderDetail.ProductId);
            if (product != null)
            {
                orderDetail.Price = product.Price;
            }

            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            var existingDetail = await _context.OrderDetails.FindAsync(orderDetail.Id);
            if (existingDetail != null)
            {
                existingDetail.OrderId = orderDetail.OrderId;
                existingDetail.ProductId = orderDetail.ProductId;
                existingDetail.Quantity = orderDetail.Quantity;
                existingDetail.Price = orderDetail.Price;

                _context.OrderDetails.Update(existingDetail);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            var detail = await _context.OrderDetails.FindAsync(id);
            if (detail != null)
            {
                _context.OrderDetails.Remove(detail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
