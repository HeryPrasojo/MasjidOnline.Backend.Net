using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

internal static class InitializeExtension
{
    internal static async Task<WebApplication> InitializeAsync(this WebApplication webApplication)
    {
        using var serviceScope = webApplication.Services.CreateScope();

        var data = serviceScope.ServiceProvider.GetServiceOrThrow<IData>();
        var dataInitializer = serviceScope.ServiceProvider.GetServiceOrThrow<IDataInitializer>();
        var service = serviceScope.ServiceProvider.GetServiceOrThrow<IService>();
        var business = serviceScope.ServiceProvider.GetServiceOrThrow<IBusiness>();

        var businessOptions = webApplication.Configuration.Get<BusinessOptions>() ?? throw new ApplicationException($"Get {nameof(BusinessOptions)} fail");

        await dataInitializer.InitializeAsync(data);

        await data.IdGenerator.InitializeAsync(data);

        service.Initialize([businessOptions.Directory.Infaq]);

        await business.InitializeAsync(data);

        return webApplication;
    }
}
