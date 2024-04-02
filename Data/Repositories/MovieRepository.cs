namespace Data.Repositories;

public class MovieRepository(AppDbContext dbContext) : GenericRepository<Movie>(dbContext), IMovieRepository
{
}
