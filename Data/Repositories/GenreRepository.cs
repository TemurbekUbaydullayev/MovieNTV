namespace Data.Repositories;

public class GenreRepository(AppDbContext dbContext) : GenericRepository<Genre>(dbContext), IGenreRepository
{
}
