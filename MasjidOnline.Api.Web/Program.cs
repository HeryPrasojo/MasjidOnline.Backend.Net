using MasjidOnline.Api.Web;
using MasjidOnline.Business.Authentication;
using MasjidOnline.Business.Interface.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddSingleton<ILoginBusiness, LoginBusiness>();

var webApplication = webApplicationBuilder.Build();

webApplication.UseHttpsRedirection();

webApplication.MapEndpoint();

webApplication.Run();
