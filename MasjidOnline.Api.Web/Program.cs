using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using MasjidOnline.Api.Web;
using MasjidOnline.Api.Web.Middleware;
using MasjidOnline.Api.Web.WebApplicationExtension;
using MasjidOnline.Business;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Data;
using MasjidOnline.Data.EntityFramework;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Service.Captcha.ReCaptcha;
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

await webApplication.InitializeAsync();

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

    webApplicationBuilder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

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

    //webApplicationBuilder.Services.AddCaptchaService();
    webApplicationBuilder.Services.AddEncryptionService();
    webApplicationBuilder.Services.AddFieldValidatorService();
    webApplicationBuilder.Services.AddHashService();
    webApplicationBuilder.Services.AddMailKitMailService();
    webApplicationBuilder.Services.AddReCaptchaService();

    webApplicationBuilder.Services.AddData();
    webApplicationBuilder.Services.AddEntityFrameworkData();
    webApplicationBuilder.Services.AddSqLiteEntityFrameworkData(webApplicationBuilder.Configuration);

    webApplicationBuilder.Services.AddBusiness();

    #endregion


    webApplicationBuilder.WebHost.UseShutdownTimeout(TimeSpan.FromSeconds(16));

    return webApplicationBuilder.Build();
}
