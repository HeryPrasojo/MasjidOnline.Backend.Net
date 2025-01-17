using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.FieldValidator;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFieldValidator(this IServiceCollection services)
    {
        services.AddSingleton<IFieldValidatorService, FieldValidatorService>();

        return services;
    }
}
