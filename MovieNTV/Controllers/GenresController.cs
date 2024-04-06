using Application.DTOs.GenreDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieNTV.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController(IGenreService genreService) : ControllerBase
{
    private readonly IGenreService _genreService = genreService;

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddGenreDto dto)
    {
        await _genreService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _genreService.GetAllAsync());
    }

    [HttpGet("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _genreService.GetByIdAsync(id));
    }

    [HttpDelete("{id}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _genreService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut, Authorize("Admin")]
    public async Task<IActionResult> UpdateAsync([FromForm] GenreDto dto)
    {
        await _genreService.UpdateAsync(dto);
        return Ok();
    }

}
