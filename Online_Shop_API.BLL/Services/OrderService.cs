using AutoMapper;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Enums;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return orderDtos;
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task UpdateAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.UpdateAsync(order);
        }
        public async Task<bool> AddItemToOrderAsync(int orderId, OrderDetailDto itemDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(itemDto);
            return await _orderRepository.AddItemToOrderAsync(orderId, orderDetail);
        }
        public async Task<bool> RemoveItemFromOrderAsync(int orderId, int orderDetailId)
        {
            return await _orderRepository.RemoveItemFromOrderAsync(orderId, orderDetailId);
        }
        public async Task<bool> ChangeOrderStatusAsync(int orderId, Status newStatus)
        {
            return await _orderRepository.ChangeOrderStatusAsync(orderId, newStatus);
        }
    }
}
