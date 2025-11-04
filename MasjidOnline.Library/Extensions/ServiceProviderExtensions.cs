using System;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Library.Extensions;

public static class ServiceProviderExtensions
{
    public static TService GetServiceOrThrow<TService>(this IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<TService>() ?? throw new ApplicationException($"Get {typeof(TService).Name} service fail");
    }
}
