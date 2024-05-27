namespace OnlineCoursePlatform.Services;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string message);
}
