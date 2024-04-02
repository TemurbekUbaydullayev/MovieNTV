using Domain.Entities;

namespace Application.DTOs.MovieDtos;
public class AddMovieDto
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Country { get; set; } = "";
    public int Duration { get; set; }
    public int Year { get; set; }
    public string Company { get; set; } = "";
    public string Director { get; set; } = "";
    public int GenreId { get; set; }

    public static implicit operator Movie(AddMovieDto dto)
    {
        return new Movie
        {
            Title = dto.Title,
            Description = dto.Description,
            Country = dto.Country,
            Director = dto.Director,
            GenreId = dto.GenreId,
            Duration = dto.Duration,
            Year = dto.Year,
            Company = dto.Company
        };
    }
}
