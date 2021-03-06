using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.CustomerDTOs;
using ECommerce.Application.Services.Customer;

namespace ECommerce.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerDTO customer)
        {
            await _customerService.Add(customer);
            return Ok(new { status = true, errors = "" });
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.Delete(id);
            return Ok(new { status = true, errors = "" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var getAll = _customerService.GetAll();
            return Ok(new { status = true, data = getAll, errors = "" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getById =await _customerService.GetById(id);
            return Ok(new { status = true, data = getById, errors = "" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id,[FromBody] CreateCustomerDTO customer)
        {
            await _customerService.Update(id,customer);
            return Ok(new { status = true, errors = "" });
        }
    }
}
