using Application.Common.Exceptions;
using Application.Common.Security;
using Application.Common.Validators;
using Application.DTOs.UserDtos;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace Application.Services;

public class AccountService(IUnitOfWork ofWork,
                            IAuthManager authManager,
                            IValidator<User> validator,
                            IMemoryCache cache,
                            IEmailService emailService)
    : IAccountService
{

    public IAuthManager _auth = authManager;

    private readonly IUnitOfWork _ofWork = ofWork;
    private readonly IValidator<User> _validator = validator;
    private readonly IMemoryCache _cache = cache;
    private readonly IEmailService _emailService = emailService;

    public async Task<string> LoginAsync(LoginDto login)
    {
        var user = await _ofWork.User.GetByEmailAsync(login.Email);

        if (user is null) throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        if (!user.Password.Equals(PasswordHasher.GetHash(login.Password)))
            throw new StatusCodeExeption(HttpStatusCode.Conflict, "Password incorrect!");
        if (!user.IsVerified)
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "User is not verified!");

        return _auth.GeneratedToken(user);
    }

    public async Task<bool> RegistrAsync(AddUserDto dto)
    {
        var user = await _ofWork.User.GetByEmailAsync(dto.Email);

        if (user is not null) throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "User already exists!");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        var entity = (User)dto;
        entity.Password = PasswordHasher.GetHash(entity.Password);

        await _ofWork.User.CreateAsync(entity);

        return true;
    }

    public async Task SendCodeAsync(string email)
    {
        var user = await _ofWork.User.GetByEmailAsync(email);
        if(user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");
        var code = GeneratedCode();
        _cache.Set(email, code, TimeSpan.FromSeconds(60));
        await _emailService.SendMessageAsync(email, "Verification code!", code);
    }

    public async Task<bool> CheckCodeAsync(string email, string code)
    {
        var user = await _ofWork.User.GetByEmailAsync(email);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");
        if (_cache.TryGetValue(email, out var result))
        {
            if (code.Equals(result))
            {
                user.IsVerified = true;
                await _ofWork.User.UpdateAsync(user);
                return true;
            }
            else
                throw new StatusCodeExeption(HttpStatusCode.Conflict, "Code is incorrect!");
        }
        else
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "Code expired!");
    }
    private string GeneratedCode()
        => (new Random().Next(10000, 99999)).ToString();
}
