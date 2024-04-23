namespace Application.Interfaces;

public interface IEmailService
{
    Task SendMessageAsync(string to, string subject, string message);
}
