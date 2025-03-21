using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MasjidOnline.Api.Web;
using MasjidOnline.Api.Web.Middleware;
using MasjidOnline.Business.AuthorizationBusiness;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Session;
using MasjidOnline.Business.User;
using MasjidOnline.Data;
using MasjidOnline.Data.EntityFramework;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Service.Captcha;
using MasjidOnline.Service.Cryptography;
using MasjidOnline.Service.Cryptography.Interface.Model;
using MasjidOnline.Service.FieldValidator;
using MasjidOnline.Service.Hash;
using MasjidOnline.Service.Mail.Interface.Model;
using MasjidOnline.Service.Mail.MailKit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var webApplication = BuildApplication(args);

await InitializeAsync(webApplication);

if (webApplication.Environment.IsDevelopment() || Debugger.IsAttached)
{
    webApplication.UseMiddleware<DevelopmentExceptionMiddleware>();
}
else
{
    webApplication.UseMiddleware<ExceptionMiddleware>();
}

webApplication.UseCors();

webApplication.UseMiddleware<AuthenticationMiddleware>();

webApplication.MapEndpoints();

webApplication.Run();


static WebApplication BuildApplication(string[] args)
{
    var webApplicationBuilder = WebApplication.CreateBuilder(args);


    webApplicationBuilder.Configuration.AddJsonFile("appsettings.Local.json", true, true);

    var option = webApplicationBuilder.Configuration.Get<BusinessOptions>() ?? throw new ApplicationException($"Get {nameof(BusinessOptions)} fail");

    webApplicationBuilder.Services.Configure<CryptographyOptions>(webApplicationBuilder.Configuration.GetSection("Cryptography"));

    webApplicationBuilder.Services.Configure<MailOptions>(webApplicationBuilder.Configuration.GetSection("Mail"));

    webApplicationBuilder.Services.Configure<BusinessOptions>(webApplicationBuilder.Configuration);


    webApplicationBuilder.Services.AddCors(corsOptions =>
    {
        corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins(option.Uri.WebOrigin)
                .WithExposedHeaders(Constant.HttpHeaderName.ResultCode, Constant.HttpHeaderName.ResultMessage)
                .AllowCredentials()
                .AllowAnyHeader();
        });
    });


    #region add dependency

    webApplicationBuilder.Services.AddCaptchaService();
    webApplicationBuilder.Services.AddEncryptionService();
    webApplicationBuilder.Services.AddFieldValidatorService();
    webApplicationBuilder.Services.AddHashService();
    webApplicationBuilder.Services.AddMailKitMailService();

    webApplicationBuilder.Services.AddData();
    webApplicationBuilder.Services.AddEntityFrameworkData();
    webApplicationBuilder.Services.AddSqLiteEntityFrameworkData(webApplicationBuilder.Configuration);

    webApplicationBuilder.Services.AddAuthorizationBusiness();
    webApplicationBuilder.Services.AddCaptchaBusiness();
    webApplicationBuilder.Services.AddInfaqBusiness();
    webApplicationBuilder.Services.AddSessionBusiness();
    webApplicationBuilder.Services.AddUserBusiness();

    #endregion


    webApplicationBuilder.WebHost.UseShutdownTimeout(TimeSpan.FromSeconds(16));

    return webApplicationBuilder.Build();
}


static async Task InitializeAsync(WebApplication webApplication)
{
    using var serviceScope = webApplication.Services.CreateScope();

    var dataTransaction = GetService<IDataTransaction>(serviceScope.ServiceProvider);

    var auditData = GetService<IAuditData>(serviceScope.ServiceProvider);
    var captchaData = GetService<ICaptchaData>(serviceScope.ServiceProvider);
    var eventData = GetService<IEventData>(serviceScope.ServiceProvider);
    var infaqData = GetService<IInfaqData>(serviceScope.ServiceProvider);
    var personData = GetService<IPersonData>(serviceScope.ServiceProvider);
    var sessionData = GetService<ISessionData>(serviceScope.ServiceProvider);
    var userData = GetService<IUserData>(serviceScope.ServiceProvider);

    var auditInitializer = GetService<IAuditInitializer>(serviceScope.ServiceProvider);
    var captchaInitializer = GetService<ICaptchaInitializer>(serviceScope.ServiceProvider);
    var eventInitializer = GetService<IEventInitializer>(serviceScope.ServiceProvider);
    var infaqInitializer = GetService<IInfaqInitializer>(serviceScope.ServiceProvider);
    var personInitializer = GetService<IPersonInitializer>(serviceScope.ServiceProvider);
    var sessionInitializer = GetService<ISessionInitializer>(serviceScope.ServiceProvider);
    var userInitializer = GetService<IUserInitializer>(serviceScope.ServiceProvider);

    var auditIdGenerator = GetService<IAuditIdGenerator>(serviceScope.ServiceProvider);
    var captchaIdGenerator = GetService<ICaptchaIdGenerator>(serviceScope.ServiceProvider);
    var eventIdGenerator = GetService<IEventIdGenerator>(serviceScope.ServiceProvider);
    var infaqIdGenerator = GetService<IInfaqIdGenerator>(serviceScope.ServiceProvider);
    var personIdGenerator = GetService<IPersonIdGenerator>(serviceScope.ServiceProvider);
    var sessionIdGenerator = GetService<ISessionIdGenerator>(serviceScope.ServiceProvider);
    var userIdGenerator = GetService<IUserIdGenerator>(serviceScope.ServiceProvider);

    var userInitializerBusiness = GetService<MasjidOnline.Business.User.Interface.IInitializerBusiness>(serviceScope.ServiceProvider);


    await auditInitializer.InitializeDatabaseAsync(auditData);
    await captchaInitializer.InitializeDatabaseAsync(captchaData);
    await eventInitializer.InitializeDatabaseAsync(eventData);
    await infaqInitializer.InitializeDatabaseAsync(infaqData);
    await personInitializer.InitializeDatabaseAsync(personData);
    await sessionInitializer.InitializeDatabaseAsync(sessionData);
    await userInitializer.InitializeDatabaseAsync(userData);


    await auditIdGenerator.InitializeAsync(auditData);
    await captchaIdGenerator.InitializeAsync(captchaData);
    await eventIdGenerator.InitializeAsync(eventData);
    await infaqIdGenerator.InitializeAsync(infaqData);
    await personIdGenerator.InitializeAsync(personData);
    await sessionIdGenerator.InitializeAsync(sessionData);
    await userIdGenerator.InitializeAsync(userData);


    await userInitializerBusiness.InitializeAsync(dataTransaction, userData, auditData);
}

static TService GetService<TService>(IServiceProvider serviceProvider)
{
    return serviceProvider.GetService<TService>() ?? throw new ApplicationException($"Get {typeof(TService).Name} service fail");
}