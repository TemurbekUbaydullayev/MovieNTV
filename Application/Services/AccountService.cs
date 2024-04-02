using Application.Common.Exceptions;
using Application.Common.Security;
using Application.DTOs.UserDtos;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using System.Net;

namespace Application.Services;

public class AccountService(IUnitOfWork ofWork, IAuthManager authManager) : IAccountService
{
    private readonly IUnitOfWork _ofWork = ofWork;

    public IAuthManager _auth = authManager;

    public async Task<string> LoginAsync(LoginDto login)
    {
        var user = await _ofWork.User.GetByEmailAsync(login.Email);

        if(user is null) throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        if (!user.Password.Equals(PasswordHasher.GetHash(login.Password)))
            throw new StatusCodeExeption(HttpStatusCode.Conflict, "Password incorrect!");

        return _auth.GeneratedToken(user);
    }

    public async Task<bool> RegistrAsync(AddUserDto dto)
    {
        var user = await _ofWork.User.GetByEmailAsync(dto.Email);

        if (user is not null) throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "User already exists!");

        var entity = (User)dto;
        entity.Password = PasswordHasher.GetHash(entity.Password);

        await _ofWork.User.CreateAsync(entity);

        return true;
    }
}
