using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.CategoryDTOs;
using ECommerce.Application.DTOs.CustomerDTOs;

namespace ECommerce.Application.Services.Category
{
    public interface ICategoryService
    {
        Task Add(CategoryDTO categoryDTO);

        Task Delete(int id);

        Task Update(int id, CategoryDTO categoryDTO);

        List<CategoryDTO> GetAll();

        Task<CategoryDTO> GetById(int id);
    }
}
