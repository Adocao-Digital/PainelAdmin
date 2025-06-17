using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using PainelAdmin.Entities;
using System.Net.Mail;

namespace PainelAdmin.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string assunto, string mensagemTexto, string mensagemHTML);
    }
    public class EmailService : IEmailSender
    {
        private readonly EmailConfig _emailConfig;
        public EmailService(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmailAsync(string email, string assunto, string mensagemTexto, string mensagemHTML)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress(_emailConfig.NomeRemetente, _emailConfig.EmailRemetente));
            mensagem.To.Add(MailboxAddress.Parse(email));

            mensagem.Subject = assunto;
            var builder = new BodyBuilder { TextBody = mensagemTexto, HtmlBody  = mensagemHTML };
            mensagem.Body = builder.ToMessageBody();

            try
            {
                using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
                await smtpClient.ConnectAsync(
                    _emailConfig.EnderecoServidor,
                    int.Parse(_emailConfig.Porta),
                    SecureSocketOptions.StartTls 
                );
                await smtpClient.AuthenticateAsync(_emailConfig.EmailRemetente, _emailConfig.Senha);
                await smtpClient.SendAsync(mensagem);
                await smtpClient.DisconnectAsync(true);
            }
            catch(Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
