using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.UserDTOs;
using ECommerce.Application.IServices;

namespace ECommerce.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserDTO user)
        {
            await _userService.Add(user);
            return Ok(new {status=true,errors=""});
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAll=await _userService.GetAll();
            return Ok(new { status = true, data = getAll, errors = "" });
        }
    }
}
