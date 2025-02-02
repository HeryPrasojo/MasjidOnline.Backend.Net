using System;
using System.Threading.Tasks;
using MasjidOnline.Api.Web;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Options;
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
using MasjidOnline.Service.Mail.Interface.Model;
using MasjidOnline.Service.Mail.MailKit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var webApplication = BuildApplication(args);

await InitializeAsync(webApplication);

var option = webApplication.Configuration.Get<Option>();

webApplication.UseMiddleware<ExceptionMiddleware>();

webApplication.UseCors();

webApplication.UseMiddleware<SessionMiddleware>();

webApplication.MapEndpoints();

webApplication.Run();


static WebApplication BuildApplication(string[] args)
{
    var webApplicationBuilder = WebApplication.CreateBuilder(args);

    webApplicationBuilder.Configuration.AddJsonFile("appsettings.Local.json", true, true);

    var option = webApplicationBuilder.Configuration.Get<Option>();

    webApplicationBuilder.Services.AddOptions<MailOption>("Mail");
    webApplicationBuilder.Services.AddOptions<Option>();

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
    webApplicationBuilder.Services.AddFieldValidatorService();
    webApplicationBuilder.Services.AddHash512Service();
    webApplicationBuilder.Services.AddMailKitMailService();

    webApplicationBuilder.Services.AddData();
    webApplicationBuilder.Services.AddSqLiteEntityFrameworkData(webApplicationBuilder.Configuration);
    webApplicationBuilder.Services.AddEntityIdGenerator();

    webApplicationBuilder.Services.AddDonationBusiness();
    webApplicationBuilder.Services.AddCaptchaBusiness();
    webApplicationBuilder.Services.AddUserBusiness();

    webApplicationBuilder.Services.AddScoped<Session>();

    #endregion


    webApplicationBuilder.WebHost.UseShutdownTimeout(TimeSpan.FromSeconds(16));

    return webApplicationBuilder.Build();
}


static async Task InitializeAsync(WebApplication webApplication)
{
    using var serviceScope = webApplication.Services.CreateScope();

    var auditData = GetService<IAuditData>(serviceScope.ServiceProvider);
    var coreData = GetService<ICoreData>(serviceScope.ServiceProvider);
    var captchaData = GetService<ICaptchaData>(serviceScope.ServiceProvider);
    var eventData = GetService<IEventData>(serviceScope.ServiceProvider);
    var transactionData = GetService<ITransactionsData>(serviceScope.ServiceProvider);
    var userData = GetService<IUsersData>(serviceScope.ServiceProvider);

    var auditInitializer = GetService<IAuditInitializer>(serviceScope.ServiceProvider);
    var coreInitializer = GetService<ICoreInitializer>(serviceScope.ServiceProvider);
    var captchaInitializer = GetService<ICaptchaInitializer>(serviceScope.ServiceProvider);
    var eventInitializer = GetService<IEventInitializer>(serviceScope.ServiceProvider);
    var transactionInitializer = GetService<ITransactionsInitializer>(serviceScope.ServiceProvider);
    var userInitializer = GetService<IUsersInitializer>(serviceScope.ServiceProvider);

    var auditIdGenerator = GetService<IAuditIdGenerator>(serviceScope.ServiceProvider);
    var coreIdGenerator = GetService<ICoreIdGenerator>(serviceScope.ServiceProvider);
    var captchaIdGenerator = GetService<ICaptchaIdGenerator>(serviceScope.ServiceProvider);
    var eventIdGenerator = GetService<IEventIdGenerator>(serviceScope.ServiceProvider);
    var transactionIdGenerator = GetService<ITransactionsIdGenerator>(serviceScope.ServiceProvider);
    var userIdGenerator = GetService<IUsersIdGenerator>(serviceScope.ServiceProvider);


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