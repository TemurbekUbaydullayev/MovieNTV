namespace Data.Repositories;
public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public IGenreRepository Genre => new GenreRepository(_appDbContext);

    public IMovieRepository Movie => new MovieRepository(_appDbContext);

    public IUserRepository User => new UserRepository(_appDbContext);
}
