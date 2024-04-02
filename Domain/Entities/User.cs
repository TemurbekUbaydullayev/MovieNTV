using Domain.Enums;

namespace Domain.Entities;

public class User : Base
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public Gender Gender { get; set; }
    public string Password { get; set; } = "";
    public Role Role { get; set; }
}
