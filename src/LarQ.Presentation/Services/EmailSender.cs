using System.Net;
using System.Net.Mail;
using LarQ.Configuration;
using LarQ.Services.Contracts;
using Microsoft.Extensions.Options;

namespace LarQ.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger<IEmailSender> _logger;
    private readonly EmailSenderOptionModel _options;

    public EmailSender(ILogger<IEmailSender> logger, IOptions<EmailSenderOptionModel> options)
    {
        _logger = logger;
        _options = options.Value;
    }

    public void SendEmail(string toEmail, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage(_options.UserName, toEmail, subject, htmlMessage) { IsBodyHtml = true };

        var client = new SmtpClient(_options.Host)
        {
            Credentials = new NetworkCredential(_options.UserName, _options.Password),
            Port = _options.Port,
            EnableSsl = _options.EnableSSL,
            UseDefaultCredentials = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
        };

        client.Send(mailMessage);
    }

    public Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage(_options.UserName, toEmail, subject, htmlMessage) { IsBodyHtml = true };

        var client = new SmtpClient(_options.Host)
        {
            Credentials = new NetworkCredential(_options.UserName, _options.Password),
            Port = _options.Port,
            EnableSsl = _options.EnableSSL,
            UseDefaultCredentials = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
        };

        return client.SendMailAsync(mailMessage);
    }
}