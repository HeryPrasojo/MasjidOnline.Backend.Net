using MasjidOnline.Api.Model;
using MasjidOnline.Api.Web;
using MasjidOnline.Api.Web.WebApplicationExtension;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Donation;
using MasjidOnline.Data;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Log;
using MasjidOnline.Service.Captcha;
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

webApplicationBuilder.Services.AddHash512Service();

webApplicationBuilder.Services.AddSqLiteEntityFrameworkData(webApplicationBuilder.Configuration);

webApplicationBuilder.Services.AddEntityIdGenerator();

webApplicationBuilder.Services.AddDonationBusiness();

webApplicationBuilder.Services.AddCaptchaBusiness();

#endregion


var webApplication = webApplicationBuilder.Build();


#region initialize database

using (var serviceScope = webApplication.Services.CreateScope())
{
    serviceScope.ServiceProvider.GetService<ICoreInitializer>();
    serviceScope.ServiceProvider.GetService<ICaptchaInitializer>();
    serviceScope.ServiceProvider.GetService<ILogInitializer>();
}

#endregion


#region initialize EntityIdGenerator

webApplication.Services.GetService<ICoreIdGenerator>();
webApplication.Services.GetService<ICaptchaIdGenerator>();
webApplication.Services.GetService<ILogIdGenerator>();

#endregion


webApplication.UseMiddleware<ExceptionHandlerMiddleware>();

webApplication.UseCors();

webApplication.MapEndpoints();

webApplication.Run();
