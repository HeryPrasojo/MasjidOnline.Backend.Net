using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

internal static class InitializeExtension
{
    internal static async Task<WebApplication> InitializeAsync(this WebApplication webApplication)
    {
        using var serviceScope = webApplication.Services.CreateScope();

        var data = GetService<IData>(serviceScope.ServiceProvider);
        var dataInitializer = GetService<IDataInitializer>(serviceScope.ServiceProvider);
        var idGenerator = GetService<IIdGenerator>(serviceScope.ServiceProvider);
        var service = GetService<IService>(serviceScope.ServiceProvider);
        var business = GetService<IBusiness>(serviceScope.ServiceProvider);

        await dataInitializer.InitializeAsync(data);

        await idGenerator.InitializeAsync(data);

        service.Initialize([Business.Model.Constant.Path.InfaqFileDirectory]);

        await business.InitializeAsync(data);

        return webApplication;
    }

    private static TService GetService<TService>(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<TService>() ?? throw new ApplicationException($"Get {typeof(TService).Name} service fail");
    }
}
