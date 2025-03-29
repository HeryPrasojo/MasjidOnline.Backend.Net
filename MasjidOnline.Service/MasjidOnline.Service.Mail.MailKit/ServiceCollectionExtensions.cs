using MasjidOnline.Service.Mail.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Mail.MailKit;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMailKitMailService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailOptions>(configuration.GetSection("Mail"));

        services.AddSingleton<IMailSenderService, SmtpMailSenderService>();

        return services;
    }
}
