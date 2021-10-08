using ECommerce.Application.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Repositories;

namespace ECommerce.Application.Services.Category
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

        public async Task Add(CategoryDTO categoryDTO)
        {
            var entered = _mapper.Map<Domain.Entities.Category>(categoryDTO);
            var category = _categoryRepository.Get(c => c.CategoryName == entered.CategoryName ).Result;
            if (category.Equals(null))
            {
                await _categoryRepository.Add(_mapper.Map<Domain.Entities.Category>(categoryDTO));
            }
            throw new Exception("Already exist");
        }

        public async Task Delete(int id)
        {
            var category = _categoryRepository.Get(c => c.Id == id).Result;
            if (category.Equals(null))
            {
                throw new Exception("Not exist");
            }
            await _categoryRepository.Delete(category);
        }

        public List<CategoryDTO> GetAll()
        {
            var categoryList = _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDTO>>(categoryList);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _categoryRepository.Get(c => c.Id == id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Update(int id, CategoryDTO categoryDTO)
        {
            var category = _categoryRepository.Get(c => c.Id == id).Result;
            if (category.Equals(null))
            {
                throw new Exception("Not exist");
            }
            var changed = _mapper.Map<Domain.Entities.Category>(categoryDTO);
            category.CategoryName = changed.CategoryName;

            await _categoryRepository.Update(category);
        }
    }
}
