using Karapinha.Model;
using Karapinha.Repositorios.Interface;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace Karapinha.Repositorios.Repositorio
{
    public class EmailRepositorio : IEmail
    {
        private readonly IConfiguration _config;

        public EmailRepositorio(IConfiguration config)
        {
            _config = config;
        }

        public void Send(Email request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(request.From));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config["EmailSettings:SmtpServer"], int.Parse(_config["EmailSettings:Port"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["EmailSettings:Username"], _config["EmailSettings:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}