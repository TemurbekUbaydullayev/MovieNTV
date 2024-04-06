using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.DTOs.MovieDtos;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;

namespace Application.Services;

public class MovieService(IUnitOfWork unitOfWork,
                          IValidator<Movie> validator) 
    : IMovieService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Movie> _validator = validator;

    public async Task CreateAsync(AddMovieDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());
        await _unitOfWork.Movie.CreateAsync((Movie)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var movie = await _unitOfWork.Movie.GetByIdAsync(id);
        if (movie is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Movie mavjud emas");
        await _unitOfWork.Movie.DeleteAsync(movie);
    }

    public async Task<List<MovieDto>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movie.GetAllAsync();
        var genres = await _unitOfWork.Genre.GetAllAsync();

        var entities = new List<MovieDto>();

        foreach (var movie in movies)
        {
            var genre = genres.First(p => p.Id == movie.GenreId);
            var dto = (MovieDto)movie;
            dto.Genre = new Genre()
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
            };

            entities.Add(dto);
        }

        return entities;
    }

    public async Task<MovieDto> GetByIdAsync(int id)
    {
        var movie = await _unitOfWork.Movie.GetByIdAsync(id);
        if (movie is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Movie topilmadi");

        var genre = await _unitOfWork.Genre.GetByIdAsync(movie.GenreId);
        var entity = (MovieDto)movie;       


        entity.Genre = new Genre()
        {
            Id = genre.Id,
            Name = genre.Name,
            Description = genre.Description
        };

        return entity;
    }

    public Task<List<MovieDto>> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(MovieDto dto)
    {
        throw new NotImplementedException();
    }
}
