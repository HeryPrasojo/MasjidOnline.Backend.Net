using MasjidOnline.Backend.Api.Web;
using MasjidOnline.Backend.Business.Authentication;
using MasjidOnline.Backend.Business.Interface.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddSingleton<ILoginBusiness, LoginBusiness>();

var webApplication = webApplicationBuilder.Build();

webApplication.UseHttpsRedirection();

webApplication.MapEndpoint();

webApplication.Run();
