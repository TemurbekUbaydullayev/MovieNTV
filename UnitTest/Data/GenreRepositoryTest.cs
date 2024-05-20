using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UnitTest.Helpers;

namespace UnitTest.Data;
internal class GenreRepositoryTest
{
    AppDbContext dbContext;
    IUnitOfWork unitOfWork;

    [SetUp]
    public void Setup()
    {
        dbContext = DbContextHelper.GetDbContext();
        unitOfWork = DbContextHelper.GetUnitOfWork();
    }

    [Test]
    [TestCase("Test2")]
    [TestCase("Test3")]
    [TestCase("Test4")]
    [TestCase("Test5")]
    [TestCase("Test6")]
    [TestCase("Test7")]
    public async Task AddAsync(string name)
    {
        var genre = new Genre() { Name = name, Description = "Test uchun" };

        await unitOfWork.Genre.CreateAsync(genre);

        var result = await dbContext.Genres.FirstOrDefaultAsync(p => p.Name == name);

        Assert.That(genre.Name, Is.EqualTo(result!.Name));
    }

    [TearDown]
    public void Teardown()
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}