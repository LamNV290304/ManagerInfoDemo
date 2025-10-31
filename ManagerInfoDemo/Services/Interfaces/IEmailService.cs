namespace ManagerInfoDemo.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string resetLink);
    }
}
