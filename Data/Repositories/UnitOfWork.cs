namespace Data.Repositories;
public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext appDbContext = appDbContext;

    public IGenreRepository Genre => new GenreRepository(appDbContext);

    public IMovieRepository Movie => new MovieRepository(appDbContext);

    public IUserRepository User => new UserRepository(appDbContext);
}
