using System;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Web;
using MasjidOnline.Api.Web.WebApplicationExtension;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Data;
using MasjidOnline.Data.EntityFramework;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Service.Captcha;
using MasjidOnline.Service.FieldValidator;
using MasjidOnline.Service.Hash512;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Configuration.AddJsonFile("appsettings.Local.json", true);

webApplicationBuilder.Services.AddCors(corsOptions =>
{
    corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://masjidonline.localhost")
            .WithExposedHeaders(Constant.HttpHeaderName.ResultCode, Constant.HttpHeaderName.ResultMessage)
            .AllowCredentials()
            .AllowAnyHeader();
    });
});


#region add dependency

webApplicationBuilder.Services.AddCaptchaService();

webApplicationBuilder.Services.AddFieldValidator();

webApplicationBuilder.Services.AddHash512Service();


webApplicationBuilder.Services.AddData();

webApplicationBuilder.Services.AddSqLiteEntityFrameworkData(webApplicationBuilder.Configuration);

webApplicationBuilder.Services.AddEntityIdGenerator();


webApplicationBuilder.Services.AddDonationBusiness();

webApplicationBuilder.Services.AddCaptchaBusiness();

#endregion


var webApplication = webApplicationBuilder.Build();


#region initialize database

using (var serviceScope = webApplication.Services.CreateScope())
{
    var initializers = new IInitializer?[]
    {
        serviceScope.ServiceProvider.GetService<ICoreInitializer>(),
        serviceScope.ServiceProvider.GetService<ICaptchaInitializer>(),
        serviceScope.ServiceProvider.GetService<IEventInitializer>(),
        serviceScope.ServiceProvider.GetService<ITransactionInitializer>(),
        serviceScope.ServiceProvider.GetService<IUserInitializer>(),
    };

    foreach (var initializer in initializers)
    {
        if (initializer == default)
        {
            throw new ApplicationException("Get IInitializer service fail");
        }

        await initializer.InitializeDatabaseAsync();
    }
}

#endregion


#region initialize EntityIdGenerator

webApplication.Services.GetService<ICoreIdGenerator>();
webApplication.Services.GetService<ICaptchaIdGenerator>();
webApplication.Services.GetService<IEventIdGenerator>();
webApplication.Services.GetService<ITransactionIdGenerator>();
webApplication.Services.GetService<IUserIdGenerator>();

#endregion


webApplication.UseMiddleware<ExceptionHandlerMiddleware>();

webApplication.UseCors();

webApplication.MapEndpoints();

webApplication.Run();
