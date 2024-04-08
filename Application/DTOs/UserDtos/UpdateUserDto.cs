using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs.UserDtos;

public class UpdateUserDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public Gender Gender { get; set; }

    public static implicit operator User(UpdateUserDto dto)
    {
        return new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Gender = dto.Gender,
        };
    }
}
