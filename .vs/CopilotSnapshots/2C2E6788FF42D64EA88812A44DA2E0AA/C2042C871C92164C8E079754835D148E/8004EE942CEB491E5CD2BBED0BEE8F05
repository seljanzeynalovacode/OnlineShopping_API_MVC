using Microsoft.EntityFrameworkCore;
using Online_Shop_API.DAL.Data;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Enums;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }
        public async Task UpdateAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            if (existingOrder != null)
            {

                existingOrder.OrderDate = order.OrderDate;
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.Status = order.Status;
                existingOrder.CustomerId = order.CustomerId;
                _context.Orders.Update(existingOrder);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> AddItemToOrderAsync(int orderId, OrderDetail item)
        {
            var order = await _context.Orders.FindAsync(orderId);
            var product = await _context.Products.FindAsync(item.ProductId);

            if (order != null && product != null)
            {
                item.OrderId = orderId;
                item.Price = product.Price;

                product.StockQuantity -= item.Quantity;
                order.TotalAmount += (item.Quantity * item.Price);
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveItemFromOrderAsync(int orderId, int orderDetailId)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(orderDetailId);
            if (orderDetail != null && orderDetail.OrderId == orderId)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> ChangeOrderStatusAsync(int orderId, Status newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = newStatus;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

