namespace Data.Interfaces;

public interface IGenreRepository : IGenericRepository<Genre>
{
    Task<Genre?> GetByNameAsync(string name);
}
