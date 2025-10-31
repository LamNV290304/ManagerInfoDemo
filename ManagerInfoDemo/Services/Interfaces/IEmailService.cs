namespace ManagerInfoDemo.Services.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string resetLink);
    }
}
