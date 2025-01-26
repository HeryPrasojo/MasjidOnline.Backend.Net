using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Web;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.User;
using MasjidOnline.Data;
using MasjidOnline.Data.EntityFramework;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Service.Captcha;
using MasjidOnline.Service.FieldValidator;
using MasjidOnline.Service.Hash512;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var webApplication = BuildApplication(args);

await InitializeAsync(webApplication);

webApplication.UseMiddleware<ExceptionHandlerMiddleware>();

webApplication.UseCors();

webApplication.MapEndpoints();

webApplication.Run();


static WebApplication BuildApplication(string[] args)
{
    var webApplicationBuilder = WebApplication.CreateBuilder(args);

    webApplicationBuilder.Configuration.AddJsonFile("appsettings.Local.json", true);

    webApplicationBuilder.Services.AddCors(corsOptions =>
    {
        corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins("http://masjidonline.localhost")
                .WithExposedHeaders(MasjidOnline.Api.Web.Constant.HttpHeaderName.ResultCode, MasjidOnline.Api.Web.Constant.HttpHeaderName.ResultMessage)
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
    webApplicationBuilder.Services.AddUserBusiness();

    webApplicationBuilder.Services.AddScoped<UserSession>();

    #endregion


    return webApplicationBuilder.Build();
}


static async Task InitializeAsync(WebApplication webApplication)
{
    using var serviceScope = webApplication.Services.CreateScope();

    var auditData = GetService<IAuditData>(serviceScope.ServiceProvider);
    var coreData = GetService<ICoreData>(serviceScope.ServiceProvider);
    var captchaData = GetService<ICaptchaData>(serviceScope.ServiceProvider);
    var eventData = GetService<IEventData>(serviceScope.ServiceProvider);
    var transactionData = GetService<ITransactionData>(serviceScope.ServiceProvider);
    var userData = GetService<IUserData>(serviceScope.ServiceProvider);

    var auditInitializer = GetService<IAuditInitializer>(serviceScope.ServiceProvider);
    var coreInitializer = GetService<ICoreInitializer>(serviceScope.ServiceProvider);
    var captchaInitializer = GetService<ICaptchaInitializer>(serviceScope.ServiceProvider);
    var eventInitializer = GetService<IEventInitializer>(serviceScope.ServiceProvider);
    var transactionInitializer = GetService<ITransactionInitializer>(serviceScope.ServiceProvider);
    var userInitializer = GetService<IUserInitializer>(serviceScope.ServiceProvider);

    var auditIdGenerator = GetService<IAuditIdGenerator>(serviceScope.ServiceProvider);
    var coreIdGenerator = GetService<ICoreIdGenerator>(serviceScope.ServiceProvider);
    var captchaIdGenerator = GetService<ICaptchaIdGenerator>(serviceScope.ServiceProvider);
    var eventIdGenerator = GetService<IEventIdGenerator>(serviceScope.ServiceProvider);
    var transactionIdGenerator = GetService<ITransactionIdGenerator>(serviceScope.ServiceProvider);
    var userIdGenerator = GetService<IUserIdGenerator>(serviceScope.ServiceProvider);


    await auditInitializer.InitializeDatabaseAsync(auditData);
    await coreInitializer.InitializeDatabaseAsync(coreData);
    await captchaInitializer.InitializeDatabaseAsync(captchaData);
    await eventInitializer.InitializeDatabaseAsync(eventData);
    await transactionInitializer.InitializeDatabaseAsync(transactionData);
    await userInitializer.InitializeDatabaseAsync(userData);


    var userAdditionBusiness = GetService<MasjidOnline.Business.User.Interface.IAdditionBusiness>(serviceScope.ServiceProvider);

    // undone 1
    //userAdditionBusiness.;


    await auditIdGenerator.InitializeAsync(auditData);
    await coreIdGenerator.InitializeAsync(coreData);
    await captchaIdGenerator.InitializeAsync(captchaData);
    await eventIdGenerator.InitializeAsync(eventData);
    await transactionIdGenerator.InitializeAsync(transactionData);
    await userIdGenerator.InitializeAsync(userData);
}

static TService GetService<TService>(IServiceProvider serviceProvider)
{
    return serviceProvider.GetService<TService>() ?? throw new ApplicationException($"Get {typeof(TService).Name} service fail");
}