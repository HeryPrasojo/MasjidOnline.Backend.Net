using System;
using System.Diagnostics;
using System.Text.Json;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var webApplication = BuildApplication(args);

await webApplication.InitializeAsync();

webApplication.UseCors();

webApplication.UseMiddleware<AuthenticationMiddleware>();

webApplication.MapHub<ConnectionHub>("/hub"/*, httpConnectionDispatcherOptions => { }*/);

webApplication.MapEndpoints();

webApplication.Run();


static WebApplication BuildApplication(string[] args)
{
    var webApplicationBuilder = WebApplication.CreateSlimBuilder(args);

    webApplicationBuilder.Configuration.AddJsonFile("appsettings.Local.json", true, true);

    var businessOption = webApplicationBuilder.Configuration.Get<BusinessOptions>() ?? throw new ApplicationException($"Get {nameof(BusinessOptions)} fail");

    webApplicationBuilder.Services.ConfigureHttpJsonOptions(jsonOptions => SetJsonOptions(jsonOptions.SerializerOptions));

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
            hubOptions.EnableDetailedErrors = webApplicationBuilder.Environment.IsDevelopment();
            hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(32);

            hubOptions.AddFilter<HubFilter>();
        })
        .AddJsonProtocol(jsonHubProtocolOptions => SetJsonOptions(jsonHubProtocolOptions.PayloadSerializerOptions));

    webApplicationBuilder.Services.AddSingleton<HubFilter>();

    webApplicationBuilder.Services.AddSingleton<IEndpointFilter, EndpointFilter>();


    #region add dependency

    webApplicationBuilder.Services.AddService(webApplicationBuilder.Configuration);

    webApplicationBuilder.Services.AddData();
    webApplicationBuilder.Services.AddEntityFrameworkData();
    webApplicationBuilder.Services.AddSqLiteEntityFrameworkData(webApplicationBuilder.Configuration);

    webApplicationBuilder.Services.AddBusiness(webApplicationBuilder.Configuration);

    #endregion

    webApplicationBuilder.Services.AddHostedServices();


    if (Debugger.IsAttached)
    {
        webApplicationBuilder.WebHost.UseKestrelHttpsConfiguration();
    }


    webApplicationBuilder.WebHost.UseShutdownTimeout(TimeSpan.FromSeconds(16));

    return webApplicationBuilder.Build();
}

static void SetJsonOptions(JsonSerializerOptions jsonSerializerOptions)
{
    jsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    jsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict;
    jsonSerializerOptions.PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate;
    jsonSerializerOptions.PropertyNamingPolicy = null;
}
