using Microsoft.EntityFrameworkCore;
using Online_Shop_API.DAL.Data;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Surname = customer.Surname;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                _context.Customers.Update(existingCustomer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
