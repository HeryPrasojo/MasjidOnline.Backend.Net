using System;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Web;
using MasjidOnline.Api.Web.WebApplicationExtension;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Data;
using MasjidOnline.Data.EntityFramework;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Service;
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


webApplicationBuilder.Services.AddService();

#endregion


var webApplication = webApplicationBuilder.Build();


#region initialize database, EntityIdGenerator

using (var serviceScope = webApplication.Services.CreateScope())
{
    var auditData = serviceScope.ServiceProvider.GetService<IAuditData>()
        ?? throw new ApplicationException($"Get {nameof(IAuditData)} service fail");

    var coreData = serviceScope.ServiceProvider.GetService<ICoreData>()
        ?? throw new ApplicationException($"Get {nameof(ICoreData)} service fail");

    var captchaData = serviceScope.ServiceProvider.GetService<ICaptchaData>()
        ?? throw new ApplicationException($"Get {nameof(ICaptchaData)} service fail");

    var eventData = serviceScope.ServiceProvider.GetService<IEventData>()
        ?? throw new ApplicationException($"Get {nameof(IEventData)} service fail");

    var transactionData = serviceScope.ServiceProvider.GetService<ITransactionData>()
        ?? throw new ApplicationException($"Get {nameof(ITransactionData)} service fail");

    var userData = serviceScope.ServiceProvider.GetService<IUserData>()
        ?? throw new ApplicationException($"Get {nameof(IUserData)} service fail");


    var auditInitializer = serviceScope.ServiceProvider.GetService<IAuditInitializer>()
        ?? throw new ApplicationException($"Get {nameof(IAuditInitializer)} service fail");

    var coreInitializer = serviceScope.ServiceProvider.GetService<ICoreInitializer>()
        ?? throw new ApplicationException($"Get {nameof(ICoreInitializer)} service fail");

    var captchaInitializer = serviceScope.ServiceProvider.GetService<ICaptchaInitializer>()
        ?? throw new ApplicationException($"Get {nameof(ICaptchaInitializer)} service fail");

    var eventInitializer = serviceScope.ServiceProvider.GetService<IEventInitializer>()
        ?? throw new ApplicationException($"Get {nameof(IEventInitializer)} service fail");

    var transactionInitializer = serviceScope.ServiceProvider.GetService<ITransactionInitializer>()
        ?? throw new ApplicationException($"Get {nameof(ITransactionInitializer)} service fail");

    var userInitializer = serviceScope.ServiceProvider.GetService<IUserInitializer>()
        ?? throw new ApplicationException($"Get {nameof(IUserInitializer)} service fail");


    var auditIdGenerator = serviceScope.ServiceProvider.GetService<IAuditIdGenerator>()
        ?? throw new ApplicationException($"Get {nameof(IAuditIdGenerator)} service fail");

    var coreIdGenerator = serviceScope.ServiceProvider.GetService<ICoreIdGenerator>()
        ?? throw new ApplicationException($"Get {nameof(ICoreIdGenerator)} service fail");

    var captchaIdGenerator = serviceScope.ServiceProvider.GetService<ICaptchaIdGenerator>()
        ?? throw new ApplicationException($"Get {nameof(ICaptchaIdGenerator)} service fail");

    var eventIdGenerator = serviceScope.ServiceProvider.GetService<IEventIdGenerator>()
        ?? throw new ApplicationException($"Get {nameof(IEventIdGenerator)} service fail");

    var transactionIdGenerator = serviceScope.ServiceProvider.GetService<ITransactionIdGenerator>()
        ?? throw new ApplicationException($"Get {nameof(ITransactionIdGenerator)} service fail");

    var userIdGenerator = serviceScope.ServiceProvider.GetService<IUserIdGenerator>()
        ?? throw new ApplicationException($"Get {nameof(IUserIdGenerator)} service fail");


    await auditInitializer.InitializeDatabaseAsync(auditData);
    await coreInitializer.InitializeDatabaseAsync(coreData);
    await captchaInitializer.InitializeDatabaseAsync(captchaData);
    await eventInitializer.InitializeDatabaseAsync(eventData);
    await transactionInitializer.InitializeDatabaseAsync(transactionData);
    await userInitializer.InitializeDatabaseAsync(userData);

    await auditIdGenerator.InitializeAsync(auditData);
    await coreIdGenerator.InitializeAsync(coreData);
    await captchaIdGenerator.InitializeAsync(captchaData);
    await eventIdGenerator.InitializeAsync(eventData);
    await transactionIdGenerator.InitializeAsync(transactionData);
    await userIdGenerator.InitializeAsync(userData);
}

#endregion


webApplication.UseMiddleware<ExceptionHandlerMiddleware>();

webApplication.UseCors();

webApplication.MapEndpoints();

webApplication.Run();
