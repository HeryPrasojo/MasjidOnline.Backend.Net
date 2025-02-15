using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.FieldValidator;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFieldValidatorService(this IServiceCollection services)
    {
        services.AddSingleton<IFieldValidatorService, FieldValidatorService>();

        return services;
    }
}
