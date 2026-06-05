using AutoMapper;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.AddAsync(customer);

        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return customerDtos;
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        public async Task UpdateAsync(CustomerDto customerDto)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(customerDto.Id);

            if (existingCustomer != null)
            {
                _mapper.Map(customerDto, existingCustomer);
                await _customerRepository.UpdateAsync(existingCustomer);
            }
        }
    }
}
