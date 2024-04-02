
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepository(AppDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
        => await _dbContext.Users.FirstOrDefaultAsync(mail => mail.Email == email);
}
