using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id, CancellationToken cancellationToken)
        {
            return _mapper.Map<CategoryDTO>(await _categoryRepository.GetByIdAsync(id.GetValueOrDefault(), cancellationToken));
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CategoryDTO>>(await _categoryRepository.GetCategoriesAsync(cancellationToken));
        }

        public async Task AddAsync(CategoryDTO dto, CancellationToken cancellationToken)
        {
            await _categoryRepository.CreateAsync(_mapper.Map<Category>(dto), cancellationToken);
        }

        public async Task UpdateAsync(CategoryDTO dto, CancellationToken cancellationToken)
        {
            await _categoryRepository.UpdateAsync(_mapper.Map<Category>(dto), cancellationToken);
        }

        public async Task DeleteAsync(int? id, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
            await _categoryRepository.DeleteAsync(_mapper.Map<Category>(category), cancellationToken);
        }
    }
}
