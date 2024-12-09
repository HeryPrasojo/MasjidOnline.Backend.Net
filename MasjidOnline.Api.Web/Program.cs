using MasjidOnline.Api.Web;
using MasjidOnline.Business;
using Microsoft.AspNetCore.Builder;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddBusiness();

var webApplication = webApplicationBuilder.Build();

webApplication.UseHttpsRedirection();

webApplication.MapEndpoint();

webApplication.Run();
