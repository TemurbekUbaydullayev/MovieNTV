using Application.DTOs.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieNTV.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost("registr")]
    public async Task<IActionResult> RegistrAsync([FromForm] AddUserDto dto)
    {
        var result = await _accountService.RegistrAsync(dto);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
    {
        var result = await _accountService.LoginAsync(dto);
        return Ok($"Token : {result}");
    }
}
