using Application.DTOs.MovieDtos;

namespace Application.Interfaces;

public interface IMovieService
{
    Task CreateAsync(AddMovieDto dto);
    Task UpdateAsync(MovieDto dto);
    Task DeleteAsync(int id);
    Task<List<MovieDto>> GetAllAsync();
    Task<MovieDto> GetByIdAsync(int id);
    Task<List<MovieDto>> GetByNameAsync(string name);
}