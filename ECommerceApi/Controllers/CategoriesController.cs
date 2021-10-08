using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.CategoryDTOs;
using ECommerce.Application.DTOs.CustomerDTOs;
using ECommerce.Application.Services.Category;
using ECommerce.Application.Services.Customer;

namespace ECommerce.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryDTO category)
        {
            await _categoryService.Add(category);
            return Ok(new { status = true, errors = "" });
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok(new { status = true, errors = "" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var getAll = _categoryService.GetAll();
            return Ok(new { status = true, data = getAll, errors = "" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getById = await _categoryService.GetById(id);
            return Ok(new { status = true, data = getById, errors = "" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] CategoryDTO category)
        {
            await _categoryService.Update(id, category);
            return Ok(new { status = true, errors = "" });
        }
    }
}
