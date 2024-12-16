using MasjidOnline.Api.Web;
using MasjidOnline.Business.Donation;
using Microsoft.AspNetCore.Builder;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddDonationBusiness();

var webApplication = webApplicationBuilder.Build();

webApplication.UseHttpsRedirection();

webApplication.MapEndpoint();

webApplication.Run();
