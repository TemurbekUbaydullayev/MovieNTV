using Application.DTOs.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieNTV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateUserDto dto)
        {
            await _userService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync( int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
