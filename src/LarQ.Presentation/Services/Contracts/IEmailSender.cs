namespace LarQ.Services.Contracts;

public interface IEmailSender
{
    public Task SendEmailAsync(string toEmail, string subject, string htmlMessage);
    public void SendEmail(string toEmail, string subject, string htmlMessage);
}