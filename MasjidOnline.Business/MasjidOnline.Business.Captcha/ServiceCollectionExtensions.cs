using MasjidOnline.Business.Captcha.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Captcha;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCaptchaBusiness(this IServiceCollection services)
    {
        services.AddSingleton<ICaptchaQuestionBusiness, CaptchaQuestionBusiness>();

        services.AddSingleton<ICaptchaAnswerBusiness, CaptchaAnswerBusiness>();

        return services;
    }
}
