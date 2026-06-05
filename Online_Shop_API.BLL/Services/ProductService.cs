using AutoMapper;
using Online_Shop_API.BLL.Dtos;
using Online_Shop_API.BLL.Services.Interfaces;
using Online_Shop_API.DAL.Entities;
using Online_Shop_API.DAL.Repositories.Interfaces;

namespace Online_Shop_API.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);

        }
        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);

        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productDtos;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }
        public async Task UpdateAsync(ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productDto.Id);
            if (existingProduct != null)
            {
                _mapper.Map(productDto, existingProduct);
                await _productRepository.UpdateAsync(existingProduct);
            }
        }
    }
}
