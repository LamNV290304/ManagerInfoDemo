using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using ManagerInfoDemo.Services.Interfaces;

namespace ManagerInfoDemo.Services
{
    public class SmtpSettings
    {
        public string Host { get; init; } = default!;
        public int Port { get; init; }
        public bool UseStartTls { get; init; }
        public string User { get; init; } = default!;
        public string Pass { get; init; } = default!;
        public string SenderEmail { get; init; } = default!;
        public string SenderName { get; init; } = default!;
    }

    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtp;

        public EmailService(IOptions<SmtpSettings> options) => _smtp = options.Value;

        public async Task SendEmailAsync(string toEmail, string resetLink)
        {
            if (!IsConfigured() || string.IsNullOrWhiteSpace(toEmail))
            {
                return;
            }

            var subject = "Đặt lại mật khẩu";
            var htmlBody = $"""
        <p>Xin chào,</p>

        <p>Bạn vừa yêu cầu đặt lại mật khẩu. Nhấn vào nút bên dưới 
           (hiệu lực 30 phút):</p>

        <p style="text-align:center;">
            <a href="{resetLink}"
               style="display:inline-block;
                      padding:12px 24px;
                      background-color:#0d6efd;
                      color:#ffffff;
                      text-decoration:none;
                      font-weight:bold;
                      border-radius:6px;">
                Đặt lại mật khẩu
            </a>
        </p>

        <p>Nếu không phải bạn, vui lòng bỏ qua e‑mail này.</p>

        <hr/>
    <small>© 2025 CozyShop</small>
    """;

            await SendAsync(toEmail, subject, htmlBody);
        }

        public async Task SendCustomerVerificationEmailAsync(string toEmail, string verificationLink)
        {
            if (!IsConfigured() || string.IsNullOrWhiteSpace(toEmail))
            {
                return;
            }

            var subject = "Xác nhận tài khoản khách hàng";
            var htmlBody = $"""
        <p>Xin chào,</p>

        <p>Cảm ơn bạn đã đăng ký. Vui lòng xác nhận e‑mail bằng cách nhấn nút dưới đây:</p>

        <p style="text-align:center;">
            <a href="{verificationLink}"
               style="display:inline-block;
                      padding:12px 24px;
                      background-color:#16a34a;
                      color:#ffffff;
                      text-decoration:none;
                      font-weight:bold;
                      border-radius:6px;">
                Xác nhận tài khoản
            </a>
        </p>

        <p>Nếu bạn không yêu cầu tạo tài khoản, hãy bỏ qua e‑mail này.</p>

        <hr/>
    <small>© 2025 CozyShop</small>
    """;

            await SendAsync(toEmail, subject, htmlBody);
        }

        private bool IsConfigured()
        {
            return !string.IsNullOrWhiteSpace(_smtp.Host)
                   && _smtp.Port > 0
                   && !string.IsNullOrWhiteSpace(_smtp.SenderEmail)
                   && !string.IsNullOrWhiteSpace(_smtp.User)
                   && !string.IsNullOrWhiteSpace(_smtp.Pass);
        }

        private async Task SendAsync(string toEmail, string subject, string htmlBody)
        {
            if (!IsConfigured())
            {
                return;
            }

            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(_smtp.SenderName, _smtp.SenderEmail));
            msg.To.Add(MailboxAddress.Parse(toEmail));
            msg.Subject = subject;
            msg.Body = new BodyBuilder
            {
                HtmlBody = htmlBody
            }.ToMessageBody();


            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(
                _smtp.Host,
                _smtp.Port,
                _smtp.UseStartTls ? SecureSocketOptions.StartTls : SecureSocketOptions.SslOnConnect);

            await smtp.AuthenticateAsync(_smtp.User, _smtp.Pass);
            await smtp.SendAsync(msg);
            await smtp.DisconnectAsync(true);
        }
    }
}
