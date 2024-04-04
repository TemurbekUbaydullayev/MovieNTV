using Application.DTOs.GenreDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieNTV.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController(IGenreService genreService) : ControllerBase
{
    private readonly IGenreService _genreService = genreService;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AddGenreDto dto)
    {
        await _genreService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _genreService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _genreService.GetByIdAsync(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _genreService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] GenreDto dto)
    {
        await _genreService.UpdateAsync(dto);
        return Ok();
    }

}
