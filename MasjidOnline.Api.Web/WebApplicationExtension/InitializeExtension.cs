using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

internal static class InitializeExtension
{
    internal static async Task<WebApplication> InitializeAsync(this WebApplication webApplication)
    {
        using var serviceScope = webApplication.Services.CreateScope();

        var data = GetService<IData>(serviceScope.ServiceProvider);

        var auditInitializer = GetService<IAuditInitializer>(serviceScope.ServiceProvider);
        var captchaInitializer = GetService<ICaptchaInitializer>(serviceScope.ServiceProvider);
        var eventInitializer = GetService<IEventInitializer>(serviceScope.ServiceProvider);
        var infaqInitializer = GetService<IInfaqInitializer>(serviceScope.ServiceProvider);
        var personInitializer = GetService<IPersonInitializer>(serviceScope.ServiceProvider);
        var sessionInitializer = GetService<ISessionInitializer>(serviceScope.ServiceProvider);
        var userInitializer = GetService<IUserInitializer>(serviceScope.ServiceProvider);

        var idGenerator = GetService<IIdGenerator>(serviceScope.ServiceProvider);

        var userInitializerBusiness = GetService<MasjidOnline.Business.User.Interface.IInitializerBusiness>(serviceScope.ServiceProvider);


        await auditInitializer.InitializeDatabaseAsync(data);
        await captchaInitializer.InitializeDatabaseAsync(data);
        await eventInitializer.InitializeDatabaseAsync(data);
        await infaqInitializer.InitializeDatabaseAsync(data);
        await personInitializer.InitializeDatabaseAsync(data);
        await sessionInitializer.InitializeDatabaseAsync(data);
        await userInitializer.InitializeDatabaseAsync(data);


        await idGenerator.Audit.InitializeAsync(data);
        await idGenerator.Captcha.InitializeAsync(data);
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
