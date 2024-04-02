using Domain.Entities;

namespace Application.DTOs.GenreDtos;
public class GenreDto : AddGenreDto
{
    public int Id { get; set; }

    public static implicit operator GenreDto(Genre genre)
    {
        return new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name,
            Description = genre.Description,
        };
    }
}
