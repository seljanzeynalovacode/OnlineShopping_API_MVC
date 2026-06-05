using AutoMapper;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.BLL.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(OrderDetailDto orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            await _orderDetailRepository.AddAsync(orderDetail);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderDetailRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAllAsync()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            var orderDetailDtos = _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetails);
            return orderDetailDtos;
        }

        public async Task<OrderDetailDto> GetByIdAsync(int id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
            return orderDetailDto;
        }

        public async Task UpdateAsync(OrderDetailDto orderDetailDto)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDto);
            await _orderDetailRepository.UpdateAsync(orderDetail);
        }
    }
}
