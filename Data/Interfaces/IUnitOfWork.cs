namespace Data.Interfaces;
public interface IUnitOfWork
{
    IGenreRepository Genre { get; }
    IMovieRepository Movie { get; }
    IUserRepository User { get; }
}
