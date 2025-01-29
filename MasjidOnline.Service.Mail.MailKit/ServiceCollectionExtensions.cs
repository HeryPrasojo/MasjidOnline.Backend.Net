using MasjidOnline.Service.Mail.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Mail.MailKit;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMailKitMailService(this IServiceCollection services)
    {
        services.AddSingleton<IMailSenderService, SmtpMailSenderService>();

        return services;
    }
}
