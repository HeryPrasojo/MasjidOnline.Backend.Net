using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using MasjidOnline.Api.Web;
using MasjidOnline.Api.Web.Filter;
using MasjidOnline.Api.Web.HostedServices;
using MasjidOnline.Api.Web.Middleware;
using MasjidOnline.Api.Web.WebApplicationExtension;
using MasjidOnline.Business;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Data;
using MasjidOnline.Data.EntityFramework;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
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

webApplication.MapHub<ConnectionHub>("/hub");

webApplication.Run();


static WebApplication BuildApplication(string[] args)
{
    var webApplicationBuilder = WebApplication.CreateBuilder(args);

    webApplicationBuilder.Configuration.AddJsonFile("appsettings.Local.json", true, true);

    var businessOption = webApplicationBuilder.Configuration.Get<BusinessOptions>() ?? throw new ApplicationException($"Get {nameof(BusinessOptions)} fail");

    webApplicationBuilder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    webApplicationBuilder.Services.AddCors(
        corsOptions =>
    {
        corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
        {
            corsPolicyBuilder.WithOrigins(businessOption.Uri.WebOrigin)
                .AllowAnyHeader()
                //.WithExposedHeaders(Constant.HttpHeaderName.ResultCode, Constant.HttpHeaderName.ResultMessage)
                .WithExposedHeaders(Constant.HttpHeaderName.Session);
            //corsPolicyBuilder.WithOrigins(option.Uri.WebOrigin)
            //    .AllowCredentials()
            //    .AllowAnyHeader();
        });
    });


    webApplicationBuilder.Services.AddSignalR(
        hubOptions =>
    {
        hubOptions.AddFilter<HubFilter>();
    });

    webApplicationBuilder.Services.AddSingleton<ConnectionHub>();
    webApplicationBuilder.Services.AddSingleton<HubFilter>();


    #region add dependency

    webApplicationBuilder.Services.AddService(webApplicationBuilder.Configuration);

    webApplicationBuilder.Services.AddData();
    webApplicationBuilder.Services.AddEntityFrameworkData();
    webApplicationBuilder.Services.AddSqLiteEntityFrameworkData(webApplicationBuilder.Configuration);

    webApplicationBuilder.Services.AddBusiness(webApplicationBuilder.Configuration);

    #endregion

    webApplicationBuilder.Services.AddHostedServices();

    webApplicationBuilder.WebHost.UseShutdownTimeout(TimeSpan.FromSeconds(16));

    return webApplicationBuilder.Build();
}
