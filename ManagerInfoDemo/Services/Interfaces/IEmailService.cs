namespace ManagerInfoDemo.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string resetLink);
        Task SendCustomerVerificationEmailAsync(string toEmail, string verificationLink);
    }
}
