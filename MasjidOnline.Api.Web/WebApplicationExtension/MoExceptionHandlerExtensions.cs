using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

internal static class MoExceptionHandlerExtensions
{
    internal static WebApplication UseCustomExceptionHandler(this WebApplication webApplication)
    {
        new ExceptionHandlerOptions
        {
            ExceptionHandler = async (httpContext) =>
            {
                using (var serviceScope = webApplication.Services.CreateScope())
                {
                    var dataAccess = serviceScope.ServiceProvider.GetService<ILoggingDataAccess>();

                    if (dataAccess == default)
                    {
                        throw new ApplicationException("Get IDataAccess service fail");
                    }
                }
            },
        };

        webApplication.UseExceptionHandler();

        return webApplication;
    }
}
