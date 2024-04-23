using Application.DTOs.MovieDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieNTV.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController(IMovieService movieService) : ControllerBase
{
    private readonly IMovieService _movieService = movieService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm]AddMovieDto dto)
    {
        await _movieService.CreateAsync(dto);
        return Ok();
    }
    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id) 
    {
        return Ok(await _movieService.GetByIdAsync(id));
    }

    [HttpGet("movies")]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _movieService.GetAllAsync());
    }

    [HttpDelete("id")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _movieService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public async Task<IActionResult> UpdateAsync([FromForm]MovieDto dto)
    {
        await _movieService.UpdateAsync(dto);
        return Ok();
    }
}
