using System;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Web.WebApplicationExtension;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Donation;
using MasjidOnline.Data;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Captcha;
using MasjidOnline.Service.Hash512;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddCors(corsOptions =>
{
    corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://masjidonline.localhost")
            .WithExposedHeaders(Constant.HttpHeaderName.ResultCode, Constant.HttpHeaderName.ResultMessage)
            .AllowCredentials();
    });
});


#region add dependency

webApplicationBuilder.Services.AddCaptchaService();

webApplicationBuilder.Services.AddHash512Service();

webApplicationBuilder.Services.AddSqLiteEntityFrameworkDataAccess(webApplicationBuilder.Configuration);

webApplicationBuilder.Services.AddEntityIdGenerator();

webApplicationBuilder.Services.AddDonationBusiness();

webApplicationBuilder.Services.AddCaptchaBusiness();

#endregion


var webApplication = webApplicationBuilder.Build();


#region initialize database

using (var serviceScope = webApplication.Services.CreateScope())
{
    var dataAccessUpdate = serviceScope.ServiceProvider.GetService<ICoreDefinitionData>();

    if (dataAccessUpdate == default)
    {
        throw new ApplicationException("Get IEntityIdGenerator service fail");
    }

    await dataAccessUpdate.InitializeDatabaseAsync();
}

#endregion


#region initialize EntityIdGenerator

var entityIdGenerator = webApplication.Services.GetService<IEntityIdGenerator>();

if (entityIdGenerator == default)
{
    throw new ApplicationException("Get IEntityIdGenerator service fail");
}

using (var serviceScope = webApplication.Services.CreateScope())
{
    var dataAccess = serviceScope.ServiceProvider.GetService<ICoreData>();

    if (dataAccess == default)
    {
        throw new ApplicationException("Get IDataAccess service fail");
    }

    await entityIdGenerator.InitializeAsync(dataAccess);
}

#endregion


webApplication.UseCustomExceptionHandler();

webApplication.UseCors();

webApplication.MapEndpoints();

webApplication.Run();
