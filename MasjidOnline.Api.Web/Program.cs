using System;
using MasjidOnline.Api.Web;
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

webApplicationBuilder.Services.AddCaptchaService();

webApplicationBuilder.Services.AddHash512Service();

webApplicationBuilder.Services.AddSqLiteEntityFrameworkDataAccess(webApplicationBuilder.Configuration);

webApplicationBuilder.Services.AddEntityIdGenerator();

webApplicationBuilder.Services.AddDonationBusiness();

webApplicationBuilder.Services.AddCaptchaBusiness();


var webApplication = webApplicationBuilder.Build();


var entityIdGenerator = webApplication.Services.GetService<IEntityIdGenerator>();

if (entityIdGenerator == default)
{
    throw new ApplicationException("Get IEntityIdGenerator service fail");
}

using (var scope = webApplication.Services.CreateScope())
{
    var dataAccess = scope.ServiceProvider.GetService<IDataAccess>();

    if (dataAccess == default)
    {
        throw new ApplicationException("Get IDataAccess service fail");
    }

    await entityIdGenerator.InitializeAsync(dataAccess);
}


//webApplication.UseHttpsRedirection();

webApplication.MapEndpoint();

webApplication.Run();
