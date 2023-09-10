namespace LarQ.Configuration;

public class EmailSenderOptionModel
{
    public const string EmailSenderOption = "EmailSenderOption";

    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool EnableSSL { get; set; }

    public string DisplayName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}