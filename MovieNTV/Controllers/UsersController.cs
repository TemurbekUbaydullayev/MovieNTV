using Application.DTOs.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieNTV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpGet("users")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateUserDto dto)
        {
            var id = int.Parse(HttpContext.User.FindFirst("Id")!.Value);

            await _userService.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
