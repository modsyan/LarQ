using LarQ.Configuration;

namespace LarQ.Startup;

public static class ConfigurationRegistrar
{
    public static void ConfigureBindingOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FileOptionModel>(configuration.GetSection(FileOptionModel.FileOption));
        services.Configure<EmailSenderOptionModel>(configuration.GetSection(EmailSenderOptionModel.EmailSenderOption));
    }
}