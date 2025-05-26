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
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
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

webApplication.UseRequestLocalization(requestLocalizationOptions =>
{
    requestLocalizationOptions.ApplyCurrentCultureToResponseHeaders = true;

    requestLocalizationOptions.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async httpContext =>
    {
        var cultureQueryExists = httpContext.Request.Query.TryGetValue("culture", out var culture);

        if (cultureQueryExists && !string.IsNullOrWhiteSpace(culture))
        {
            string cultureString = culture.ToString();

            var data = httpContext.RequestServices.GetService<IData>() ?? throw new ErrorException($"get {nameof(IData)} failed");

            data.User.UserPreference.;

            // todo save to db

            return new ProviderCultureResult(cultureString, cultureString);
        }


        // todo check cookie


        // todo check db: session, user


        // todo check http header


        // todo else return default

        return new ProviderCultureResult("", "");
    }));
});

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

    webApplicationBuilder.Services.AddCors(corsOptions =>
    {
        corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins(option.Uri.WebOrigin)
                .AllowAnyHeader()
                //.WithExposedHeaders(Constant.HttpHeaderName.ResultCode, Constant.HttpHeaderName.ResultMessage)
                .WithExposedHeaders(Constant.HttpHeaderName.Session);
            //corsPolicyBuilder.WithOrigins(option.Uri.WebOrigin)
            //    .AllowCredentials()
            //    .AllowAnyHeader();
        });
    });

    #region add dependency

    webApplicationBuilder.Services.AddService(webApplicationBuilder.Configuration);

    webApplicationBuilder.Services.AddData();
    webApplicationBuilder.Services.AddEntityFrameworkData();
    webApplicationBuilder.Services.AddSqLiteEntityFrameworkData(webApplicationBuilder.Configuration);

    webApplicationBuilder.Services.AddBusiness(webApplicationBuilder.Configuration);

    #endregion


    webApplicationBuilder.WebHost.UseShutdownTimeout(TimeSpan.FromSeconds(16));

    return webApplicationBuilder.Build();
}
