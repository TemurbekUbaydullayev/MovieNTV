using Application.DTOs.MovieDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieNTV.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController(IMovieService movieService) : ControllerBase
{
    private readonly IMovieService _movieService = movieService;

    [HttpPost]
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
}
