
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class MovieRepository(AppDbContext dbContext) : GenericRepository<Movie>(dbContext), IMovieRepository
{
    public async Task<List<Movie>> GetByNameAsync(string name)
    {
        var movies = await _dbContext.Movies.ToListAsync();

        return movies.Where(p => p.Title.ToLower().Contains(name.ToLower())).ToList();
    }
}
