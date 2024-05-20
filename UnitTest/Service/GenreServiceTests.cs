using Application.Common.Exceptions;
using Application.DTOs.GenreDtos;
using Application.Interfaces;
using Application.Services;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using Moq;
using System.Net;

namespace UnitTest.Service;

public class GenreServiceTests
{
    private Mock<IUnitOfWork> mockUnitOfWork = new();
    private Mock<IValidator<Genre>> mockValidator = new();
    private IUnitOfWork unitOfWork;
    private IValidator<Genre> validator;
    private IGenreService service;

    [SetUp]
    public void Setup()
    {
        unitOfWork = mockUnitOfWork.Object;
        validator = mockValidator.Object;

        service = new GenreService(unitOfWork, validator);
    }

    [Test]
    [TestCase("Test1")]
    [TestCase("Test2")]
    [TestCase("Test3")]
    [TestCase("Test4")]
    public async Task AddGenreAsync_WhenGenreAllreadyExists_ThrowsStatusCodeException(string name)
    {
        var dto = new AddGenreDto() { Name = name };
        mockUnitOfWork.Setup(p => p.Genre.GetByNameAsync(dto.Name)).ReturnsAsync(new Genre());

        var exception = Assert.ThrowsAsync<StatusCodeExeption>(() => service.CreateAsync(dto));

        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.AlreadyReported));
        Assert.That(exception.Message, Is.EqualTo("janr oldin foydalanilgan"));
    }
}
