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

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsAsync(cancellationToken));
        }
        public async Task<ProductDTO> GetByIdAsync(int? id, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id, cancellationToken));
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetProductCategoryAsync(id, cancellationToken));
        }

        public async Task<ProductDTO> AddAsync(ProductDTO dto, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(dto);
            return _mapper.Map<ProductDTO>(await _productRepository.CreateAsync(product, cancellationToken));
        }
        public async Task<ProductDTO> UpdateAsync(ProductDTO dto, CancellationToken cancellationToken)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.UpdateAsync(_mapper.Map<Product>(dto), cancellationToken));
        }

        public async Task DeleteAsync(int? id, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetByIdAsync(id, cancellationToken);
            await _productRepository.DeleteAsync(_mapper.Map<Product>(product), cancellationToken);
        }
    }
}
