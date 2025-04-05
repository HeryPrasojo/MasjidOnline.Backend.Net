using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
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

        var userInitializerBusiness = GetService<MasjidOnline.Business.User.Interface.IInitializerBusiness>(serviceScope.ServiceProvider);

        await dataInitializer.Audit.InitializeDatabaseAsync(data);
        await dataInitializer.Authorization.InitializeDatabaseAsync(data);
        await dataInitializer.Captcha.InitializeDatabaseAsync(data);
        await dataInitializer.Event.InitializeDatabaseAsync(data);
        await dataInitializer.Infaq.InitializeDatabaseAsync(data);
        await dataInitializer.Person.InitializeDatabaseAsync(data);
        await dataInitializer.Session.InitializeDatabaseAsync(data);
        await dataInitializer.User.InitializeDatabaseAsync(data);

        await idGenerator.Audit.InitializeAsync(data);
        await idGenerator.Event.InitializeAsync(data);
        await idGenerator.Infaq.InitializeAsync(data);
        await idGenerator.Person.InitializeAsync(data);
        await idGenerator.Session.InitializeAsync(data);
        await idGenerator.Session.InitializeAsync(data);

        await userInitializerBusiness.InitializeAsync(data);

        return webApplication;
    }

    private static TService GetService<TService>(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetService<TService>() ?? throw new ApplicationException($"Get {typeof(TService).Name} service fail");
    }
}
