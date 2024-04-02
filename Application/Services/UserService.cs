using Application.Common.Exceptions;
using Application.Common.Helper;
using Application.DTOs.UserDtos;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using System.Net;

namespace Application.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task DeleteAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");
        await _unitOfWork.User.DeleteAsync(user);
        throw new StatusCodeExeption(HttpStatusCode.OK, "User has been deleted sucessfully");
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.User.GetAllAsync();
        return users.Select(x => (UserDto)x).ToList();
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");
        return (UserDto)user;
    }

    public async Task UpdateAsync(UpdateUserDto dto)
    {
        var model = await _unitOfWork.User.GetByIdAsync(dto.Id);
        if (model is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found");
        var user = (User)dto;
        user.CreatedAt = TimeHelper.GetCurrentTime();
        user.Password = model.Password;

        await _unitOfWork.User.UpdateAsync(user);
        throw new StatusCodeExeption(HttpStatusCode.OK, "User has been updated sucessfully");
    }
}
