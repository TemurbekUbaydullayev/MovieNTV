using Application.DTOs.GenreDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieNTV.Controllers;

namespace UnitTest.Controller;

internal class GenresControllerTests
{
    private Mock<IGenreService> serviceMock = new();
    private GenresController controller;

    [SetUp]
    public void Setup()
    {
        serviceMock = new Mock<IGenreService>();
        controller = new GenresController(serviceMock.Object);
    }

    [Test]
    public async Task GetAllAsync()
    {
        var genres = new List<GenreDto>
        {
            new GenreDto { Id = 1, Name = "Test1" },
            new GenreDto { Id = 2, Name = "Test2" },
            new GenreDto { Id = 3, Name = "Test3" }
        };

        serviceMock.Setup(p => p.GetAllAsync())
                                           .ReturnsAsync(genres)
                                           .Verifiable();

        var result = await controller.GetAllAsync();

        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;

        Assert.That(okResult!.Value, Is.InstanceOf<List<GenreDto>>());
        Assert.That(okResult.Value, Is.EqualTo(genres));
    }
}
