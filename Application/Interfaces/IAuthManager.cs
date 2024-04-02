using Domain.Entities;
namespace Application.Interfaces;
public  interface IAuthManager
{
    string GeneratedToken(User user);
}
