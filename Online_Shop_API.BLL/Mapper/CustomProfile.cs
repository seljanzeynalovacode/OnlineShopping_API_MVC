using AutoMapper;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.DAL.Entities;

namespace Online_Shop_API.BLL.Mapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Customer,CustomerDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
