using Domain.Entities;

namespace Application.DTOs.MovieDtos;
public class MovieDto : AddMovieDto
{
    public int Id { get; set; }

    public static implicit operator MovieDto (Movie movie)
    {
        return new MovieDto()
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Duration = movie.Duration,
            Company = movie.Company,
            Director = movie.Director,
            Country = movie.Country,
            GenreId = movie.GenreId,
            Year   = movie.Year,    
        };

    }
}
