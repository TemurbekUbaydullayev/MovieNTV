using Domain.Entities;

namespace Application.DTOs.GenreDtos;
public class AddGenreDto
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public static implicit operator Genre(AddGenreDto dto)
    {
        return new Genre
        {
            Name = dto.Name,
            Description = dto.Description
        };
    } 
}
