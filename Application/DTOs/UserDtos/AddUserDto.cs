using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs.UserDtos;
public class AddUserDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public Gender Gender { get; set; }
    public string Password { get; set; } = "";

    public static implicit operator User(AddUserDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Gender = dto.Gender,
            Password = dto.Password
        };

    }
}
