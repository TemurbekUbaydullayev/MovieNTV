using Application.DTOs.GenreDtos;

namespace Application.Interfaces;

public interface IGenreService
{
    Task CreateAsync(AddGenreDto dto);
    Task UpdateAsync(GenreDto dto);
    Task DeleteAsync(int id);
    Task<List<GenreDto>> GetAllAsync();
    Task<GenreDto?> GetByIdAsync(int id);
}
