using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<CategoryDTO> GetById(int? id)
        {
            return _mapper.Map<CategoryDTO>(await _categoryRepository.GetByIdAsync(id.GetValueOrDefault()));
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return _mapper.Map<List<CategoryDTO>>(await _categoryRepository.GetCategoriesAsync());
        }

        public async Task Add(CategoryDTO dto)
        {
            await _categoryRepository.CreateAsync(_mapper.Map<Category>(dto));
        }

        public async Task Update(CategoryDTO dto)
        {
            await _categoryRepository.UpdateAsync(_mapper.Map<Category>(dto));
        }

        public async Task Delete(int? id)
        {
            await _categoryRepository.DeleteAsync(_mapper.Map<Category>(await _categoryRepository.GetByIdAsync(id)));
        }              
    }
}
