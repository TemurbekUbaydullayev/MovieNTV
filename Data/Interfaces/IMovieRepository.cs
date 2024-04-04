namespace Data.Interfaces;

public interface IMovieRepository : IGenericRepository<Movie>
{
    Task<List<Movie>> GetByNameAsync(string name);
}
