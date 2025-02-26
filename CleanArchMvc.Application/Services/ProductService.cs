using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsAsync());
        }
        public async Task<ProductDTO> GetById(int? id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetProductCategoryAsync(id));
        }

        public async Task<ProductDTO> Add(ProductDTO dto)
        {
            Product product = _mapper.Map<Product>(dto);
            return _mapper.Map<ProductDTO>(await _productRepository.CreateAsync(product));
        }
        public async Task<ProductDTO> Update(ProductDTO dto)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.UpdateAsync(_mapper.Map<Product>(dto)));
        }

        public async Task Delete(int? id)
        {
            await _productRepository.DeleteAsync(_mapper.Map<Product>(await _productRepository.GetByIdAsync(id)));
        }
    }
}
