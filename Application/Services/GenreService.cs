using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.DTOs.GenreDtos;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;

namespace Application.Services;

public class GenreService(IUnitOfWork unitOfWork,
                          IValidator<Genre> validator)
                        : IGenreService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Genre> _validator = validator;

    public async Task CreateAsync(AddGenreDto dto)
    {
        var genre = await _unitOfWork.Genre.GetByNameAsync(dto.Name);
        if (genre != null)
            throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "janr oldin foydalanilgan");
        //var result = await _validator.ValidateAsync(dto);
        //if (!result.IsValid)
        //    throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Genre.CreateAsync((Genre)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await _unitOfWork.Genre.GetByIdAsync(id);
        if (genre is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Janr yo'q");

        await _unitOfWork.Genre.DeleteAsync(genre);
    }

    public async Task<List<GenreDto>> GetAllAsync()
    {
        var genres = await _unitOfWork.Genre.GetAllAsync();

        return genres.Select(item => (GenreDto)item).ToList();
    }

    public async Task<GenreDto?> GetByIdAsync(int id)
    {
        var genre = await _unitOfWork.Genre.GetByIdAsync(id);
        if (genre is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Janr mavjud emas");

        return (GenreDto)genre;
    }

    public async Task UpdateAsync(GenreDto dto)
    {
        var genre = await _unitOfWork.Genre.GetByIdAsync(dto.Id);
        if (genre is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Janr yo'q");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Genre.UpdateAsync((Genre)dto);
    }
}
