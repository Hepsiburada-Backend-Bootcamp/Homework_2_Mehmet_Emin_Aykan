using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.BrandDTOs;
using ECommerce.Application.DTOs.CategoryDTOs;
using ECommerce.Application.Services.Brand;
using ECommerce.Application.Services.Category;

namespace ECommerce.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BrandDTO brand)
        {
            await _brandService.Add(brand);
            return Ok(new { status = true, errors = "" });
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _brandService.Delete(id);
            return Ok(new { status = true, errors = "" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var getAll = _brandService.GetAll();
            return Ok(new { status = true, data = getAll, errors = "" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getById = await _brandService.GetById(id);
            return Ok(new { status = true, data = getById, errors = "" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] BrandDTO brand)
        {
            await _brandService.Update(id, brand);
            return Ok(new { status = true, errors = "" });
        }
    }
}
