using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Temur",
                LastName = "Ubaydullayev",
                Email = "ubaydullayev117@gmail.com",
                Gender = Gender.Male,
                Password = "6596443e7768f0c1ae055535783a3b6fcd3c2efb4fc0725336e31e087c4d10fc",
                Role = Role.Admin
            });
    }
}
